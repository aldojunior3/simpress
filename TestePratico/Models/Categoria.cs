using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestePratico.Models
{
    [Table("tblCategoriaProduto")]
    public class Categoria
    {
        public int id { get; set; }
        [Display(Name = "Categoria do Produto")]
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Boolean Ativo { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}