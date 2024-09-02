namespace RigelSolarAPI.Models;

public partial class LocalInstalacaoModulo
{
    public int Id { get; set; }

    public string Local { get; set; } = null!;

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
