using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class IdadeTelhadoDTO
{
    public int Idade { get; set; }
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
