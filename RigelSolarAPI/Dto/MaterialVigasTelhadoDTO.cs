namespace RigelSolarAPI.Dto;

public partial class MaterialVigasTelhadoDTO
{
    public string Condicao { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
