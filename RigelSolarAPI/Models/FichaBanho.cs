namespace RigelSolarAPI.Models;

public partial class FichaBanho
{
    public int Id { get; set; }

    public decimal BaseCaixa { get; set; }

    public decimal BaseBoiler { get; set; }

    public decimal DistanciaBoiler { get; set; }

    public decimal RegistroCaixa { get; set; }

    public decimal RegistroBarrilete { get; set; }

    public decimal DisjuntorBipolar { get; set; }

    public int? IdVistoria { get; set; }

    public virtual ICollection<Foto> Fotos { get; set; } = new List<Foto>();

    public virtual Vistorium? IdVistoriaNavigation { get; set; }
}
