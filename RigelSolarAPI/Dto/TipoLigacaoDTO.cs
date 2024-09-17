namespace RigelSolarAPI.Dto;

public partial class TipoLigacaoDTO
{
    public string Tipo { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
