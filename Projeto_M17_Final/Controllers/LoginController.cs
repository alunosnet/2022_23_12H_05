using Projeto_M17_Final.Data;
using Projeto_M17_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeto_M17_Final.Controllers
{
    public class LoginController : Controller
    {
        private Projeto_M17_FinalContext db = new Projeto_M17_FinalContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(Utilizador utilizador)
        {
            if (utilizador.Email != null && utilizador.Password != null)
            {
                ////has password
                //HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 2 });
                //var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                //utilizador.Password = Convert.ToBase64String(password);
                foreach (var u in db.Utilizadors.ToList())
                {
                    if (u.Email.ToLower() == utilizador.Email.ToLower() &&
                        u.Password == utilizador.Password)
                    {
                        //iniciar sessão
                        FormsAuthentication.SetAuthCookie(utilizador.Email, false);
                        //redirecionar utilizador
                        if (Request.QueryString["ReturnUrl"] == null)
                            return RedirectToAction("Index", "Home");
                        else
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                }
            }

            ModelState.AddModelError("", "Login falhou. Tente novamente.");
            return View(utilizador);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}