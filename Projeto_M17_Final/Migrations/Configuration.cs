namespace Projeto_M17_Final.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto_M17_Final.Data.Projeto_M17_FinalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Projeto_M17_Final.Data.Projeto_M17_FinalContext";
        }

        protected override void Seed(Projeto_M17_Final.Data.Projeto_M17_FinalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
