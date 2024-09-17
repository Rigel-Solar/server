namespace RigelSolarAPI.Dto;

public partial class ModeloRelogioDTO
{

    public string Modelo { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
