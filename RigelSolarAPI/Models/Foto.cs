namespace RigelSolarAPI.Models;

public partial class Foto
{
    public int Id { get; set; }

    public string Foto1 { get; set; } = null!;

    public string TipoFoto { get; set; } = null!;

    public int? IdFichaBanho { get; set; }

    public int? IdFichaPiscina { get; set; }

    public int? IdFichaFotovoltaico { get; set; }

    public virtual FichaBanho? IdFichaBanhoNavigation { get; set; }

    public virtual FichaFotovoltaico? IdFichaFotovoltaicoNavigation { get; set; }

    public virtual FichaPiscina? IdFichaPiscinaNavigation { get; set; }
}
