using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class FichaFotovoltaicoRepository : BaseRepository<FichaFotovoltaico>
{
    public FichaFotovoltaicoRepository(RigelSolarContext context) : base(context)
    {
    }
    
    public async Task<FichaFotovoltaico?> GetAllByTecnicoId(int Id)
    {
        FichaFotovoltaico? fichaFotovoltaico = await _context
            .FichaFotovoltaicos
            .Include(x => x.IdVistoriaNavigation)
            .ThenInclude(x => x.IdTecnicoNavigation)
            .FirstOrDefaultAsync(x => x.IdVistoriaNavigation.IdTecnicoNavigation.Id == Id);

        return fichaFotovoltaico;
    }
}
