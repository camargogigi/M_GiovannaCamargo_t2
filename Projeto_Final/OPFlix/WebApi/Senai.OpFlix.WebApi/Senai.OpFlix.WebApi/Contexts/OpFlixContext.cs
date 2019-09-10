using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.Favoritos'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=M_OpFlix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B21C89233A")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Lancamen__7D8FE3B2CC629945")
                    .IsUnique();

                entity.Property(e => e.DataEstreia).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TempoDuracao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__5DCAEF64");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__Lancament__IdPla__5EBF139D");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Lancament__IdTip__5CD6CB2B");
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B2893B6302")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipos>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Tipos__7D8FE3B2D2502084")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdTipoUser);

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TiposUsu__8E762CB49921D03C")
                    .IsUnique();

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Usuarios__C1F8973149523B6C")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053439D0D5FA")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuarios__7D8FE3B2144B8B44")
                    .IsUnique();

                entity.HasIndex(e => e.Telefone)
                    .HasName("UQ__Usuarios__4EC504B64B9C7BA3")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUserNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUser)
                    .HasConstraintName("FK__Usuarios__IdTipo__59063A47");
            });
        }
    }
}
