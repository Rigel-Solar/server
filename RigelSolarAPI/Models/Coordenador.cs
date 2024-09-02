namespace RigelSolarAPI.Models;

public partial class Coordenador
{
    public int Id { get; set; }

    public int? IdTecnico { get; set; }

    public virtual Tecnico? IdTecnicoNavigation { get; set; }

    public virtual ICollection<Vistorium> Vistoria { get; set; } = new List<Vistorium>();
}
