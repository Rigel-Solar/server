using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class VistoriaRepository : BaseRepository<Vistorium>
{
    public VistoriaRepository(RigelSolarContext context) : base(context)
    {
    }

    public async Task<Vistorium?> GetAllByTecnicoId(int Id)
    {
        Vistorium? vistoria = await _context
            .Vistoria
            .Include(x => x.IdTecnicoNavigation)
            .FirstOrDefaultAsync(x => x.IdTecnicoNavigation.Id == Id);

        return vistoria;
    }
}
