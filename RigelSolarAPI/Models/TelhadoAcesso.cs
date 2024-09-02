namespace RigelSolarAPI.Models;

public partial class TelhadoAcesso
{
    public int Id { get; set; }

    public string Acesso { get; set; } = null!;

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();
}
