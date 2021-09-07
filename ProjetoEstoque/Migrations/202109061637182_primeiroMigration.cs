namespace ProjetoEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeiroMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompraVendas",
                c => new
                    {
                        NomeProdutoC = c.String(nullable: false, maxLength: 128),
                        ValorFornecedor = c.Double(nullable: false),
                        ValorCliente = c.Double(nullable: false),
                        QuantidadeComprada = c.Int(nullable: false),
                        QuantidadeVendida = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NomeProdutoC);
            
            AddColumn("dbo.Produtos", "CompraVendaId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtos", "CompraVenda_NomeProdutoC", c => c.String(maxLength: 128));
            CreateIndex("dbo.Produtos", "CompraVenda_NomeProdutoC");
            AddForeignKey("dbo.Produtos", "CompraVenda_NomeProdutoC", "dbo.CompraVendas", "NomeProdutoC");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CompraVenda_NomeProdutoC", "dbo.CompraVendas");
            DropIndex("dbo.Produtos", new[] { "CompraVenda_NomeProdutoC" });
            DropColumn("dbo.Produtos", "CompraVenda_NomeProdutoC");
            DropColumn("dbo.Produtos", "CompraVendaId");
            DropTable("dbo.CompraVendas");
        }
    }
}
