using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestePratico.Models
{
    public class ProdutoViewModel
    {
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Produto")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Descrição do Produto")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Informe se o produto é perecivel", AllowEmptyStrings = false)]
        [Display(Name = "Perecivel")]
        public Boolean Perecivel { get; set; }

        public Boolean Ativo { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria", AllowEmptyStrings = false)]
        [Display(Name = "Categoria")]
        public Int32 CategoriaID { get; set; }

    }
}