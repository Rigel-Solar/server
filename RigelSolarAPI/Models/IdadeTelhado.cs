namespace RigelSolarAPI.Models;

public partial class IdadeTelhado
{
    public int Id { get; set; }

    public int Idade { get; set; }

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
