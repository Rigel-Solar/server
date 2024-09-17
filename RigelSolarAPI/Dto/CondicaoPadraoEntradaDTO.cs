namespace RigelSolarAPI.Dto;

public partial class CondicaoPadraoEntradaDTO
{

    public string Condicao { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
