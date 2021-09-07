using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoEstoque.Models
{
    public class Produtos
    {
        [Key]
        public int ProdutosId { get; set; }
        public string NomeProduto { get; set; }
        public double PrecoProduto { get; set; }
        public bool Cerveja { get; set; }
        public bool Refrigerante { get; set; }
        public bool Outros { get; set; }
        public bool Doces { get; set; }
        public int QuantidadeComprada { get; set; }
        public int BebidasId { get; set; }
        public virtual Bebidas Bebidas { get; set; }
        public int CompraVendaId { get; set; }
        public virtual CompraVenda CompraVenda { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataCompra { get; set; }
    }

}