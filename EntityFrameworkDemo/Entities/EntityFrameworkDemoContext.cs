using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkDemo.Entities
{
    public partial class EntityFrameworkDemoContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<TblMain> TblMain { get; set; }
        public virtual DbSet<TblSub00> TblSub00 { get; set; }
        public virtual DbSet<TblSub01> TblSub01 { get; set; }
        public virtual DbSet<TblSubSub00> TblSubSub00 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=BRENT-ASUS\MSSQLSERVER01;Database=EntityFrameworkDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK_Addresses");

                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_Addresses_PersonId");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK_Persons");
            });

            modelBuilder.Entity<TblMain>(entity =>
            {
                entity.HasKey(e => e.MainId)
                    .HasName("PK__tblMain__71F8F5CC2ECE2E57");

                entity.ToTable("tblMain");

                entity.Property(e => e.MainData).HasMaxLength(10);
            });

            modelBuilder.Entity<TblSub00>(entity =>
            {
                entity.HasKey(e => e.Sub00Id)
                    .HasName("PK__tblSub00__382C3AF5790330E2");

                entity.ToTable("tblSub00");

                entity.Property(e => e.Sub00Data).HasMaxLength(10);

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.TblSub00)
                    .HasForeignKey(d => d.MainId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tblSub00_MainId_FK");
            });

            modelBuilder.Entity<TblSub01>(entity =>
            {
                entity.HasKey(e => e.Sub01Id)
                    .HasName("PK__tblSub01__38EE30AC7160F023");

                entity.ToTable("tblSub01");

                entity.Property(e => e.Sub01Data).HasMaxLength(10);

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.TblSub01)
                    .HasForeignKey(d => d.MainId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tblSub01_MainId_FK");
            });

            modelBuilder.Entity<TblSubSub00>(entity =>
            {
                entity.HasKey(e => e.SubSub00Id)
                    .HasName("PK__tblSubSu__25D7F38596D5F7DC");

                entity.ToTable("tblSubSub00");

                entity.Property(e => e.SubSub00Data).HasMaxLength(10);

                entity.HasOne(d => d.Sub00)
                    .WithMany(p => p.TblSubSub00)
                    .HasForeignKey(d => d.Sub00Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tblSubSub00_MainId_FK");
            });
        }
    }
}