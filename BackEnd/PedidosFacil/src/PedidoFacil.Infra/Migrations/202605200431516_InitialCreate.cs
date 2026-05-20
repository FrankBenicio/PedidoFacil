namespace PedidoFacil.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PedidoItens",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PedidoId = c.Guid(nullable: false),
                        ProdutoId = c.Guid(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estoque = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoItens", "ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.PedidoItens", "PedidoId", "dbo.Pedidos");
            DropIndex("dbo.PedidoItens", new[] { "ProdutoId" });
            DropIndex("dbo.PedidoItens", new[] { "PedidoId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Pedidos");
            DropTable("dbo.PedidoItens");
        }
    }
}
