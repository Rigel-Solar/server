namespace RigelSolarAPI.Dto;

public class VistoriaFichaDTO
{
    public int? IdGestor { get; set; }

    public int? IdCliente { get; set; }

    public string TipoInstalacao { get; set; } = null!;

    public string Solucoes { get; set; } = null!;

    public string PretendeInstalarEm { get; set; } = null!;

    public decimal ValorContaLuz { get; set; }

    public string? Comentarios { get; set; }
}

public class GetVistoriaFichaDTO : VistoriaDTO
{
    public int Id { get; set; }
    public virtual ClienteDTO? IdClienteNavigation { get; set; }

    public virtual GestorDTO? IdGestorNavigation { get; set; }
}

