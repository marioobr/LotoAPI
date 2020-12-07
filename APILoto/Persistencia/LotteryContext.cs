using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistencia
{
    public partial class LotteryContext : IdentityDbContext<User>
    {

        public LotteryContext(DbContextOptions<LotteryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillDetail> BillDetail { get; set; }
        public virtual DbSet<Draw> Draw { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill_");

                entity.Property(e => e.Date)
                    .HasColumnName("Date_")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("DetailPK");

                entity.ToTable("BillDetail_");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetail)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetailFK_Bill");

                entity.HasOne(d => d.Draw)
                    .WithMany(p => p.BillDetail)
                    .HasForeignKey(d => d.DrawId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetailFK_Draw");
            });

            modelBuilder.Entity<Draw>(entity =>
            {
                entity.ToTable("Draw_");

                entity.Property(e => e.Date)
                    .HasColumnName("Date_")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User_");

                entity.Property(e => e.FirstNames)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastNames)
                    .IsRequired()
                    .HasMaxLength(150);
            });
        }
    }
}
