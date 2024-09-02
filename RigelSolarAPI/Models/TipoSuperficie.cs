namespace RigelSolarAPI.Models;

public partial class TipoSuperficie
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
