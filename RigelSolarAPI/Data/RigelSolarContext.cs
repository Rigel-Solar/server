using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83FA5660525");

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
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83F27BBF75B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<CondicaoQuadroPrincipalEnergium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83F79C90502");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<CondicaoViga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicao__3213E83F18C94107");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<Coordenador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coordena__3213E83F995B54C0");

            entity.ToTable("Coordenador");

            entity.HasIndex(e => e.IdTecnico, "UQ__Coordena__295BEDE5D961F22F").IsUnique();

            entity.HasIndex(e => e.IdGestor, "UQ__Coordena__7AEBF3854EE170CD").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__FichaBan__3213E83F3455AD4A");

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
            entity.HasKey(e => e.Id).HasName("PK__FichaFot__3213E83F1707FE42");

            entity.ToTable("FichaFotovoltaico");

            entity.HasIndex(e => e.IdTipoLigacao, "UQ__FichaFot__101C83B65D127A29").IsUnique();

            entity.HasIndex(e => e.IdCondicaoQuadroPrincipalEnergia, "UQ__FichaFot__407847C5009B9147").IsUnique();

            entity.HasIndex(e => e.IdMaterialVigasTelhado, "UQ__FichaFot__4858726D35F19C01").IsUnique();

            entity.HasIndex(e => e.IdModeloRelogio, "UQ__FichaFot__4B6E5856A9316B8D").IsUnique();

            entity.HasIndex(e => e.IdCondicaoPadraoEntrada, "UQ__FichaFot__5F97740B92F34006").IsUnique();

            entity.HasIndex(e => e.IdNivelamentoSolo, "UQ__FichaFot__6E88DD6E05452843").IsUnique();

            entity.HasIndex(e => e.IdTipoSuperficie, "UQ__FichaFot__712490DB2859D93F").IsUnique();

            entity.HasIndex(e => e.IdIdadeTelhado, "UQ__FichaFot__7BE0E3D42742E999").IsUnique();

            entity.HasIndex(e => e.IdCondicaoVigas, "UQ__FichaFot__85EFE688C3AAC183").IsUnique();

            entity.HasIndex(e => e.IdTensaoNominal, "UQ__FichaFot__995C2CA5E37FDDC5").IsUnique();

            entity.HasIndex(e => e.IdTelhadoAcesso, "UQ__FichaFot__ADDAC398B08DA7FB").IsUnique();

            entity.HasIndex(e => e.IdLocalInstalacaoModulos, "UQ__FichaFot__CC32E0BA00C25C25").IsUnique();

            entity.HasIndex(e => e.IdTipoCliente, "UQ__FichaFot__FE7DCABDAD011593").IsUnique();

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
            entity.Property(e => e.IdVistoria).HasColumnName("idVistoria");
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

            entity.HasOne(d => d.IdVistoriaNavigation).WithMany(p => p.FichaFotovoltaicos)
                .HasForeignKey(d => d.IdVistoria)
                .HasConstraintName("FK__FichaFoto__idVis__3D2915A8");
        });

        modelBuilder.Entity<FichaPiscina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaPis__3213E83F9A974F46");

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
            entity.HasKey(e => e.Id).HasName("PK__Fotos__3213E83F3865D8CE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Foto1)
                .HasMaxLength(1)
                .HasColumnName("foto");
            entity.Property(e => e.IdFichaBanho).HasColumnName("idFichaBanho");
            entity.Property(e => e.IdFichaFotovoltaico).HasColumnName("idFichaFotovoltaico");
            entity.Property(e => e.IdFichaPiscina).HasColumnName("idFichaPiscina");

            entity.HasOne(d => d.IdFichaBanhoNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaBanho)
                .HasConstraintName("FK__Fotos__idFichaBa__40058253");

            entity.HasOne(d => d.IdFichaFotovoltaicoNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaFotovoltaico)
                .HasConstraintName("FK__Fotos__idFichaFo__41EDCAC5");

            entity.HasOne(d => d.IdFichaPiscinaNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdFichaPiscina)
                .HasConstraintName("FK__Fotos__idFichaPi__40F9A68C");
        });

        modelBuilder.Entity<Gestor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gestor__3213E83FFD72781E");

            entity.ToTable("Gestor");

            entity.HasIndex(e => e.IdUsuario, "UQ__Gestor__4E3E04AC0342D4F7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Gestor)
                .HasForeignKey<Gestor>(d => d.IdUsuario)
                .HasConstraintName("FK__Gestor__id_usuar__72C60C4A");
        });

        modelBuilder.Entity<IdadeTelhado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IdadeTel__3213E83F4E4B2F59");

            entity.ToTable("IdadeTelhado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idade).HasColumnName("idade");
        });

        modelBuilder.Entity<LocalInstalacaoModulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LocalIns__3213E83F636388E2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Local)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("local");
        });

        modelBuilder.Entity<MaterialVigasTelhado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3213E83FC6948E2F");

            entity.ToTable("MaterialVigasTelhado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Condicao)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("condicao");
        });

        modelBuilder.Entity<ModeloRelogio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ModeloRe__3213E83FBA88E228");

            entity.ToTable("ModeloRelogio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Modelo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("modelo");
        });

        modelBuilder.Entity<NivelamentoSolo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nivelame__3213E83F8D77591D");

            entity.ToTable("NivelamentoSolo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nivelamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nivelamento");
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tecnico__3213E83F9DDA108C");

            entity.ToTable("Tecnico");

            entity.HasIndex(e => e.IdUsuario, "UQ__Tecnico__645723A735442EB8").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__TelhadoA__3213E83F1077BDD0");

            entity.ToTable("TelhadoAcesso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acesso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("acesso");
        });

        modelBuilder.Entity<TensaoNominal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TensaoNo__3213E83FDB5F14E2");

            entity.ToTable("TensaoNominal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tensao)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("tensao");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoClie__3213E83FBA53F513");

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
            entity.HasKey(e => e.Id).HasName("PK__TipoLiga__3213E83FFC186E8F");

            entity.ToTable("TipoLigacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoSuperficie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoSupe__3213E83F57B91B1B");

            entity.ToTable("TipoSuperficie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FECB031DA");

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
            entity.HasKey(e => e.Id).HasName("PK__Vistoria__3213E83F89C25257");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentarios)
                .HasMaxLength(355)
                .IsUnicode(false)
                .HasColumnName("comentarios");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdGestor).HasColumnName("idGestor");
            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");
            entity.Property(e => e.PretendeInstalarEm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pretendeInstalarEm");
            entity.Property(e => e.Solucoes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("solucoes");
            entity.Property(e => e.TipoInstalacao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoInstalacao");
            entity.Property(e => e.ValorContaLuz)
                .HasColumnType("money")
                .HasColumnName("valorContaLuz");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Vistoria__idClie__02FC7413");

            entity.HasOne(d => d.IdGestorNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdGestor)
                .HasConstraintName("FK_Vistoria_Gestor");

            entity.HasOne(d => d.IdTecnicoNavigation).WithMany(p => p.Vistoria)
                .HasForeignKey(d => d.IdTecnico)
                .HasConstraintName("FK__Vistoria__idTecn__01142BA1");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
