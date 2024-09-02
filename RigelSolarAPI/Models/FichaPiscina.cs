namespace RigelSolarAPI.Models;

public partial class FichaPiscina
{
    public int Id { get; set; }

    public decimal Comprimento { get; set; }

    public decimal Largura { get; set; }

    public decimal Profundidade { get; set; }

    public decimal TemperaturaAgua { get; set; }

    public string UsoCapaTermica { get; set; } = null!;

    public string Regiao { get; set; } = null!;

    public string Ambiente { get; set; } = null!;

    public int? IdVistoria { get; set; }

    public virtual ICollection<Foto> Fotos { get; set; } = new List<Foto>();

    public virtual Vistorium? IdVistoriaNavigation { get; set; }
}
