using YandM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace YandM.Dal
{
    public class OrderDal:DbContext
    {
        public DbSet<Order> order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().ToTable("Orders_tbl");
        }
    }
}