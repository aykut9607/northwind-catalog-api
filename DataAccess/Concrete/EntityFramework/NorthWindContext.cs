using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthWindContext : DbContext
    //Context:DB ile proje class'ını bağlamak için kullanılan sınıftır.
    //java daki jpa gibi yani.
    {
        //override on yazıp cıkana tıkla.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
             (@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");

            /*optionsBuilder.UseSqlServer
             * (@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");*/

            // @ ters slash: \ işaretini tek olarak algılaması için kullanılır.
            //yani normal slash gibi algılaması için kullanılır.
        }

        public DbSet<Product> Products { get; set; }
        //DbSet<Product> : bizim entity imiz, Products: veritabanındaki tablo ismi.
        //yani entity ile tabloyu bağlamak için kullanılır.
        public DbSet<Category> Categories { get; set; }

    }
}
