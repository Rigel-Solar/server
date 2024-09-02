namespace RigelSolarAPI.Models;

public partial class ModeloRelogio
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
