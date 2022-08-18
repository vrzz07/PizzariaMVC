using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostPizzaDTO
    {
        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "A imagem é obrigatóra!")]
        public string ImageURL { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O Preço é obrigatório!")]
        public decimal Preco { get; set; }

        #region Relacionamentos

        [Display(Name = "Sabor")]
        [Required(ErrorMessage = "A sabor é obrigatória!")]
        public List<int> SaborId { get; set; }

        [Display(Name = "Tamanho")]
        [Required(ErrorMessage = "O tamanho é obrigatório!")]
        public int TamanhoId { get; set; }

        #endregion
    }
}