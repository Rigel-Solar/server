namespace RigelSolarAPI.Dto;

public partial class NivelamentoSoloDTO
{
    public string Nivelamento { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
