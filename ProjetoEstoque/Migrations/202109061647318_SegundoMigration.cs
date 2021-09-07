namespace ProjetoEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundoMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "CompraVenda_NomeProdutoC", "dbo.CompraVendas");
            DropIndex("dbo.Produtos", new[] { "CompraVenda_NomeProdutoC" });
            DropColumn("dbo.Produtos", "CompraVendaId");
            RenameColumn(table: "dbo.Produtos", name: "CompraVenda_NomeProdutoC", newName: "CompraVendaId");
            DropPrimaryKey("dbo.CompraVendas");
            AddColumn("dbo.CompraVendas", "CompraVendaId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Produtos", "CompraVendaId", c => c.Int(nullable: false));
            AlterColumn("dbo.CompraVendas", "NomeProdutoC", c => c.String());
            AddPrimaryKey("dbo.CompraVendas", "CompraVendaId");
            CreateIndex("dbo.Produtos", "CompraVendaId");
            AddForeignKey("dbo.Produtos", "CompraVendaId", "dbo.CompraVendas", "CompraVendaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CompraVendaId", "dbo.CompraVendas");
            DropIndex("dbo.Produtos", new[] { "CompraVendaId" });
            DropPrimaryKey("dbo.CompraVendas");
            AlterColumn("dbo.CompraVendas", "NomeProdutoC", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Produtos", "CompraVendaId", c => c.String(maxLength: 128));
            DropColumn("dbo.CompraVendas", "CompraVendaId");
            AddPrimaryKey("dbo.CompraVendas", "NomeProdutoC");
            RenameColumn(table: "dbo.Produtos", name: "CompraVendaId", newName: "CompraVenda_NomeProdutoC");
            AddColumn("dbo.Produtos", "CompraVendaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtos", "CompraVenda_NomeProdutoC");
            AddForeignKey("dbo.Produtos", "CompraVenda_NomeProdutoC", "dbo.CompraVendas", "NomeProdutoC");
        }
    }
}
