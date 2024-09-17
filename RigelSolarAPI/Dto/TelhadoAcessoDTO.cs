namespace RigelSolarAPI.Dto;

public partial class TelhadoAcessoDTO
{
    public string Acesso { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
