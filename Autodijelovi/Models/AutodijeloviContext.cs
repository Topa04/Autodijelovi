using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class AutodijeloviContext : DbContext
    {
        public AutodijeloviContext()
        {
        }

        public AutodijeloviContext(DbContextOptions<AutodijeloviContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dijelovi> Dijelovis { get; set; }
        public virtual DbSet<Kupac> Kupacs { get; set; }
        public virtual DbSet<Modeli> Modelis { get; set; }
        public virtual DbSet<ModeliRadnja> ModeliRadnjas { get; set; }
        public virtual DbSet<Narudzba> Narudzbas { get; set; }
        public virtual DbSet<Proba> Probas { get; set; }
        public virtual DbSet<Proba2> Proba2s { get; set; }
        public virtual DbSet<Proba3> Proba3s { get; set; }
        public virtual DbSet<Radnja> Radnjas { get; set; }
        public virtual DbSet<StavkaNarudzbe> StavkaNarudzbes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Autodijelovi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dijelovi>(entity =>
            {
                entity.HasKey(e => e.IdDijela)
                    .HasName("PK__Dijelovi__CEA2816C168CA565");

                entity.ToTable("Dijelovi");

                entity.Property(e => e.IdDijela).HasColumnName("ID_dijela");

                entity.Property(e => e.Cijena)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Proizvodac).HasMaxLength(20);

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.HasKey(e => e.IdKupca)
                    .HasName("PK__Kupac__9AE721DC763A047F");

                entity.ToTable("Kupac");

                entity.Property(e => e.IdKupca).HasColumnName("ID_kupca");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.BrojKartice)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("Broj_kartice");

                entity.Property(e => e.Grad)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Kontakt)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Modeli>(entity =>
            {
                entity.HasKey(e => e.IdModela)
                    .HasName("PK__Modeli__4C8E0FF148E6F323");

                entity.ToTable("Modeli");

                entity.Property(e => e.IdModela).HasColumnName("ID_modela");

                entity.Property(e => e.GodinaProizvodnje)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("Godina_proizvodnje");

                entity.Property(e => e.Gorivo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Kubikaža)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NazivModela)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Naziv_modela");

                entity.Property(e => e.Pogon)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SnagaMotora)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("Snaga_motora");
            });

            modelBuilder.Entity<ModeliRadnja>(entity =>
            {
                entity.HasKey(e => e.IdVeze)
                    .HasName("PK__Modeli_R__D3571B4929B2A68E");

                entity.ToTable("Modeli_Radnja");

                entity.Property(e => e.IdVeze).HasColumnName("ID_veze");

                entity.Property(e => e.IdDijela).HasColumnName("ID_dijela");

                entity.Property(e => e.IdModela).HasColumnName("ID_modela");

                entity.Property(e => e.IdRadnje).HasColumnName("ID_radnje");

                entity.HasOne(d => d.IdDijelaNavigation)
                    .WithMany(p => p.ModeliRadnjas)
                    .HasForeignKey(d => d.IdDijela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Modeli_Ra__ID_di__2C3393D0");

                entity.HasOne(d => d.IdModelaNavigation)
                    .WithMany(p => p.ModeliRadnjas)
                    .HasForeignKey(d => d.IdModela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Modeli_Ra__ID_mo__2B3F6F97");

                entity.HasOne(d => d.IdRadnjeNavigation)
                    .WithMany(p => p.ModeliRadnjas)
                    .HasForeignKey(d => d.IdRadnje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Modeli_Ra__ID_ra__2A4B4B5E");
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.HasKey(e => e.IdNarudzbe)
                    .HasName("PK__Narudzba__64C9AA72ED50C50C");

                entity.ToTable("Narudzba");

                entity.Property(e => e.IdNarudzbe).HasColumnName("ID_narudzbe");

                entity.Property(e => e.DatumNarudzbe)
                    .HasColumnType("date")
                    .HasColumnName("Datum_narudzbe");

                entity.Property(e => e.IdKupca).HasColumnName("ID_kupca");

                entity.HasOne(d => d.IdKupcaNavigation)
                    .WithMany(p => p.Narudzbas)
                    .HasForeignKey(d => d.IdKupca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Narudzba__ID_kup__30F848ED");
            });

            modelBuilder.Entity<Proba>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Proba");

                entity.Property(e => e.NazivModela)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Naziv_modela");

                entity.Property(e => e.NazivRadnje)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Naziv_radnje");
            });

            modelBuilder.Entity<Proba2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Proba2");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NazivModela)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Naziv_modela");

                entity.Property(e => e.NazivRadnje)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Naziv_radnje");
            });

            modelBuilder.Entity<Proba3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Proba3");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NazivModela)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Naziv_modela");

                entity.Property(e => e.NazivRadnje)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Naziv_radnje");
            });

            modelBuilder.Entity<Radnja>(entity =>
            {
                entity.HasKey(e => e.IdRadnje)
                    .HasName("PK__Radnja__6F06F10EE618C451");

                entity.ToTable("Radnja");

                entity.Property(e => e.IdRadnje).HasColumnName("ID_radnje");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("E-mail");

                entity.Property(e => e.Grad)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.KontaktTel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Kontakt_tel");

                entity.Property(e => e.NazivRadnje)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Naziv_radnje");
            });

            modelBuilder.Entity<StavkaNarudzbe>(entity =>
            {
                entity.HasKey(e => e.IdStavke)
                    .HasName("PK__Stavka_n__451FABEAF837C3EE");

                entity.ToTable("Stavka_narudzbe");

                entity.Property(e => e.IdStavke).HasColumnName("ID_stavke");

                entity.Property(e => e.Cijena).HasColumnType("money");

                entity.Property(e => e.IdDijela).HasColumnName("ID_dijela");

                entity.Property(e => e.IdNarudzbe).HasColumnName("ID_narudzbe");

                entity.HasOne(d => d.IdDijelaNavigation)
                    .WithMany(p => p.StavkaNarudzbes)
                    .HasForeignKey(d => d.IdDijela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stavka_na__ID_di__33D4B598");

                entity.HasOne(d => d.IdNarudzbeNavigation)
                    .WithMany(p => p.StavkaNarudzbes)
                    .HasForeignKey(d => d.IdNarudzbe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stavka_na__ID_na__34C8D9D1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
