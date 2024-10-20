using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class TipoClienteDTO
{
    public string Tipo { get; set; } = null!;
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
