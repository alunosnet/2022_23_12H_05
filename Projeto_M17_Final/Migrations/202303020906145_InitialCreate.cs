namespace Projeto_M17_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Camiaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false, maxLength: 80),
                        Peso = c.Int(nullable: false),
                        Custo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                        Tipo_Camiao = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Motoristas",
                c => new
                    {
                        MotoristaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false),
                        Morada = c.String(nullable: false, maxLength: 80),
                        CP = c.String(nullable: false, maxLength: 80),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MotoristaID);
            
            CreateTable(
                "dbo.Cargas",
                c => new
                    {
                        CargaID = c.Int(nullable: false, identity: true),
                        data_aquisicao = c.DateTime(nullable: false),
                        data_entrega = c.DateTime(nullable: false),
                        valor_pago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MotoristaID = c.Int(nullable: false),
                        CamiaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CargaID)
                .ForeignKey("dbo.Camiaos", t => t.CamiaoID, cascadeDelete: true)
                .ForeignKey("dbo.Motoristas", t => t.MotoristaID, cascadeDelete: true)
                .Index(t => t.MotoristaID)
                .Index(t => t.CamiaoID);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cargas", "MotoristaID", "dbo.Motoristas");
            DropForeignKey("dbo.Cargas", "CamiaoID", "dbo.Camiaos");
            DropIndex("dbo.Cargas", new[] { "CamiaoID" });
            DropIndex("dbo.Cargas", new[] { "MotoristaID" });
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Cargas");
            DropTable("dbo.Motoristas");
            DropTable("dbo.Camiaos");
        }
    }
}
