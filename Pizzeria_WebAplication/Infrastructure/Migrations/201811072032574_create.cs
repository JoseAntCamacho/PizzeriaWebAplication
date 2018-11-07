namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commentaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Punctuation = c.Byte(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        User = c.String(nullable: false),
                        PizzaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Picture = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pizza_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id)
                .Index(t => t.Pizza_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaries", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.Ingredients", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Ingredients", new[] { "Pizza_Id" });
            DropIndex("dbo.Commentaries", new[] { "PizzaId" });
            DropTable("dbo.Ingredients");
            DropTable("dbo.Pizzas");
            DropTable("dbo.Commentaries");
        }
    }
}
