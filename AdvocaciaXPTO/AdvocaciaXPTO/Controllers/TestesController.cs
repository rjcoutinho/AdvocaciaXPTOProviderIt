using AdvocaciaXPTO.Interface;
using AdvocaciaXPTO.Models;
using AdvocaciaXPTO.Properts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvocaciaXPTO.Controllers
{
    public class TestesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teste1()
        {

            IRNAdvocaciaXPTO rnManager = new RNAdvocaciaXPTOManager();
            pptCliente p = new pptCliente();
            p = rnManager.GetVlTotalAtivos();
            
            return View(p);
        }

        public ActionResult Teste2()
        {
            IRNAdvocaciaXPTO rnManager = new RNAdvocaciaXPTOManager();
            pptCliente pCliente = new pptCliente();
            pCliente = rnManager.GetMediaEmpresaARJ();
            
            return View(pCliente);
        }

        public ActionResult Teste3()
        {
            IRNAdvocaciaXPTO rnManager = new RNAdvocaciaXPTOManager();
            pptCliente pCliente = new pptCliente();
            pCliente.Processo = new pptProcesso();
            pCliente.Processo.qtdProcessos =  rnManager.GetQtdProcessosMaiorCemMil();

            return View(pCliente);
        }

        public ActionResult Teste4()
        {
            IRNAdvocaciaXPTO rnManager = new RNAdvocaciaXPTOManager();
            List<pptCliente> listCliente = new List<pptCliente>();
            listCliente = rnManager.GetListaProcSetembro2007();
            return View(listCliente);
        }

        public ActionResult Teste5()
        {
            IRNAdvocaciaXPTO rnManager = new RNAdvocaciaXPTOManager();
            List<pptCliente> clientList = new List<pptCliente>();
            clientList = rnManager.GetClienteProcessoMesmoEstado();
            
            return View(clientList);
        }

        public ActionResult Teste6()
        {
            IRNAdvocaciaXPTO rnManager = new RNAdvocaciaXPTOManager();
            List<pptCliente> clientList = new List<pptCliente>();
            clientList = rnManager.GetProcessosSiglaTRAB();

            return View(clientList);
        }

    }
}