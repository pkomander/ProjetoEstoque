using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoEstoque.Models
{
    public class CompraVenda
    {
        [Key]
        public int CompraVendaId { get; set; }
        public string NomeProdutoC { get; set; }
        public double ValorFornecedor { get; set; }
        public double ValorCliente { get; set; }
        public int QuantidadeComprada { get; set; }
        public int QuantidadeVendida { get; set; }
        //public int ProdutosId { get; set; }
        //public virtual Produtos Produtos { get; set; }
    }
}