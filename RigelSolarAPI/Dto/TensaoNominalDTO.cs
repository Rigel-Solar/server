using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class TensaoNominalDTO
{
    public string Tensao { get; set; } = null!;
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
