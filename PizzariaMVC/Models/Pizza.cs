using PizzariaMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Models
{
    public class Pizza : IEntidade
    {
        public Pizza(string imageURL, string nome, decimal preco, int tamanhoId)
        {
            DataAlteracao = DataCadastro;
            DataCadastro = DateTime.Now;
            ImageURL = imageURL;
            Nome = nome;
            Preco = preco;
            TamanhoId = tamanhoId;
        }

        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ImageURL { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PizzaSabor> PizzasSabores { get; set; }
        public decimal Preco { get; set; }
        public Tamanho Tamanho { get; set; }
        public int TamanhoId { get; set; }


        public void AtualizarDados(string nome, decimal preco, string imageUrl, int tamanhoid)
        {
            Nome = nome;
            Preco = preco;
            ImageURL = imageUrl;
            TamanhoId = tamanhoid;
            DataAlteracao = DateTime.Now;
        }
        
    }
}
