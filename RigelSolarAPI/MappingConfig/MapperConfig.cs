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
        CreateMap<Cliente, ClienteDTO>()
            .ReverseMap();
        CreateMap<Cliente, GetClienteDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
        CreateMap<TecnicoDTO, Tecnico>()
            .ReverseMap();
        CreateMap<Tecnico, GetTecnicoDTO>()
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.IdUsuarioNavigation))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
        CreateMap<FichaBanhoDTO, FichaBanho>();
        CreateMap<FichaBanho, GetFichaBanhoDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.VistoriaDTO, opt => opt.MapFrom(src => src.IdVistoriaNavigation))
            .ReverseMap();
        CreateMap<FichaPiscinaDTO, FichaPiscina>();
        CreateMap<FichaPiscina, GetFichaPiscinaDTO>();
        CreateMap<FichaPiscina, GetFichaPiscinaDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.VistoriaDTO, opt => opt.MapFrom(src => src.IdVistoriaNavigation))
            .ReverseMap();
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
            .ForMember(dest => dest.VistoriaDTO, opt => opt.MapFrom(src => src.IdVistoriaNavigation))
            .ReverseMap();
        ;
        CreateMap<Vistorium, VistoriaDTO>()
            .ReverseMap();

        CreateMap<Vistorium, GetVistoriaDTO>()
            .ForMember(dest => dest.FichaBanhos, opt => opt.MapFrom(src => src.FichaBanhos))
            .ForMember(dest => dest.FichaFotovoltaicos, opt => opt.MapFrom(src => src.FichaFotovoltaicos))
            .ForMember(dest => dest.FichaPiscinas, opt => opt.MapFrom(src => src.FichaPiscinas))
            .ForMember(dest => dest.IdClienteNavigation, opt => opt.MapFrom(src => src.IdClienteNavigation))
            .ForMember(dest => dest.IdGestorNavigation, opt => opt.MapFrom(src => src.IdGestorNavigation))
            .ForMember(dest => dest.IdTecnicoNavigation, opt => opt.MapFrom(src => src.IdTecnicoNavigation))
            .ReverseMap();
        CreateMap<Vistorium, VistoriaFichaDTO>()
                    .ReverseMap();

        CreateMap<Vistorium, GetVistoriaFichaDTO>()
            .ForMember(dest => dest.IdClienteNavigation, opt => opt.MapFrom(src => src.IdClienteNavigation))
            .ForMember(dest => dest.IdGestorNavigation, opt => opt.MapFrom(src => src.IdGestorNavigation))
            .ReverseMap();
        CreateMap<Gestor, GestorDTO>()
            .ForMember(dest => dest.IdUsuarioNavigation, opt => opt.MapFrom(src => src.IdUsuarioNavigation))
            .ReverseMap();
        CreateMap<Usuario, UsuarioDTO>()
            .ReverseMap();
    }
}
