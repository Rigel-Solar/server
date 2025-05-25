using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class VistoriaRepository : BaseRepository<Vistorium>
{
    public VistoriaRepository(RigelSolarContext context) : base(context)
    {
    }

    public async Task<List<Vistorium?>> GetAllByTecnicoId(int Id)
    {
        List<Vistorium?> vistoria = await _context
            .Vistoria
            .Include(x => x.IdTecnicoNavigation)
                .ThenInclude(x => x.IdUsuarioNavigation)
            .Include(x => x.IdClienteNavigation)
            .Include(x => x.IdGestorNavigation)
                .ThenInclude(x => x.IdUsuarioNavigation)
            .Where(x => x.IdTecnicoNavigation.Id == Id)
            .ToListAsync();

        return vistoria;
    }
}
