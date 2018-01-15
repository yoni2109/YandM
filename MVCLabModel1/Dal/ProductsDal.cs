using YandM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YandM.Dal
{
    public class ProductsDal : DbContext
    {
        public DbSet<Products> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>().ToTable("Products_tbl");
        }

    }
}