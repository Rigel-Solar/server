using RigelSolarAPI.Models;

namespace RigelSolarAPI.Dto;

public class VistoriaDTO
{
    public int? IdGestor { get; set; }

    public int? IdTecnico { get; set; }

    public int? IdCliente { get; set; }

    public string TipoInstalacao { get; set; } = null!;

    public string Solucoes { get; set; } = null!;

    public string PretendeInstalarEm { get; set; } = null!;

    public decimal ValorContaLuz { get; set; }

    public string? Comentarios { get; set; }
}

public class GetVistoriaDTO : VistoriaDTO
{
    public int Id { get; set; }

    public virtual ICollection<FichaBanhoDTO> FichaBanhos { get; set; } = new List<FichaBanhoDTO>();

    public virtual ICollection<FichaFotovoltaicoDTO> FichaFotovoltaicos { get; set; } = new List<FichaFotovoltaicoDTO>();

    public virtual ICollection<FichaPiscinaDTO> FichaPiscinas { get; set; } = new List<FichaPiscinaDTO>();

    public virtual ClienteDTO? IdClienteNavigation { get; set; }

    public virtual GestorDTO? IdGestorNavigation { get; set; }

    public virtual TecnicoDTO? IdTecnicoNavigation { get; set; }
}

