namespace RigelSolarAPI.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual ICollection<Vistorium> Vistoria { get; set; } = new List<Vistorium>();
}
