using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestAPI.Models
{
    public partial class Commute_DbContext : DbContext
    {
        
        public Commute_DbContext(DbContextOptions<Commute_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DriverTable> DriverTable { get; set; }
        public virtual DbSet<ParentTable> ParentTable { get; set; }
        public virtual DbSet<StudentTable> StudentTable { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverTable>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleNo)
                    .IsRequired()
                    .HasColumnName("vehicle_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParentTable>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentTable>(entity =>
            {
                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("parentId");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("user_info");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
