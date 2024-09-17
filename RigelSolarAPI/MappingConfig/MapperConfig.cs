using AutoMapper;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.MappingConfig;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<UsuarioDTO, Usuario>();
        CreateMap<ClienteDTO, Cliente>();
        CreateMap<TecnicoDTO, Tecnico>();
        CreateMap<FichaBanhoDTO, FichaBanho>();
        CreateMap<FichaPiscinaDTO, FichaPiscina>();
        CreateMap<CondicaoPadraoEntradaDTO, CondicaoPadraoEntradum>();
        CreateMap<CondicaoQuadroPrincipalDTO, CondicaoQuadroPrincipalEnergium>();
        CreateMap<CondicaoVigaDTO, CondicaoViga>();
        CreateMap<IdadeTelhadoDTO, IdadeTelhado>();
        CreateMap<LocalInstalacaoModuloDTO, LocalInstalacaoModulo>();
        CreateMap<MaterialVigasTelhadoDTO, MaterialVigasTelhado>();
        CreateMap<ModeloRelogioDTO, ModeloRelogio>();
        CreateMap<NivelamentoSoloDTO, NivelamentoSolo>();
        CreateMap<TelhadoAcessoDTO, TelhadoAcesso>();
        CreateMap<TensaoNominalDTO, TensaoNominal>();
        CreateMap<TipoClienteDTO, TipoCliente>();
        CreateMap<TipoLigacaoDTO, TipoLigacao>();
        CreateMap<TipoSuperficieDTO, TipoSuperficie>();
        CreateMap<FichaFotovoltaicoDTO, FichaFotovoltaico>();
    }
}
