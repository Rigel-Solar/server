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
        CreateMap<ClienteDTO, Cliente>();
        CreateMap<Cliente, GetClienteDTO>();
        CreateMap<TecnicoDTO, Tecnico>();
        CreateMap<Tecnico, GetTecnicoDTO>()
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.IdUsuarioNavigation));
        CreateMap<FichaBanhoDTO, FichaBanho>();
        CreateMap<FichaBanho, GetFichaBanhoDTO>();
        CreateMap<FichaPiscinaDTO, FichaPiscina>();
        CreateMap<FichaPiscina, GetFichaPiscinaDTO>();
        CreateMap<CondicaoPadraoEntradaDTO, CondicaoPadraoEntradum>(); //
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
        CreateMap<FichaFotovoltaicoDTO, FichaFotovoltaico>()
            .ForMember(dest => dest.IdCondicaoPadraoEntradaNavigation, opt => opt.MapFrom(src => src.CondicaoPadraoEntradaDTO))
            .ForMember(dest => dest.IdCondicaoQuadroPrincipalEnergiaNavigation, opt => opt.MapFrom(src => src.CondicaoQuadroPrincipalDTO))
            .ForMember(dest => dest.IdCondicaoVigasNavigation, opt => opt.MapFrom(src => src.CondicaoVigaDTO))
            .ForMember(dest => dest.IdIdadeTelhadoNavigation, opt => opt.MapFrom(src => src.IdadeTelhadoDTO))
            .ForMember(dest => dest.IdLocalInstalacaoModulosNavigation, opt => opt.MapFrom(src => src.LocalInstalacaoModuloDTO))
            .ForMember(dest => dest.IdMaterialVigasTelhadoNavigation, opt => opt.MapFrom(src => src.MaterialVigasTelhadoDTO))
            .ForMember(dest => dest.IdModeloRelogioNavigation, opt => opt.MapFrom(src => src.ModeloRelogioDTO))
            .ForMember(dest => dest.IdNivelamentoSoloNavigation, opt => opt.MapFrom(src => src.NivelamentoSoloDTO))
            .ForMember(dest => dest.IdTelhadoAcessoNavigation, opt => opt.MapFrom(src => src.TelhadoAcessoDTO))
            .ForMember(dest => dest.IdTensaoNominalNavigation, opt => opt.MapFrom(src => src.TensaoNominalDTO))
            .ForMember(dest => dest.IdTipoClienteNavigation, opt => opt.MapFrom(src => src.TipoClienteDTO))
            .ForMember(dest => dest.IdTipoLigacaoNavigation, opt => opt.MapFrom(src => src.TipoLigacaoDTO))
            .ForMember(dest => dest.IdTipoSuperficieNavigation, opt => opt.MapFrom(src => src.TipoSuperficieDTO))
            ;
        CreateMap<FichaFotovoltaico, GetFichaFotovoltaicoDTO>()
            .ForMember(dest => dest.CondicaoPadraoEntradaDTO, opt => opt.MapFrom(src => src.IdCondicaoPadraoEntradaNavigation))
            .ForMember(dest => dest.CondicaoQuadroPrincipalDTO, opt => opt.MapFrom(src => src.IdCondicaoQuadroPrincipalEnergiaNavigation))
            .ForMember(dest => dest.CondicaoVigaDTO, opt => opt.MapFrom(src => src.IdCondicaoVigasNavigation))
            .ForMember(dest => dest.IdadeTelhadoDTO, opt => opt.MapFrom(src => src.IdIdadeTelhadoNavigation))
            .ForMember(dest => dest.LocalInstalacaoModuloDTO, opt => opt.MapFrom(src => src.IdLocalInstalacaoModulosNavigation))
            .ForMember(dest => dest.MaterialVigasTelhadoDTO, opt => opt.MapFrom(src => src.IdMaterialVigasTelhadoNavigation))
            .ForMember(dest => dest.ModeloRelogioDTO, opt => opt.MapFrom(src => src.IdModeloRelogioNavigation))
            .ForMember(dest => dest.NivelamentoSoloDTO, opt => opt.MapFrom(src => src.IdNivelamentoSoloNavigation))
            .ForMember(dest => dest.TelhadoAcessoDTO, opt => opt.MapFrom(src => src.IdTelhadoAcessoNavigation))
            .ForMember(dest => dest.TensaoNominalDTO, opt => opt.MapFrom(src => src.IdTensaoNominalNavigation))
            .ForMember(dest => dest.TipoClienteDTO, opt => opt.MapFrom(src => src.IdTipoClienteNavigation))
            .ForMember(dest => dest.TipoLigacaoDTO, opt => opt.MapFrom(src => src.IdTipoLigacaoNavigation))
            .ForMember(dest => dest.TipoSuperficieDTO, opt => opt.MapFrom(src => src.IdTipoSuperficieNavigation))
            ;
        CreateMap<VistoriaDTO, Vistorium>();
        CreateMap<Vistorium, GetVistoriaDTO>();
    }
}
