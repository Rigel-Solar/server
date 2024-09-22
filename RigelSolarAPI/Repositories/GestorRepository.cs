using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class GestorRepository : BaseRepository<Gestor>
{
    public GestorRepository(RigelSolarContext context) : base(context)
    {
    }

    public async Task<Gestor?> VerDadosPorEmail(string email)
    {
        Gestor? gestor = await _context
            .Gestors
            .Include(x => x.IdUsuarioNavigation)
            .FirstOrDefaultAsync(x => x.IdUsuarioNavigation.Email == email);

        return gestor;
    }
}
