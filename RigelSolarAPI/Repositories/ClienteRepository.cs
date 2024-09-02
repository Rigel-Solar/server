using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class ClienteRepository : BaseRepository<Cliente>
{
    public ClienteRepository(RigelSolarContext context) : base(context)
    {
    }
}
