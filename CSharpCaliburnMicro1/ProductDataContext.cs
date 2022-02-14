using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCaliburnMicro1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace CSharpCaliburnMicro1
{
    public class ProductDataContext : DbContext
    {
        private string connectionString;
        public ProductDataContext(DbContextOptions options) : base(options)
        {
            var opt = options.Extensions.Last();

            connectionString = ((SqlServerOptionsExtension)opt).ConnectionString;
            Trace.WriteLine("Product Data context created");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
        }

        public override void Dispose()
        {
            Trace.WriteLine("DB context disposing");
            base.Dispose();
        }
    }
}
