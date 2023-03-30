using Projeto_M17_Final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_M17_Final.Helper
{
    public static class Utils
    {
        public static string UserId(this HtmlHelper htmlHelper,
            System.Security.Principal.IPrincipal utilizador)
        {
            string iduser = "";

            using (var context = new Projeto_M17_FinalContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT Id From utilizadors WHERE email = @p0",
                    utilizador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }

            return iduser;
        }
    }
}