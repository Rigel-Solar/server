namespace RigelSolarAPI.Models;

public partial class CondicaoPadraoEntradum
{
    public int Id { get; set; }

    public string Condicao { get; set; } = null!;

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
