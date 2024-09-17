namespace RigelSolarAPI.Dto;

public partial class TipoSuperficieDTO
{
    public string Tipo { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
