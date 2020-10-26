using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APILoto.Models
{
    public partial class LotteryContext : DbContext
    {

        public LotteryContext(DbContextOptions<LotteryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillDetail> BillDetail { get; set; }
        public virtual DbSet<Draw> Draw { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill_");

                entity.Property(e => e.Date)
                    .HasColumnName("Date_")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BillPK_User");
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

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role_");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("Description_")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State_");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("Description_")
                    .HasMaxLength(150);
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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password_")
                    .HasMaxLength(150);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserFK_Role");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserFK_State");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
