using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebCarShop.Data.Models;

public partial class UsedCarContext : DbContext
{
    public UsedCarContext()
    {
    }

    public UsedCarContext(DbContextOptions<UsedCarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Carcase> Carcases { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Dealer> Dealers { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<PhotoCar> PhotoCars { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DENISKRAVCHENKO\\SQLEXPRESS;Database=Used_car;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.IdBrand).HasName("XPKBrand");

            entity.ToTable("Brand");

            entity.Property(e => e.IdBrand)
                .ValueGeneratedNever()
                .HasColumnName("id_brand");
            entity.Property(e => e.NameBrand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_brand");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdLot).HasName("XPKCar");

            entity.ToTable("Car", tb =>
                {
                    tb.HasTrigger("tD_Car");
                    tb.HasTrigger("tU_Car");
                });

            entity.Property(e => e.IdLot)
                .ValueGeneratedNever()
                .HasColumnName("id_lot");
            entity.Property(e => e.Availability)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('в наличии')")
                .HasColumnName("availability");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.DateIssue)
                .HasColumnType("datetime")
                .HasColumnName("date_issue");
            entity.Property(e => e.EngineCapacity)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("engine_capacity");
            entity.Property(e => e.FuelType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fuel_type");
            entity.Property(e => e.IdCarcase).HasColumnName("id_carcase");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("model_name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.TypeEngine)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_engine");
            entity.Property(e => e.YearIssue)
                .HasColumnType("datetime")
                .HasColumnName("year_issue");

            entity.HasOne(d => d.ModelNameNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ModelName)
                .HasConstraintName("R_6");
        });

        modelBuilder.Entity<Carcase>(entity =>
        {
            entity.HasKey(e => e.IdCarcase).HasName("XPKCarcase");

            entity.ToTable("Carcase");

            entity.Property(e => e.IdCarcase)
                .ValueGeneratedNever()
                .HasColumnName("id_carcase");
            entity.Property(e => e.TypeCarcase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_carcase");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("XPKClient");

            entity.ToTable("Client");

            entity.Property(e => e.IdClient)
                .ValueGeneratedNever()
                .HasColumnName("id_client");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.NameClient)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name_client");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.IdContract).HasName("XPKContract");

            entity.ToTable("Contract");

            entity.Property(e => e.IdContract)
                .ValueGeneratedNever()
                .HasColumnName("id_contract");
            entity.Property(e => e.ActualPrice)
                .HasColumnType("money")
                .HasColumnName("actual_price");
            entity.Property(e => e.DateTransaction)
                .HasColumnType("datetime")
                .HasColumnName("date_transaction");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdDealer).HasColumnName("id_dealer");
            entity.Property(e => e.IdLot).HasColumnName("id_lot");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("R_1");

            entity.HasOne(d => d.IdDealerNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdDealer)
                .HasConstraintName("R_3");

            entity.HasOne(d => d.IdLotNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdLot)
                .HasConstraintName("R_2");
        });

        modelBuilder.Entity<Dealer>(entity =>
        {
            entity.HasKey(e => e.IdDealer).HasName("XPKDealer");

            entity.ToTable("Dealer");

            entity.Property(e => e.IdDealer)
                .ValueGeneratedNever()
                .HasColumnName("id_dealer");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.NameDealer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name_dealer");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelName).HasName("XPKModel");

            entity.ToTable("Model");

            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("model_name");
            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.IdCarcase).HasColumnName("id_carcase");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.IdBrand)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("R_5");

            entity.HasOne(d => d.IdCarcaseNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.IdCarcase)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("R_4");
        });

        modelBuilder.Entity<PhotoCar>(entity =>
        {
            entity.HasKey(e => e.IdLot).HasName("XPKPhoto");

            entity.ToTable("Photo_car");

            entity.Property(e => e.IdLot)
                .ValueGeneratedNever()
                .HasColumnName("id_lot");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdLotNavigation).WithOne(p => p.PhotoCar)
                .HasForeignKey<PhotoCar>(d => d.IdLot)
                .HasConstraintName("R_8");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.IdLot).HasName("XPKState");

            entity.ToTable("State");

            entity.Property(e => e.IdLot)
                .ValueGeneratedNever()
                .HasColumnName("id_lot");
            entity.Property(e => e.StateDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("state_description");

            entity.HasOne(d => d.IdLotNavigation).WithOne(p => p.State)
                .HasForeignKey<State>(d => d.IdLot)
                .HasConstraintName("R_9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
