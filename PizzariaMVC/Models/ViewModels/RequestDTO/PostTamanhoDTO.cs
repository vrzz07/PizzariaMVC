using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Models.ViewModels.RequestDTO
{
    public class PostTamanhoDTO
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório!")]
        public string Nome { get; set; }
    }
}