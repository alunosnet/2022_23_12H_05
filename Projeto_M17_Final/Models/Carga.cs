using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto_M17_Final.Models
{
    public class Carga
    {
        [Key]
        public int CargaID { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////
        
        [Display(Name = "Data de aquisição")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tem de indicar a data de aquisição")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime data_aquisicao { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////

        [Display(Name = "Data de Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime data_entrega { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////
        
        [DataType(DataType.Currency)]
        [Display(Name = "Custo")]
        public decimal valor_pago { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////
        
        [ForeignKey("motorista")]
        [Display(Name = "Motorista")]
        [Required(ErrorMessage = "Tem de indicar o motorista")]
        public int MotoristaID { get; set; }
        public Motorista motorista { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////
        
        [ForeignKey("camiao")]
        [Display(Name = "Camiao")]
        [Required(ErrorMessage = "Tem de indicar o camiao")]
        public int CamiaoID { get; set; }
        public Camiao camiao { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////

        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "Tem de indicar o contéudo da carga")]
        public string descricao { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////

        //valor default para data de aquisicao
        public Carga()
        {
            data_aquisicao = DateTime.Now;
        }
    }
}