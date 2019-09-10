using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class EkipsContext : DbContext
    {
        public EkipsContext()
        {
        }

        public EkipsContext(DbContextOptions<EkipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<StatusCargo> StatusCargo { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=M_Ekips;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Cargos__7D8FE3B206F8725D")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__Cargos__IdStatus__4F7CD00D");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Departam__7D8FE3B238DA0E7F")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Funciona__C1FF9309CE9C659C")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Funciona__7D8FE3B2D369EE63")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK__Funcionar__IdCar__5EBF139D");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Funcionar__IdDep__5DCAEF64");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Funcionar__IdUsu__5FB337D6");
            });

            modelBuilder.Entity<StatusCargo>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105342D986C37")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Permissão)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
