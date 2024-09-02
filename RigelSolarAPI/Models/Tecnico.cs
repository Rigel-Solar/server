namespace RigelSolarAPI.Models;

public partial class Tecnico
{
    public int Id { get; set; }

    public string Crea { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public virtual ICollection<Coordenador> Coordenadors { get; set; } = new List<Coordenador>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Vistorium> Vistoria { get; set; } = new List<Vistorium>();
}
