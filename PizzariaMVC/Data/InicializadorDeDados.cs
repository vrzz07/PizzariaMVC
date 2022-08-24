using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PizzariaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Data
{
    public class InicializadorDeDados
    {
        public static void Inicializar(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider
                    .GetService<PizzariaDbContext>();

                context.Database.EnsureCreated();

                if (!context.Pizzas.Any())
                {
                    context.Pizzas.AddRange(new List<Pizza>()
                    {
                        new Pizza("https://www.picanhacia.com.br/wp-content/uploads/2017/01/frango-c-catupiry.jpg", "Frango com Catupiry", 59, 2),
                    });
                }

                if (!context.Sabores.Any())
                {
                    context.Sabores.AddRange(new List<Sabor>()
                    {
                        new Sabor("Frango"),
                    });
                }

                if (!context.Tamanhos.Any())
                {
                    context.Tamanhos.AddRange(new List<Tamanho>()
                    {
                        new Tamanho("Pequeno"),
                        new Tamanho("Médio"),
                        new Tamanho("Grande"),
                    });
                }

                if (!context.PizzasSabores.Any())
                {
                    context.PizzasSabores.AddRange(new List<PizzaSabor>()
                    {
                        new PizzaSabor(1, 1),

                    });
                }
            }   
        }
    }
}
