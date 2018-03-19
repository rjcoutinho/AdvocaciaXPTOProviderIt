using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdvocaciaXPTO.Properts
{
    public class pptCliente
    {

        public int IdCLiente { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "O campo CnpjCpf é obrigatório.")]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        public string Tipo { get; set; }
        
        public pptProcesso Processo { get; set; }
        
    }
}