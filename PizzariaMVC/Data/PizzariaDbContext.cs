using Microsoft.EntityFrameworkCore;
using PizzariaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Data
{
    public class PizzariaDbContext : DbContext
    {
        public PizzariaDbContext(DbContextOptions<PizzariaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaSabor>().HasKey(ps => new
            {
                ps.PizzaId,
                ps.SaborId
            });
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<PizzaSabor> PizzasSabores { get; set; }
    }
}
