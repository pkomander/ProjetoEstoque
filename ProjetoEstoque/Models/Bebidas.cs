using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoEstoque.Models
{
    public class Bebidas
    {
        [Key]
        public int? BebidasId { get; set; }
        public string NomeBebida { get; set; }
    }
}