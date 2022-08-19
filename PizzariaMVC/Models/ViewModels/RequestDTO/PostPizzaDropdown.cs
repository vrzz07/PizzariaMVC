using PizzariaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models.ViewModels.RequestDTO
{
    public class PostPizzaDropdown
    {
        public PostPizzaDropdown()
        {
            Sabores = new List<Sabor>();
            Tamanhos = new List<Tamanho>();
        }

        public List<Sabor> Sabores { get; set; }
        public List<Tamanho> Tamanhos { get; set; }
    }
}