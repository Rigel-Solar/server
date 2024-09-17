using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class FichaBanhoRepository : BaseRepository<FichaBanho>
{
    public FichaBanhoRepository(RigelSolarContext context) : base(context)
    {
    }
}
