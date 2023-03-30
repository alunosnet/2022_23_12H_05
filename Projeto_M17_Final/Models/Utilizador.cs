using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_M17_Final.Models
{
    public class Utilizador
    {
        [Key]
        public int ID { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Indique um nome de utilizador")]
        public string Nome { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Indique um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Indique uma palavra passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Indique um perfil de utilizador")]
        public int Perfil { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////

        //dropdown perfil
        public IEnumerable<System.Web.Mvc.SelectListItem> Perfis { get; set; }
    }
}