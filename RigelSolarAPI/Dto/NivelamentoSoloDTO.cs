using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class NivelamentoSoloDTO
{
    public string Nivelamento { get; set; } = null!;
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
