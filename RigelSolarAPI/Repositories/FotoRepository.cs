using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class FotoRepository : BaseRepository<Foto>
{
    public FotoRepository(RigelSolarContext context) : base(context)
    {
    }
}
