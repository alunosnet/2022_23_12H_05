using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_M17_Final.Models
{
    public class Motorista
    {
        [Key]
        public int MotoristaID { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Tem de indicar o nome do motorista")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome do motorista, deve ter pelo menos 3 letras")]
        public string Nome { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Tem de indicar um email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Tem de indicar a morada do motorista")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Morada muito pequena. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira a morada do motorista, deve ter pelo menos 3 letras")]
        public string Morada { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Tem de indicar o código postal do motorista")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Código postal muito pequeno. Tem de ter pelo menos 8 letras")]
        [UIHint("Insira o código postal do motorista.")]
        [Display(Name = "Código Postal")]
        public string CP { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////
        
        [Required(ErrorMessage = "Tem de indicar um telefone.")]
        [StringLength(15)]
        [MinLength(9, ErrorMessage = "O telefone deve ter pelo menos 9 digitos")]
        public string Telefone { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////
        
        [Required(ErrorMessage = "Tem de indicar a data de nascimento do motorista")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        //lista das estadias
        public virtual List<Carga> listaCargas { get; set; }
    }
}