using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class FichaPiscinaRepository : BaseRepository<FichaPiscina>
{
    public FichaPiscinaRepository(RigelSolarContext context) : base(context)
    {
    }
}
