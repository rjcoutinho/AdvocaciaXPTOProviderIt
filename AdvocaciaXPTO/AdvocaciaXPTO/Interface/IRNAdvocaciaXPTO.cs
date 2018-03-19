using AdvocaciaXPTO.Models;
using AdvocaciaXPTO.Properts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvocaciaXPTO.Interface
{
    public interface IRNAdvocaciaXPTO
    {
        
        pptCliente GetVlTotalAtivos();
        pptCliente GetMediaEmpresaARJ();
        string GetQtdProcessosMaiorCemMil();
        List<pptCliente> GetListaProcSetembro2007();
        List<pptCliente> GetClienteProcessoMesmoEstado();
        List<pptCliente> GetProcessosSiglaTRAB();
    }

}