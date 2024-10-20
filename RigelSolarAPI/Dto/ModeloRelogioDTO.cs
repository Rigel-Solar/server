using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class ModeloRelogioDTO
{

    public string Modelo { get; set; } = null!;
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
