using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Data;

public partial class RigelSolarContext : DbContext
{
    public RigelSolarContext()
    {
    }

    public RigelSolarContext(DbContextOptions<RigelSolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CondicaoPadraoEntradum> CondicaoPadraoEntrada { get; set; }

    public virtual DbSet<CondicaoQuadroPrincipalEnergium> CondicaoQuadroPrincipalEnergia { get; set; }

    public virtual DbSet<CondicaoViga> CondicaoVigas { get; set; }

    public virtual DbSet<Coordenador> Coordenadors { get; set; }

    public virtual DbSet<FichaBanho> FichaBanhos { get; set; }

    public virtual DbSet<FichaFotovoltaico> FichaFotovoltaicos { get; set; }

    public virtual DbSet<FichaPiscina> FichaPiscinas { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    public virtual DbSet<IdadeTelhado> IdadeTelhados { get; set; }

    public virtual DbSet<LocalInstalacaoModulo> LocalInstalacaoModulos { get; set; }

    public virtual DbSet<MaterialVigasTelhado> MaterialVigasTelhados { get; set; }

    public virtual DbSet<ModeloRelogio> ModeloRelogios { get; set; }

    public virtual DbSet<NivelamentoSolo> NivelamentoSolos { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    public virtual DbSet<TelhadoAcesso> TelhadoAcessos { get; set; }

    public virtual DbSet<TensaoNominal> TensaoNominals { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoLigacao> TipoLigacaos { get; set; }

    public virtual DbSet<TipoSuperficie> TipoSuperficies { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vistorium> Vistoria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ESS000N1530610\\SQLEXPRESS;Database=RigelSolar;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83FDFFFF775");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("longitude");
            entity.Property(e => e.Tipo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<CondicaoPadraoEntradum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83F24FC832C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<CondicaoQuadroPrincipalEnergium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83F61E31EBE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<CondicaoViga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83FD4A668CD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<Coordenador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coordena__3213E83F664AE92A");

            entity.ToTable("Coordenador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

            entity.HasOne(d => d.IdTecnicoNavigation).WithMany(p => p.Coordenadors)
                .HasForeignKey(d => d.IdTecnico)
                .HasConstraintName("FK__Coordenad__idTec__74AE54BC");
        });

        modelBuilder.Entity<FichaBanho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaBan__3213E83F03860617");

            entity.ToTable("FichaBanho");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaseBoiler)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("baseBoiler");
            entity.Property(e => e.BaseCaixa)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("baseCaixa");
            entity.Property(e => e.DisjuntorBipolar).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DistanciaBoiler)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("distanciaBoiler");
            entity.Property(e => e.IdVistoria).HasColumnName("idVistoria");
            entity.Property(e => e.RegistroBarrilete)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("registroBarrilete");
            entity.Property(e => e.RegistroCaixa)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("registroCaixa");

            entity.HasOne(d => d.IdVistoriaNavigation).WithMany(p => p.FichaBanhos)
                .HasForeignKey(d => d.IdVistoria)
                .HasConstraintName("FK__FichaBanh__idVis__7E37BEF6");
        });

        modelBuilder.Entity<FichaFotovoltaico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaFot__3213E83F983FCCA5");

            entity.ToTable("FichaFotovoltaico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AntesDisjuntorPe).HasColumnName("antesDisjuntorPE");
            entity.Property(e => e.AreaOcupacaoQpe)
                .HasColumnType("decimal(8, 6)")
                .HasColumnName("areaOcupacaoQPE");
            entity.Property(e => e.AreaOcupacaoSf)
                .HasColumnType("decimal(8, 6)")
                .HasColumnName("areaOcupacaoSF");
            entity.Property(e => e.AterramentoPe).HasColumnName("aterramentoPE");
            entity.Property(e => e.BitolaCondutorPe).HasColumnName("bitolaCondutorPE");
            entity.Property(e => e.ComprimentoDcp)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("comprimentoDCP");
            entity.Property(e => e.ComprimentoSolo)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("comprimentoSolo");
            entity.Property(e => e.ConcessionariaEnergiaPe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("concessionariaEnergiaPE");
            entity.Property(e => e.DemandaContratadaPe)
                .HasColumnType("decimal(8, 6)")
                .HasColumnName("demandaContratadaPE");
            entity.Property(e => e.DimensaoCaixaPadraoPe)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("dimensaoCaixaPadraoPE");
            entity.Property(e => e.DimensoesQpe)
                .HasColumnType("decimal(8, 6)")
                .HasColumnName("dimensoesQPE");
            entity.Property(e => e.DimensoesSf)
                .HasColumnType("decimal(8, 6)")
                .HasColumnName("dimensoesSF");
            entity.Property(e => e.DisjuntorPadraoEntradaPe)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("disjuntorPadraoEntradaPE");
            entity.Property(e => e.DisjuntorQuadroPrincipalQpe)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("disjuntorQuadroPrincipalQPE");
            entity.Property(e => e.DistanciaCaibrosTelhado)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("distanciaCaibrosTelhado");
            entity.Property(e => e.DistanciaEmpenaTelhado)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("distanciaEmpenaTelhado");
            entity.Property(e => e.DistanciaRipasTelhado)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("distanciaRipasTelhado");
            entity.Property(e => e.DistanciaTercasTelhado)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("distanciaTercasTelhado");
            entity.Property(e => e.IdCondicaoPadraoEntrada).HasColumnName("idCondicaoPadraoEntrada");
            entity.Property(e => e.IdCondicaoQuadroPrincipalEnergia).HasColumnName("idCondicaoQuadroPrincipalEnergia");
            entity.Property(e => e.IdCondicaoVigas).HasColumnName("idCondicaoVigas");
            entity.Property(e => e.IdIdadeTelhado).HasColumnName("idIdadeTelhado");
            entity.Property(e => e.IdLocalInstalacaoModulos).HasColumnName("idLocalInstalacaoModulos");
            entity.Property(e => e.IdMaterialVigasTelhado).HasColumnName("idMaterialVigasTelhado");
            entity.Property(e => e.IdModeloRelogio).HasColumnName("idModeloRelogio");
            entity.Property(e => e.IdNivelamentoSolo).HasColumnName("idNivelamentoSolo");
            entity.Property(e => e.IdTelhadoAcesso).HasColumnName("idTelhadoAcesso");
            entity.Property(e => e.IdTensaoNominal).HasColumnName("idTensaoNominal");
            entity.Property(e => e.IdTipoCliente).HasColumnName("idTipoCliente");
            entity.Property(e => e.IdTipoLigacao).HasColumnName("idTipoLigacao");
            entity.Property(e => e.IdTipoSuperficie).HasColumnName("idTipoSuperficie");
            entity.Property(e => e.LarguraDcp)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("larguraDCP");
            entity.Property(e => e.LarguraSolo)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("larguraSolo");
            entity.Property(e => e.ModeloInversorQpe)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modeloInversorQPE");
            entity.Property(e => e.ModeloInversorSf)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modeloInversorSF");
            entity.Property(e => e.PotenciaSf).HasColumnName("potenciaSF");
            entity.Property(e => e.ProfundidadeDcp)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("profundidadeDCP");
            entity.Property(e => e.QuantidadeInversorQpe)
                .HasColumnType("decimal(8, 6)")
                .HasColumnName("quantidadeInversorQPE");
            entity.Property(e => e.QuantidadeInversorSf)
                .HasColumnType("decimal(8, 6)")
                .HasColumnName("quantidadeInversorSF");
            entity.Property(e => e.QuantidadeSf).HasColumnName("quantidadeSF");
            entity.Property(e => e.TipoTelha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoTelha");

            entity.HasOne(d => d.IdCondicaoPadraoEntradaNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdCondicaoPadraoEntrada)
                .HasConstraintName("FK__FichaFoto__idCon__1F98B2C1");

            entity.HasOne(d => d.IdCondicaoQuadroPrincipalEnergiaNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdCondicaoQuadroPrincipalEnergia)
                .HasConstraintName("FK__FichaFoto__idCon__2180FB33");

            entity.HasOne(d => d.IdCondicaoVigasNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdCondicaoVigas)
                .HasConstraintName("FK__FichaFoto__idCon__25518C17");

            entity.HasOne(d => d.IdIdadeTelhadoNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdIdadeTelhado)
                .HasConstraintName("FK__FichaFoto__idIda__236943A5");

            entity.HasOne(d => d.IdLocalInstalacaoModulosNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdLocalInstalacaoModulos)
                .HasConstraintName("FK__FichaFoto__idLoc__22751F6C");

            entity.HasOne(d => d.IdMaterialVigasTelhadoNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdMaterialVigasTelhado)
                .HasConstraintName("FK__FichaFoto__idMat__245D67DE");

            entity.HasOne(d => d.IdModeloRelogioNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdModeloRelogio)
                .HasConstraintName("FK__FichaFoto__idMod__208CD6FA");

            entity.HasOne(d => d.IdNivelamentoSoloNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdNivelamentoSolo)
                .HasConstraintName("FK__FichaFoto__idNiv__2645B050");

            entity.HasOne(d => d.IdTelhadoAcessoNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdTelhadoAcesso)
                .HasConstraintName("FK__FichaFoto__idTel__2739D489");

            entity.HasOne(d => d.IdTensaoNominalNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdTensaoNominal)
                .HasConstraintName("FK__FichaFoto__idTen__1EA48E88");

            entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdTipoCliente)
                .HasConstraintName("FK__FichaFoto__idTip__1CBC4616");

            entity.HasOne(d => d.IdTipoLigacaoNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdTipoLigacao)
                .HasConstraintName("FK__FichaFoto__idTip__1DB06A4F");

            entity.HasOne(d => d.IdTipoSuperficieNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdTipoSuperficie)
                .HasConstraintName("FK__FichaFoto__idTip__282DF8C2");
        });

        modelBuilder.Entity<FichaPiscina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaPis__3213E83F63B9A1DB");

            entity.ToTable("FichaPiscina");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ambiente)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ambiente");
            entity.Property(e => e.Comprimento)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("comprimento");
            entity.Property(e => e.IdVistoria).HasColumnName("idVistoria");
            entity.Property(e => e.Largura)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("largura");
            entity.Property(e => e.Profundidade)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("profundidade");
            entity.Property(e => e.Regiao)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("regiao");
            entity.Property(e => e.TemperaturaAgua)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperaturaAgua");
            entity.Property(e => e.UsoCapaTermica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usoCapaTermica");

            entity.HasOne(d => d.IdVistoriaNavigation).WithMany(p => p.FichaPiscinas)
                .HasForeignKey(d => d.IdVistoria)
                .HasConstraintName("FK__FichaPisc__idVis__01142BA1");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fotos__3213E83FC86C707D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Foto1)
                .HasMaxLength(1)
                .HasColumnName("foto");
            entity.Property(e => e.IdFichaBanho).HasColumnName("idFichaBanho");
            entity.Property(e => e.IdFichaFotovoltaico).HasColumnName("idFichaFotovoltaico");
            entity.Property(e => e.IdFichaPiscina).HasColumnName("idFichaPiscina");
            entity.Property(e => e.TipoFoto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoFoto");

            entity.HasOne(d => d.IdFichaBanhoNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaBanho)
                .HasConstraintName("FK__Fotos__idFichaBa__2B0A656D");

            entity.HasOne(d => d.IdFichaFotovoltaicoNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaFotovoltaico)
                .HasConstraintName("FK__Fotos__idFichaFo__2CF2ADDF");

            entity.HasOne(d => d.IdFichaPiscinaNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaPiscina)
                .HasConstraintName("FK__Fotos__idFichaPi__2BFE89A6");
        });

        modelBuilder.Entity<IdadeTelhado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IdadeTel__3213E83F7E878BDF");

            entity.ToTable("IdadeTelhado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idade).HasColumnName("idade");
        });

        modelBuilder.Entity<LocalInstalacaoModulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LocalIns__3213E83F7B1BF292");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Local)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("local");
        });

        modelBuilder.Entity<MaterialVigasTelhado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3213E83FF8506271");

            entity.ToTable("MaterialVigasTelhado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<ModeloRelogio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ModeloRe__3213E83FC6952029");

            entity.ToTable("ModeloRelogio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Modelo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("modelo");
        });

        modelBuilder.Entity<NivelamentoSolo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nivelame__3213E83F5D07DBE3");

            entity.ToTable("NivelamentoSolo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nivelamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nivelamento");
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tecnico__3213E83F858F6642");

            entity.ToTable("Tecnico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Crea)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("crea");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tecnicos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Tecnico__idUsuar__71D1E811");
        });

        modelBuilder.Entity<TelhadoAcesso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TelhadoA__3213E83FBEBBB0C1");

            entity.ToTable("TelhadoAcesso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acesso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("acesso");
        });

        modelBuilder.Entity<TensaoNominal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TensaoNo__3213E83F5290E88F");

            entity.ToTable("TensaoNominal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tensao)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("tensao");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoClie__3213E83FF5A18E98");

            entity.ToTable("TipoCliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoLigacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoLiga__3213E83F2E1E3CE1");

            entity.ToTable("TipoLigacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoSuperficie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoSupe__3213E83FB8BD693D");

            entity.ToTable("TipoSuperficie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F964F4FD6");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("senha");
        });

        modelBuilder.Entity<Vistorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vistoria__3213E83F7E1BF22C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdCoordenador).HasColumnName("idCoordenador");
            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Vistoria__idClie__7B5B524B");

            entity.HasOne(d => d.IdCoordenadorNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdCoordenador)
                .HasConstraintName("FK__Vistoria__idCoor__7A672E12");

            entity.HasOne(d => d.IdTecnicoNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdTecnico)
                .HasConstraintName("FK__Vistoria__idTecn__797309D9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
