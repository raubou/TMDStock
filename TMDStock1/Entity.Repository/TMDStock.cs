using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TMDStock1.Entity
{
    public partial class TMDStock : DbContext
    {
        public TMDStock()
        {
        }

        public TMDStock(DbContextOptions<TMDStock> options)
            : base(options)
        {
        }

        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TMSLAP\\TMDLAPSQL1;Database=TMDStock;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("dateUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Positions_Transactions");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DatePurchased)
                    .HasColumnName("datePurchased")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
