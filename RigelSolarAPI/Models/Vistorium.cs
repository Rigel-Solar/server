namespace RigelSolarAPI.Models;

public partial class Vistorium
{
    public int Id { get; set; }

    public int? IdGestor { get; set; }

    public int? IdTecnico { get; set; }

    public int? IdCliente { get; set; }

    public string TipoInstalacao { get; set; } = null!;

    public string Solucoes { get; set; } = null!;

    public string PretendeInstalarEm { get; set; } = null!;

    public decimal ValorContaLuz { get; set; }

    public string? Comentarios { get; set; }

    public virtual ICollection<FichaBanho> FichaBanhos { get; set; } = new List<FichaBanho>();

    public virtual ICollection<FichaFotovoltaico> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaico>();

    public virtual ICollection<FichaPiscina> FichaPiscinas { get; set; } = new List<FichaPiscina>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Gestor? IdGestorNavigation { get; set; }

    public virtual Tecnico? IdTecnicoNavigation { get; set; }
}
