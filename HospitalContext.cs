using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Enfermeiro> Enfermeiros { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Triagem> Triagems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=ANDROMEDA;database=Hospital;trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(x => x.CodConsultas)
                    .HasName("PK__Consulta__AB89BEABACBE42B6");

                entity.HasIndex(x => new { x.Cpf, x.DataConsulta, x.Crm, x.Coren, x.CodTriagem }, "ck_marcado")
                    .IsUnique();

                entity.Property(e => e.CodConsultas).HasColumnName("Cod_Consultas");

                entity.Property(e => e.CodTriagem).HasColumnName("Cod_Triagem");

                entity.Property(e => e.Coren)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CRM");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.CodTriagemNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(x => x.CodTriagem)
                    .HasConstraintName("FK_TRIAGEM");

                entity.HasOne(d => d.CorenNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(x => x.Coren)
                    .HasConstraintName("FK_ENFERMEIROS");

                entity.HasOne(d => d.CpfNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(x => x.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PACIENTES");

                entity.HasOne(d => d.CrmNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(x => x.Crm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS");
            });

            modelBuilder.Entity<Enfermeiro>(entity =>
            {
                entity.HasKey(x => x.Coren)
                    .HasName("PK__Enfermei__F7D2C3E9B6302E3E");

                entity.Property(e => e.Coren)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("COREN");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(x => x.CodEspecialidade)
                    .HasName("PK__Especial__0EB6E8550E3A0195");

                entity.HasIndex(x => x.Nome, "UQ__Especial__7D8FE3B290CED59A")
                    .IsUnique();

                entity.Property(e => e.CodEspecialidade).HasColumnName("Cod_especialidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValorConsulta)
                    .HasColumnType("numeric(4, 0)")
                    .HasAnnotation("Relational:ColumnType", "numeric(4, 0)");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(x => x.Crm)
                    .HasName("PK__Medicos__C1F887FE228C3411");

                entity.Property(e => e.Crm)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CRM");

                entity.Property(e => e.CodEspecialidade).HasColumnName("Cod_especialidade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.HasOne(d => d.CodEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(x => x.CodEspecialidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESPECIALIDADES");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(x => x.Cpf)
                    .HasName("PK__Paciente__C1F89730E0FBE276");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEXO")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Triagem>(entity =>
            {
                entity.HasKey(x => x.CodTriagem)
                    .HasName("PK__Triagem__49128E56500FEABD");

                entity.ToTable("Triagem");

                entity.Property(e => e.CodTriagem).HasColumnName("Cod_triagem");

                entity.Property(e => e.Coren)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DescricaoPaciente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prioridade)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("prioridade")
                    .HasAnnotation("Relational:ColumnType", "numeric(1, 0)");

                entity.HasOne(d => d.CorenNavigation)
                    .WithMany(p => p.Triagems)
                    .HasForeignKey(x => x.Coren)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COREN");

                entity.HasOne(d => d.CpfNavigation)
                    .WithMany(p => p.Triagems)
                    .HasForeignKey(x => x.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
