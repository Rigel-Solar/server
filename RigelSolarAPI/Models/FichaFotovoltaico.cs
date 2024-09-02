namespace RigelSolarAPI.Models;

public partial class FichaFotovoltaico
{
    public int Id { get; set; }

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

    public int? IdTipoCliente { get; set; }

    public int? IdTipoLigacao { get; set; }

    public int? IdTensaoNominal { get; set; }

    public int? IdCondicaoPadraoEntrada { get; set; }

    public int? IdModeloRelogio { get; set; }

    public int? IdCondicaoQuadroPrincipalEnergia { get; set; }

    public int? IdLocalInstalacaoModulos { get; set; }

    public int? IdIdadeTelhado { get; set; }

    public int? IdMaterialVigasTelhado { get; set; }

    public int? IdCondicaoVigas { get; set; }

    public int? IdNivelamentoSolo { get; set; }

    public int? IdTelhadoAcesso { get; set; }

    public int? IdTipoSuperficie { get; set; }

    public virtual ICollection<Foto> Fotos { get; set; } = new List<Foto>();

    public virtual CondicaoPadraoEntradum? IdCondicaoPadraoEntradaNavigation { get; set; }

    public virtual CondicaoQuadroPrincipalEnergium? IdCondicaoQuadroPrincipalEnergiaNavigation { get; set; }

    public virtual CondicaoViga? IdCondicaoVigasNavigation { get; set; }

    public virtual IdadeTelhado? IdIdadeTelhadoNavigation { get; set; }

    public virtual LocalInstalacaoModulo? IdLocalInstalacaoModulosNavigation { get; set; }

    public virtual MaterialVigasTelhado? IdMaterialVigasTelhadoNavigation { get; set; }

    public virtual ModeloRelogio? IdModeloRelogioNavigation { get; set; }

    public virtual NivelamentoSolo? IdNivelamentoSoloNavigation { get; set; }

    public virtual TelhadoAcesso? IdTelhadoAcessoNavigation { get; set; }

    public virtual TensaoNominal? IdTensaoNominalNavigation { get; set; }

    public virtual TipoCliente? IdTipoClienteNavigation { get; set; }

    public virtual TipoLigacao? IdTipoLigacaoNavigation { get; set; }

    public virtual TipoSuperficie? IdTipoSuperficieNavigation { get; set; }
}
