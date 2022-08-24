﻿using PizzariaMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Models
{
    public class Sabor : IEntidade
    {
        public Sabor(string nome)
        {
            DataAlteracao = DataCadastro;
            DataCadastro = DateTime.Now;
            Nome = nome;
        }

        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ImageURL { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PizzaSabor> PizzasSabores { get; set; }

        public void AtualizarDados(string nome)
        {
            Nome = nome;
            DataAlteracao = DateTime.Now;
        }
    }
}
