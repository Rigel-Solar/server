using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class CoordenadorRepository : BaseRepository<Coordenador>
{
    public CoordenadorRepository(RigelSolarContext context) : base(context)
    {
    }

    public async Task<Coordenador?> VerDadosPorEmail(string email)
    {
        Coordenador? tecnico = await _context
            .Coordenadors
            .Include(x => x.IdTecnicoNavigation)
            .ThenInclude(x => x.IdUsuarioNavigation)
            .FirstOrDefaultAsync(x => x.IdTecnicoNavigation.IdUsuarioNavigation.Email == email);

        return tecnico;
    }
}
