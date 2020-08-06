using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Models
{
    public partial class teste2Context : DbContext
    {
        public teste2Context()
        {
        }

        public teste2Context(DbContextOptions<teste2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiResourceClaims> ApiResourceClaims { get; set; }
        public virtual DbSet<ApiResourceProperties> ApiResourceProperties { get; set; }
        public virtual DbSet<ApiResourceScopes> ApiResourceScopes { get; set; }
        public virtual DbSet<ApiResourceSecrets> ApiResourceSecrets { get; set; }
        public virtual DbSet<ApiResources> ApiResources { get; set; }
        public virtual DbSet<ApiScopeClaims> ApiScopeClaims { get; set; }
        public virtual DbSet<ApiScopeProperties> ApiScopeProperties { get; set; }
        public virtual DbSet<ApiScopes> ApiScopes { get; set; }
        public virtual DbSet<ClientClaims> ClientClaims { get; set; }
        public virtual DbSet<ClientCorsOrigins> ClientCorsOrigins { get; set; }
        public virtual DbSet<ClientGrantTypes> ClientGrantTypes { get; set; }
        public virtual DbSet<ClientIdPrestrictions> ClientIdPrestrictions { get; set; }
        public virtual DbSet<ClientPostLogoutRedirectUris> ClientPostLogoutRedirectUris { get; set; }
        public virtual DbSet<ClientProperties> ClientProperties { get; set; }
        public virtual DbSet<ClientRedirectUris> ClientRedirectUris { get; set; }
        public virtual DbSet<ClientScopes> ClientScopes { get; set; }
        public virtual DbSet<ClientSecrets> ClientSecrets { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Enfermeiros> Enfermeiros { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<IdentityResourceClaims> IdentityResourceClaims { get; set; }
        public virtual DbSet<IdentityResourceProperties> IdentityResourceProperties { get; set; }
        public virtual DbSet<IdentityResources> IdentityResources { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Triagem> Triagem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=W107CLHD33;database=teste2;trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiResourceClaims>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceClaims)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceProperties>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceProperties)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceScopes>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceScopes)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceSecrets>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceSecrets)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResources>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.AllowedAccessTokenSigningAlgorithms).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ApiScopeClaims>(entity =>
            {
                entity.HasIndex(e => e.ScopeId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.ApiScopeClaims)
                    .HasForeignKey(d => d.ScopeId);
            });

            modelBuilder.Entity<ApiScopeProperties>(entity =>
            {
                entity.HasIndex(e => e.ScopeId);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.ApiScopeProperties)
                    .HasForeignKey(d => d.ScopeId);
            });

            modelBuilder.Entity<ApiScopes>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ClientClaims>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientClaims)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientCorsOrigins>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCorsOrigins)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientGrantTypes>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.GrantType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientGrantTypes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientIdPrestrictions>(entity =>
            {
                entity.ToTable("ClientIdPRestrictions");

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientIdPrestrictions)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUris>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.PostLogoutRedirectUri)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPostLogoutRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientProperties>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientProperties)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientRedirectUris>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.RedirectUri)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientScopes>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientScopes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientSecrets>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSecrets)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasIndex(e => e.ClientId)
                    .IsUnique();

                entity.Property(e => e.AllowedIdentityTokenSigningAlgorithms).HasMaxLength(100);

                entity.Property(e => e.BackChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.ClientClaimsPrefix).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.ClientUri).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.FrontChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.LogoUri).HasMaxLength(2000);

                entity.Property(e => e.PairWiseSubjectSalt).HasMaxLength(200);

                entity.Property(e => e.ProtocolType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserCodeType).HasMaxLength(100);
            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.HasKey(e => e.CodConsultas)
                    .HasName("PK__Consulta__AB89BEAB9C8D924A");

                entity.HasIndex(e => new { e.Cpf, e.DataConsulta, e.Crm, e.Coren, e.CodTriagem })
                    .HasName("ck_marcado")
                    .IsUnique();

                entity.Property(e => e.CodConsultas).HasColumnName("Cod_Consultas");

                entity.Property(e => e.CodTriagem).HasColumnName("Cod_Triagem");

                entity.Property(e => e.Coren).HasMaxLength(14);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(14);

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasColumnName("CRM")
                    .HasMaxLength(14);

                entity.Property(e => e.DataConsulta).HasColumnType("datetime");

                entity.HasOne(d => d.CodTriagemNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.CodTriagem)
                    .HasConstraintName("FK_TRIAGEM");

                entity.HasOne(d => d.CorenNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.Coren)
                    .HasConstraintName("FK_ENFERMEIROS");

                entity.HasOne(d => d.CpfNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PACIENTES");

                entity.HasOne(d => d.CrmNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.Crm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS");
            });

            modelBuilder.Entity<Enfermeiros>(entity =>
            {
                entity.HasKey(e => e.Coren)
                    .HasName("PK__Enfermei__F7D2C3E900302901");

                entity.Property(e => e.Coren)
                    .HasColumnName("COREN")
                    .HasMaxLength(14);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CorenNavigation)
                    .WithOne(p => p.Enfermeiros)
                    .HasPrincipalKey<Clients>(p => p.ClientId)
                    .HasForeignKey<Enfermeiros>(d => d.Coren)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT_ENF");
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.HasKey(e => e.CodEspecialidade)
                    .HasName("PK__Especial__0EB6E855DC11B979");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Especial__7D8FE3B2B6C004F5")
                    .IsUnique();

                entity.Property(e => e.CodEspecialidade).HasColumnName("Cod_especialidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ValorConsulta).HasColumnType("numeric(4, 0)");
            });

            modelBuilder.Entity<IdentityResourceClaims>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityResourceClaims)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResourceProperties>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityResourceProperties)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResources>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.HasKey(e => e.Crm)
                    .HasName("PK__Medicos__C1F887FE97C75860");

                entity.Property(e => e.Crm)
                    .HasColumnName("CRM")
                    .HasMaxLength(14);

                entity.Property(e => e.CodEspecialidade).HasColumnName("Cod_especialidade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.CodEspecialidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESPECIALIDADES");

                entity.HasOne(d => d.CrmNavigation)
                    .WithOne(p => p.Medicos)
                    .HasPrincipalKey<Clients>(p => p.ClientId)
                    .HasForeignKey<Medicos>(d => d.Crm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Paciente__C1F89730BEE8B7D9");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(14);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("SEXO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CpfNavigation)
                    .WithOne(p => p.Pacientes)
                    .HasPrincipalKey<Clients>(p => p.ClientId)
                    .HasForeignKey<Pacientes>(d => d.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT_PAC");
            });

            modelBuilder.Entity<Triagem>(entity =>
            {
                entity.HasKey(e => e.CodTriagem)
                    .HasName("PK__Triagem__49128E564FC01A20");

                entity.Property(e => e.CodTriagem).HasColumnName("Cod_triagem");

                entity.Property(e => e.Coren)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(14);

                entity.Property(e => e.DataConsulta).HasColumnType("datetime");

                entity.Property(e => e.DescricaoPaciente).HasMaxLength(50);

                entity.Property(e => e.Prioridade)
                    .HasColumnName("prioridade")
                    .HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.CorenNavigation)
                    .WithMany(p => p.Triagem)
                    .HasForeignKey(d => d.Coren)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COREN");

                entity.HasOne(d => d.CpfNavigation)
                    .WithMany(p => p.Triagem)
                    .HasForeignKey(d => d.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
