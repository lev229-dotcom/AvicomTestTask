using Avicom.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Avicom.ViewModel
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ClientStatus> ClientStatus { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<BuyedProducts> BuyedProducts { get; set; }

        public ApplicationContext() { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyedProducts>()
                    .HasKey(c => new { c.Client_ID, c.Product_ID });

            modelBuilder.Entity<BuyedProducts>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.BuyedProducts)
                .HasForeignKey(bc => bc.Product_ID);

            modelBuilder.Entity<BuyedProducts>()
                .HasOne(bc => bc.Client)
                .WithMany(b => b.BuyedProducts)
                .HasForeignKey(bc => bc.Client_ID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=/*Ваше имя сервера*/;Initial Catalog=Avicom;Integrated Security=True;");
        }

        
    }
}
