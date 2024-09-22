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
        return _dbSet.ToList();
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
        return _dbSet.Find(id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
