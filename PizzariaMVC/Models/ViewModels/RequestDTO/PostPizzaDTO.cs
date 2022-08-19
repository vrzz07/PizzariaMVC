using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Models.ViewModels.RequestDTO
{
    public class PostPizzaDTO
    {
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "A foto é obrigatória!")]
        public string FotoURL { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O Preço é obrigatório!")]
        public decimal Preco { get; set; }

        #region Relacionamentos
        [Display(Name = "Informe o Tamanho da pizza")]
        [Required(ErrorMessage = "Tamanho é obrigatório!")]
        public int TamanhoId { get; set; }

        [Display(Name = "Informe o(s) Sabor(res) da pizza")]
        [Required(ErrorMessage = "A foto é obrigatória!")]
        public List<int> SaboresId { get; set; }

        #endregion
    }
}