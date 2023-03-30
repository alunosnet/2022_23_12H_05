using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_M17_Final.Models
{
    public class Camiao
    {
        [Key]
        public int Id { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Tem de indicar o modelo do camiao")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o modelo do camiao, deve ter pelo menos 3 letras")]
        public string Modelo { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Tem de indicar o peso máxima do camiao")]
        [Range(1000, 3000, ErrorMessage = "O camiao tem de ter lotação entre 1000 e 3000")]
        [UIHint("Insira o peso do camiao (de 1000 a 3000)")]
        [Display(Name = "Peso")]
        public int Peso { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Tem de indicar o custo do camiao")]
        [Range(0, 10000, ErrorMessage = "Custo do camiao deve estar entre 0 e 10000")]
        [UIHint("Insira o custo do camiao")]
        [Display(Name = "Custo")]
        [DataType(DataType.Currency)]
        public decimal Custo { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////
        public bool Estado { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////
        
        [Required(ErrorMessage = "Tem de indicar o tipo de camiao")]
        [StringLength(20)]
        [MinLength(4, ErrorMessage = "O tipo de camiao deve ter pelo menos 4 letras(2 eixos, simples...)")]
        [Display(Name = "Tipo de Camiao")]
        public string Tipo_Camiao { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////
        
        public Camiao()
        {
            Estado = true;
        }
    }
}