using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using System.Reflection.Metadata.Ecma335;

namespace RigelSolarAPI.Repositories;

public class BaseRepository<T> where T : class
{
    protected readonly RigelSolarContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(RigelSolarContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = _dbSet.AsQueryable();

        // Recursively include all navigation properties and their nested properties
        query = IncludeNavigations(query, typeof(T), new HashSet<Type>());

        return query.ToList();
    }

    private IQueryable<T> IncludeNavigations(IQueryable<T> query, Type entityType, HashSet<Type> visitedTypes)
    {
        // Avoid processing the same entity type multiple times (to prevent cycles)
        if (!visitedTypes.Add(entityType))
        {
            return query; // Skip this entity type
        }

        // Get all navigation properties of the current entity type
        var navigationProperties = _context.Model.FindEntityType(entityType)
            .GetNavigations()
            .ToList();

        foreach (var navigation in navigationProperties)
        {
            // Include the navigation property
            query = query.Include(navigation.Name);

            // Check if this navigation property itself has navigation properties (i.e., it's a complex type or a collection)
            var nestedEntityType = navigation.ClrType;

            // Only recurse if the navigation target type has additional navigations
            if (_context.Model.FindEntityType(nestedEntityType)?.GetNavigations().Any() == true)
            {
                // Use ThenInclude with recursion
                query = IncludeNestedNavigation(query, navigation.Name, nestedEntityType, visitedTypes);
            }
        }

        return query;
    }

    private IQueryable<T> IncludeNestedNavigation(IQueryable<T> query, string navigationProperty, Type entityType, HashSet<Type> visitedTypes)
    {
        // Avoid processing the same entity type multiple times (to prevent cycles)
        if (!visitedTypes.Add(entityType))
        {
            return query; // Skip this entity type
        }

        // Get all navigation properties of the nested entity type
        var nestedNavigations = _context.Model.FindEntityType(entityType).GetNavigations().ToList();

        foreach (var nestedNavigation in nestedNavigations)
        {
            // Apply ThenInclude for each nested navigation property
            query = query.Include($"{navigationProperty}.{nestedNavigation.Name}");

            // Recursively add ThenIncludes if the nested navigation has further navigation properties
            if (_context.Model.FindEntityType(nestedNavigation.ClrType)?.GetNavigations().Any() == true)
            {
                query = IncludeNestedNavigation(query, $"{navigationProperty}.{nestedNavigation.Name}", nestedNavigation.ClrType, visitedTypes);
            }
        }

        return query;
    }


    public T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        Save();
        return entity;
    }

    public T Update(T entity) 
    {
        _context.Set<T>().Update(entity);
        Save();
        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity != null)
        {
            _dbSet.Remove(entity);
            Save();
        }
    }

    public T GetById(object id)
    {
        IQueryable<T> query = _dbSet.AsQueryable();

        // Incluir navegações recursivamente
        query = IncludeNavigations(query, typeof(T), new HashSet<Type>());

        var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.First();

        return query.FirstOrDefault(e => EF.Property<object>(e, key.Name).Equals(id));
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
