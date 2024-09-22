using AutoMapper;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.MappingConfig;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<UsuarioDTO, Usuario>();
        CreateMap<Usuario, GetUsuarioDTO>();
        CreateMap<List<Usuario>, List<GetUsuarioDTO>>();
        CreateMap<ClienteDTO, Cliente>();
        CreateMap<Cliente, GetClienteDTO>();
        CreateMap<List<Cliente>, List<GetClienteDTO>>();
        CreateMap<TecnicoDTO, Tecnico>();
        CreateMap<Tecnico, GetTecnicoDTO>();
        CreateMap<List<Tecnico>, List<GetTecnicoDTO>>();
        CreateMap<FichaBanhoDTO, FichaBanho>();
        CreateMap<FichaBanho, GetFichaBanhoDTO>();
        CreateMap<List<FichaBanho>, List<GetFichaBanhoDTO>>();
        CreateMap<FichaPiscinaDTO, FichaPiscina>();
        CreateMap<FichaPiscina, GetFichaPiscinaDTO>();
        CreateMap<List<FichaPiscina>, List<GetFichaPiscinaDTO>>();
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
        CreateMap<FichaFotovoltaico, GetFichaFotovoltaicoDTO>();
        CreateMap<List<FichaFotovoltaico>, List<GetFichaFotovoltaicoDTO>>();
        CreateMap<VistoriaDTO, Vistorium>();
        CreateMap<Vistorium, GetVistoriaDTO>();
        CreateMap<List<Vistorium>, List<GetVistoriaDTO>>();
    }
}
