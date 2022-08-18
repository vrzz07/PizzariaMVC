using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Models
{
    public class PizzaSabor
    {
        public PizzaSabor(int pizzaId, int saborId)
        {
            PizzaId = pizzaId;
            SaborId = saborId;
        }

        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }
        public Sabor Sabor { get; set; }
        public int SaborId { get; set; }
    }
}
