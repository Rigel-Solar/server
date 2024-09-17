namespace RigelSolarAPI.Dto;

public partial class CondicaoQuadroPrincipalDTO
{
    public string Condicao { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
