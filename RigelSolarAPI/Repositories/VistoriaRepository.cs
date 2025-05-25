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
            .Where(x => x.IdTecnicoNavigation.Id == Id)
            .ToListAsync();

        return vistoria;
    }
}
