namespace RigelSolarAPI.Dto;

public class FichaPiscinaDTO
{
    public decimal Comprimento { get; set; }

    public decimal Largura { get; set; }

    public decimal Profundidade { get; set; }

    public decimal TemperaturaAgua { get; set; }

    public string UsoCapaTermica { get; set; } = null!;

    public string Regiao { get; set; } = null!;

    public string Ambiente { get; set; } = null!;

    public int? IdVistoria { get; set; }
}

public class GetFichaPiscinaDTO : FichaPiscinaDTO
{
    public int Id { get; set; }
    public virtual GetVistoriaFichaDTO? VistoriaDTO { get; set; }
}

