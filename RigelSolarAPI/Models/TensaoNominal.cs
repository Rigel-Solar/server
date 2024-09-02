namespace RigelSolarAPI.Models;

public partial class TensaoNominal
{
    public int Id { get; set; }

    public string Tensao { get; set; } = null!;

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
