using System.Text.Json.Serialization;

namespace RigelSolarAPI.Dto;

public partial class CondicaoPadraoEntradaDTO
{

    public string Condicao { get; set; } = null!;
    [JsonIgnore]
    public FichaFotovoltaicoDTO? FichaFotovoltaico { get; set; }
}
