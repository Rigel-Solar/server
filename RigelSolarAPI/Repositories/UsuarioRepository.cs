using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>
{
    public UsuarioRepository(RigelSolarContext context) : base(context)
    {
    }

    public async Task<Usuario?> VerDadosPorEmail(string email)
    {
        Usuario? usuario = await _context
            .Usuarios
            .FirstOrDefaultAsync(x => x.Email == email);

        return usuario;
    }
}
