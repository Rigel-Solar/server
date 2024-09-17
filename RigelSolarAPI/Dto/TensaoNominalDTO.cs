namespace RigelSolarAPI.Dto;

public partial class TensaoNominalDTO
{
    public string Tensao { get; set; } = null!;

    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
