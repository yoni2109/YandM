using YandM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YandM.Dal
{
    public class CustomerDal:DbContext
    {
        public DbSet<Customer>  Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("tblCustomers");
        }

    }
}