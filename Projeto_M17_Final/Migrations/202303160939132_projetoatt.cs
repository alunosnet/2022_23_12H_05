namespace Projeto_M17_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projetoatt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cargas", "descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cargas", "descricao");
        }
    }
}
