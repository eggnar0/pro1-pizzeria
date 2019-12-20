using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s15410Context : DbContext
    {
        public s15410Context()
        {
        }

        public s15410Context(DbContextOptions<s15410Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<PizzaSkladnikZamowienie> PizzaSkladnikZamowienie { get; set; }
        public virtual DbSet<PizzaTyp> PizzaTyp { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<ProduktZamowienie> ProduktZamowienie { get; set; }
        public virtual DbSet<Rabat> Rabat { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s15410;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasColumnName("miasto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NrDomu).HasColumnName("nr_domu");

                entity.Property(e => e.NrLokalu).HasColumnName("nr_lokalu");

                entity.Property(e => e.Telefon).HasColumnName("telefon");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasColumnName("ulica")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ciasto)
                    .IsRequired()
                    .HasColumnName("ciasto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.Wielkosc)
                    .IsRequired()
                    .HasColumnName("wielkosc")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PizzaNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnik_Pizza");
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.PizzaId, e.SkladnikId });

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.SkladnikId).HasColumnName("skladnik_id");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DomyslneSkladniki_Pizza");

                entity.HasOne(d => d.Skladnik)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.SkladnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DomyslneSkladniki_Skladnik");
            });

            modelBuilder.Entity<PizzaSkladnikZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.ZamowienieId, e.PizzaSkladnikId });

                entity.Property(e => e.ZamowienieId).HasColumnName("zamowienie_id");

                entity.Property(e => e.PizzaSkladnikId).HasColumnName("PizzaSkladnik_id");

                entity.HasOne(d => d.PizzaSkladnik)
                    .WithMany(p => p.PizzaSkladnikZamowienie)
                    .HasForeignKey(d => d.PizzaSkladnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnikZamowienie_PizzaSkladnik");

                entity.HasOne(d => d.Zamowienie)
                    .WithMany(p => p.PizzaSkladnikZamowienie)
                    .HasForeignKey(d => d.ZamowienieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnikZamowienie_Zamowienie");
            });

            modelBuilder.Entity<PizzaTyp>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Nazwa).HasColumnName("nazwa");

                entity.Property(e => e.RabatId).HasColumnName("rabat_id");

                entity.HasOne(d => d.Rabat)
                    .WithMany(p => p.PizzaTyp)
                    .HasForeignKey(d => d.RabatId)
                    .HasConstraintName("Pizza_Rabat");
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Kategoria)
                    .IsRequired()
                    .HasColumnName("kategoria")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProduktZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.ProduktId, e.ZamowienieId });

                entity.Property(e => e.ProduktId).HasColumnName("produkt_id");

                entity.Property(e => e.ZamowienieId).HasColumnName("zamowienie_id");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.ProduktZamowienie)
                    .HasForeignKey(d => d.ProduktId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProduktZamowienie_Produkt");

                entity.HasOne(d => d.Zamowienie)
                    .WithMany(p => p.ProduktZamowienie)
                    .HasForeignKey(d => d.ZamowienieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProduktZamowienie_Zamowienie");
            });

            modelBuilder.Entity<Rabat>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Wielkosc).HasColumnName("wielkosc");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kategoria)
                    .IsRequired()
                    .HasColumnName("kategoria")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.KlientId).HasColumnName("klient_id");

                entity.HasOne(d => d.Klient)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");
            });
        }
    }
}
