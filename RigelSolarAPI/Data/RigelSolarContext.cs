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

    public virtual DbSet<Gestor> Gestors { get; set; }

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
        => optionsBuilder.UseSqlServer("server=ESS000N1530610\\SQLEXPRESS;Database=RigelSolar;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83F5BE756B1");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
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
            entity.Property(e => e.Nome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Tipo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<CondicaoPadraoEntradum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83F0E21FA0B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<CondicaoQuadroPrincipalDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83FF193FD67");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<CondicaoViga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83F0B299501");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<Coordenador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coordena__3213E83F75626626");

            entity.ToTable("Coordenador");

            entity.HasIndex(e => e.IdTecnico, "UQ__Coordena__295BEDE5FA7AC39B").IsUnique();

            entity.HasIndex(e => e.IdGestor, "UQ__Coordena__7AEBF385E1457251").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdGestor).HasColumnName("idGestor");
            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

            entity.HasOne(d => d.IdGestorNavigation).WithOne(p => p.Coordenador)
                .HasForeignKey<Coordenador>(d => d.IdGestor)
                .HasConstraintName("FK__Coordenad__idGes__7C4F7684");

            entity.HasOne(d => d.IdTecnicoNavigation).WithOne(p => p.Coordenador)
                .HasForeignKey<Coordenador>(d => d.IdTecnico)
                .HasConstraintName("FK__Coordenad__idTec__7B5B524B");
        });

        modelBuilder.Entity<FichaBanho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaBan__3213E83F444E4840");

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
                .HasConstraintName("FK__FichaBanh__idVis__05D8E0BE");
        });

        modelBuilder.Entity<FichaFotovoltaico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaFot__3213E83FE7C68390");

            entity.ToTable("FichaFotovoltaico");

            entity.HasIndex(e => e.IdTipoLigacao, "UQ__FichaFot__101C83B6A60A4BC9").IsUnique();

            entity.HasIndex(e => e.IdCondicaoQuadroPrincipalEnergia, "UQ__FichaFot__407847C58367C23D").IsUnique();

            entity.HasIndex(e => e.IdMaterialVigasTelhado, "UQ__FichaFot__4858726D9DDFDFBD").IsUnique();

            entity.HasIndex(e => e.IdModeloRelogio, "UQ__FichaFot__4B6E58560E34F3E6").IsUnique();

            entity.HasIndex(e => e.IdCondicaoPadraoEntrada, "UQ__FichaFot__5F97740B7D23F7E3").IsUnique();

            entity.HasIndex(e => e.IdNivelamentoSolo, "UQ__FichaFot__6E88DD6E2AC4227D").IsUnique();

            entity.HasIndex(e => e.IdTipoSuperficie, "UQ__FichaFot__712490DBF77C5429").IsUnique();

            entity.HasIndex(e => e.IdIdadeTelhado, "UQ__FichaFot__7BE0E3D4DFA78F7B").IsUnique();

            entity.HasIndex(e => e.IdCondicaoVigas, "UQ__FichaFot__85EFE688A5471CDD").IsUnique();

            entity.HasIndex(e => e.IdTensaoNominal, "UQ__FichaFot__995C2CA5725A2F95").IsUnique();

            entity.HasIndex(e => e.IdTelhadoAcesso, "UQ__FichaFot__ADDAC39850DA0B7F").IsUnique();

            entity.HasIndex(e => e.IdLocalInstalacaoModulos, "UQ__FichaFot__CC32E0BA7C21288E").IsUnique();

            entity.HasIndex(e => e.IdTipoCliente, "UQ__FichaFot__FE7DCABD3A56FD13").IsUnique();

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

            entity.HasOne(d => d.IdCondicaoPadraoEntradaNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdCondicaoPadraoEntrada)
                .HasConstraintName("FK__FichaFoto__idCon__339FAB6E");

            entity.HasOne(d => d.IdCondicaoQuadroPrincipalEnergiaNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdCondicaoQuadroPrincipalEnergia)
                .HasConstraintName("FK__FichaFoto__idCon__3587F3E0");

            entity.HasOne(d => d.IdCondicaoVigasNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdCondicaoVigas)
                .HasConstraintName("FK__FichaFoto__idCon__395884C4");

            entity.HasOne(d => d.IdIdadeTelhadoNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdIdadeTelhado)
                .HasConstraintName("FK__FichaFoto__idIda__37703C52");

            entity.HasOne(d => d.IdLocalInstalacaoModulosNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdLocalInstalacaoModulos)
                .HasConstraintName("FK__FichaFoto__idLoc__367C1819");

            entity.HasOne(d => d.IdMaterialVigasTelhadoNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdMaterialVigasTelhado)
                .HasConstraintName("FK__FichaFoto__idMat__3864608B");

            entity.HasOne(d => d.IdModeloRelogioNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdModeloRelogio)
                .HasConstraintName("FK__FichaFoto__idMod__3493CFA7");

            entity.HasOne(d => d.IdNivelamentoSoloNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdNivelamentoSolo)
                .HasConstraintName("FK__FichaFoto__idNiv__3A4CA8FD");

            entity.HasOne(d => d.IdTelhadoAcessoNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdTelhadoAcesso)
                .HasConstraintName("FK__FichaFoto__idTel__3B40CD36");

            entity.HasOne(d => d.IdTensaoNominalNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdTensaoNominal)
                .HasConstraintName("FK__FichaFoto__idTen__32AB8735");

            entity.HasOne(d => d.IdTipoClienteNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdTipoCliente)
                .HasConstraintName("FK__FichaFoto__idTip__30C33EC3");

            entity.HasOne(d => d.IdTipoLigacaoNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdTipoLigacao)
                .HasConstraintName("FK__FichaFoto__idTip__31B762FC");

            entity.HasOne(d => d.IdTipoSuperficieNavigation).WithOne(p => p.FichaFotovoltaico)
                .HasForeignKey<FichaFotovoltaico>(d => d.IdTipoSuperficie)
                .HasConstraintName("FK__FichaFoto__idTip__3C34F16F");
        });

        modelBuilder.Entity<FichaPiscina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaPis__3213E83FD9B9BB4D");

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
                .HasConstraintName("FK__FichaPisc__idVis__08B54D69");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fotos__3213E83FFFAFB0A1");

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
                .HasConstraintName("FK__Fotos__idFichaBa__3F115E1A");

            entity.HasOne(d => d.IdFichaFotovoltaicoNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaFotovoltaico)
                .HasConstraintName("FK__Fotos__idFichaFo__40F9A68C");

            entity.HasOne(d => d.IdFichaPiscinaNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaPiscina)
                .HasConstraintName("FK__Fotos__idFichaPi__40058253");
        });

        modelBuilder.Entity<Gestor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gestor__3213E83FE32608F6");

            entity.ToTable("Gestor");

            entity.HasIndex(e => e.IdUsuario, "UQ__Gestor__4E3E04ACA3DBC50E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Gestor)
                .HasForeignKey<Gestor>(d => d.IdUsuario)
                .HasConstraintName("FK__Gestor__id_usuar__72C60C4A");
        });

        modelBuilder.Entity<IdadeTelhado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IdadeTel__3213E83FE3359C05");

            entity.ToTable("IdadeTelhado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idade).HasColumnName("idade");
        });

        modelBuilder.Entity<LocalInstalacaoModulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LocalIns__3213E83F03560041");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Local)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("local");
        });

        modelBuilder.Entity<MaterialVigasTelhado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3213E83F829ED1C6");

            entity.ToTable("MaterialVigasTelhado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<ModeloRelogio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ModeloRe__3213E83F78B4737B");

            entity.ToTable("ModeloRelogio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Modelo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("modelo");
        });

        modelBuilder.Entity<NivelamentoSolo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nivelame__3213E83FAEF69974");

            entity.ToTable("NivelamentoSolo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nivelamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nivelamento");
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tecnico__3213E83F8FB0857B");

            entity.ToTable("Tecnico");

            entity.HasIndex(e => e.IdUsuario, "UQ__Tecnico__645723A788CFAD0F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Crea)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("crea");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Tecnico)
                .HasForeignKey<Tecnico>(d => d.IdUsuario)
                .HasConstraintName("FK__Tecnico__idUsuar__76969D2E");
        });

        modelBuilder.Entity<TelhadoAcesso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TelhadoA__3213E83FAD39676A");

            entity.ToTable("TelhadoAcesso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acesso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("acesso");
        });

        modelBuilder.Entity<TensaoNominal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TensaoNo__3213E83F732460CC");

            entity.ToTable("TensaoNominal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tensao)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("tensao");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoClie__3213E83FEFDBF5CD");

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
            entity.HasKey(e => e.Id).HasName("PK__TipoLiga__3213E83FE5301A48");

            entity.ToTable("TipoLigacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoSuperficie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoSupe__3213E83FD88CF636");

            entity.ToTable("TipoSuperficie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FE140C7A4");

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
            entity.HasKey(e => e.Id).HasName("PK__Vistoria__3213E83F762B9C11");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdCoordenador).HasColumnName("idCoordenador");
            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Vistoria__idClie__02FC7413");

            entity.HasOne(d => d.IdCoordenadorNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdCoordenador)
                .HasConstraintName("FK__Vistoria__idCoor__02084FDA");

            entity.HasOne(d => d.IdTecnicoNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdTecnico)
                .HasConstraintName("FK__Vistoria__idTecn__01142BA1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
