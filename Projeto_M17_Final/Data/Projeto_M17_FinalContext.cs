using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto_M17_Final.Data
{
    public class Projeto_M17_FinalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Projeto_M17_FinalContext() : base("name=Projeto_M17_FinalContext")
        {
        }

        public System.Data.Entity.DbSet<Projeto_M17_Final.Models.Utilizador> Utilizadors { get; set; }

        public System.Data.Entity.DbSet<Projeto_M17_Final.Models.Motorista> Motoristas { get; set; }

        public System.Data.Entity.DbSet<Projeto_M17_Final.Models.Camiao> Camiaos { get; set; }

        public System.Data.Entity.DbSet<Projeto_M17_Final.Models.Carga> Cargas { get; set; }
    }
}
