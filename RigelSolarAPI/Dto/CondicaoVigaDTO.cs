namespace RigelSolarAPI.Dto;

public partial class CondicaoVigaDTO
{
    public string Condicao { get; set; } = null!;

    public virtual FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
