using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class FichaFotovoltaicoRepository : BaseRepository<FichaFotovoltaico>
{
    public FichaFotovoltaicoRepository(RigelSolarContext context) : base(context)
    {
    }
}
