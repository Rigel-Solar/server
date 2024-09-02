namespace RigelSolarAPI.Models;

public partial class Vistorium
{
    public int Id { get; set; }

    public int? IdCoordenador { get; set; }

    public int? IdTecnico { get; set; }

    public int? IdCliente { get; set; }

    public virtual ICollection<FichaBanho> FichaBanhos { get; set; } = new List<FichaBanho>();

    public virtual ICollection<FichaPiscina> FichaPiscinas { get; set; } = new List<FichaPiscina>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Coordenador? IdCoordenadorNavigation { get; set; }

    public virtual Tecnico? IdTecnicoNavigation { get; set; }
}
