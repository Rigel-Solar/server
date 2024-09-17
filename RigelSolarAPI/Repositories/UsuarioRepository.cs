using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>
{
    public UsuarioRepository(RigelSolarContext context) : base(context)
    {
    }
}
