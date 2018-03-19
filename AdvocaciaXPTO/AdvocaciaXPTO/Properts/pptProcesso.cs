using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdvocaciaXPTO.Properts
{
    public class pptProcesso
    {
        public int IdProcesso { get; set; }

        [Required(ErrorMessage = "O campo Data do Processo é obrigatório.")]
        public DateTime DtProcesso { get; set; }
        
        [Required(ErrorMessage = "O campo Valor Processo é obrigatório.")]
        public decimal VlProcesso { get; set; }
        
        [Required(ErrorMessage = "O campo Número do Processo é obrigatório.")]
        public string NrProcesso { get; set; }

        [Required(ErrorMessage = "O campo Processo Ativo é obrigatório.")]
        public bool Ativo { get; set; }

        public string qtdProcessos { get; set; }

        public string VlTotal { get; set; }

    }
}