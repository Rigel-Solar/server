namespace RigelSolarAPI.Models;

public partial class NivelamentoSolo
{
    public int Id { get; set; }

    public string Nivelamento { get; set; } = null!;

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
