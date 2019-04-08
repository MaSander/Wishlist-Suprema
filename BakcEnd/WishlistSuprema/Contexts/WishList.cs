using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WishlistSuprema.Domains
{
    public partial class WishList : DbContext
    {
        public WishList()
        {
        }

        public WishList(DbContextOptions<WishList> options)
            : base(options)
        {
        }

        public virtual DbSet<Desejos> Desejos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=WISHLIST_SUPREMA; user id=sa; pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desejos>(entity =>
            {
                entity.ToTable("DESEJOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataDoDesejo)
                    .HasColumnName("DATA_DO_DESEJO")
                    .HasColumnType("date");

                entity.Property(e => e.Desejo)
                    .IsRequired()
                    .HasColumnName("DESEJO")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF7243F63E960")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
