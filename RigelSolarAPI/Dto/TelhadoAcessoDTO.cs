using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class TelhadoAcessoDTO
{
    public string Acesso { get; set; } = null!;
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
