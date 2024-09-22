using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class FichaBanhoRepository : BaseRepository<FichaBanho>
{
    public FichaBanhoRepository(RigelSolarContext context) : base(context)
    {
    }
    public async Task<FichaBanho?> GetAllByTecnicoId(int Id)
    {
        FichaBanho? fichaBanho = await _context
            .FichaBanhos
            .Include(x => x.IdVistoriaNavigation)
            .ThenInclude(x => x.IdTecnicoNavigation)
            .FirstOrDefaultAsync(x => x.IdVistoriaNavigation.IdTecnicoNavigation.Id == Id);

        return fichaBanho;
    }
}
