namespace RigelSolarAPI.Dto;

public class FichaFotovoltaicoDTO
{
    public int QuantidadeSf { get; set; }

    public int PotenciaSf { get; set; }

    public decimal DimensoesSf { get; set; }

    public decimal AreaOcupacaoSf { get; set; }

    public string ModeloInversorSf { get; set; } = null!;

    public decimal QuantidadeInversorSf { get; set; }

    public string ConcessionariaEnergiaPe { get; set; } = null!;

    public decimal? DemandaContratadaPe { get; set; }

    public string DimensaoCaixaPadraoPe { get; set; } = null!;

    public bool AterramentoPe { get; set; }

    public string DisjuntorPadraoEntradaPe { get; set; } = null!;

    public int BitolaCondutorPe { get; set; }

    public int AntesDisjuntorPe { get; set; }

    public string DisjuntorQuadroPrincipalQpe { get; set; } = null!;

    public decimal DimensoesQpe { get; set; }

    public decimal AreaOcupacaoQpe { get; set; }

    public string ModeloInversorQpe { get; set; } = null!;

    public decimal QuantidadeInversorQpe { get; set; }

    public decimal LarguraDcp { get; set; }

    public decimal ComprimentoDcp { get; set; }

    public decimal ProfundidadeDcp { get; set; }

    public decimal LarguraSolo { get; set; }

    public decimal ComprimentoSolo { get; set; }

    public string TipoTelha { get; set; } = null!;

    public decimal DistanciaRipasTelhado { get; set; }

    public decimal DistanciaCaibrosTelhado { get; set; }

    public decimal DistanciaTercasTelhado { get; set; }

    public decimal DistanciaEmpenaTelhado { get; set; }

    public virtual CondicaoPadraoEntradaDTO? CondicaoPadraoEntradaDTO { get; set; }

    public virtual CondicaoQuadroPrincipalDTO? CondicaoQuadroPrincipalDTO { get; set; }

    public virtual CondicaoVigaDTO? CondicaoVigaDTO { get; set; }

    public virtual IdadeTelhadoDTO? IdadeTelhadoDTO { get; set; }

    public virtual LocalInstalacaoModuloDTO? LocalInstalacaoModuloDTO { get; set; }

    public virtual MaterialVigasTelhadoDTO? MaterialVigasTelhadoDTO { get; set; }

    public virtual ModeloRelogioDTO? ModeloRelogioDTO { get; set; }

    public virtual NivelamentoSoloDTO? NivelamentoSoloDTO { get; set; }

    public virtual TelhadoAcessoDTO? TelhadoAcessoDTO { get; set; }

    public virtual TensaoNominalDTO? TensaoNominalDTO { get; set; }

    public virtual TipoClienteDTO? TipoClienteDTO { get; set; }

    public virtual TipoLigacaoDTO? TipoLigacaoDTO { get; set; }

    public virtual TipoSuperficieDTO? TipoSuperficieDTO { get; set; }
}

public class GetFichaFotovoltaicoDTO : FichaFotovoltaicoDTO
{
    public int Id { get; set; }
}
