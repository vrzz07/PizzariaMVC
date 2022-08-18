using PizzariaMVC.Models;
using System.Collections.Generic;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostPizzaDropdownDTO
    {
        public PostPizzaDropdownDTO()
        {
            Sabores = new List<Sabor>();
            Tamanhos = new List<Tamanho>();
        }

        public List<Sabor> Sabores { get; set; }
        public List<Tamanho> Tamanhos { get; set; }
    }
}