namespace RigelSolarAPI.Dto;

public partial class TipoClienteDTO
{
    public string Tipo { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
