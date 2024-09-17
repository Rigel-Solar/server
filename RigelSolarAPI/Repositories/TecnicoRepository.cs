using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class TecnicoRepository : BaseRepository<Tecnico>
{
    public TecnicoRepository(RigelSolarContext context) : base(context)
    {
    }
}
