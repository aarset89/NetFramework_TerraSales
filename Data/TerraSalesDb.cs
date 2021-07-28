using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data
{
    public partial class TerraSalesDb : DbContext
    {
        public TerraSalesDb()
            : base("name=TerraSalesContext")
        {
        }

        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 5);

            modelBuilder.Entity<SalesOrder>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
