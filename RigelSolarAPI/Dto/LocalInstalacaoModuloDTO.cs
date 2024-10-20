using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class LocalInstalacaoModuloDTO
{
    public string Local { get; set; } = null!;
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
