using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class CondicaoVigaDTO
{
    public string Condicao { get; set; } = null!;
    [JsonIgnore]
    public virtual FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
