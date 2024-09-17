namespace RigelSolarAPI.Dto;

public partial class LocalInstalacaoModuloDTO
{
    public string Local { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
