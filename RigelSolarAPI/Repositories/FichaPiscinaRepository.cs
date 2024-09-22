using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class FichaPiscinaRepository : BaseRepository<FichaPiscina>
{
    public FichaPiscinaRepository(RigelSolarContext context) : base(context)
    {
    }

    public async Task<FichaPiscina?> GetAllByTecnicoId(int Id)
    {
        FichaPiscina? fichaPiscina = await _context
            .FichaPiscinas
            .Include(x => x.IdVistoriaNavigation)
            .ThenInclude(x => x.IdTecnicoNavigation)
            .FirstOrDefaultAsync(x => x.IdVistoriaNavigation.IdTecnicoNavigation.Id == Id);

        return fichaPiscina;
    }
}
