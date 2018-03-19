using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvocaciaXPTO;
using AdvocaciaXPTO.Controllers;
using AdvocaciaXPTO.Interface;
using AdvocaciaXPTO.Models;
using AdvocaciaXPTO.Properts;

namespace AdvocaciaXPTO.Tests.Controllers
{
    [TestClass]
    public class TestesControllerTest
    {
        /// <summary>
        /// Os testes são para validar as Regras de Negócio e se o sistema está acessando o Banco de Dados, 
        /// trazendo as informações corretamente.
        /// Todos esses métodos estão na RNAdvocaciaXPTOManager:IRNAdvocaciaXPTO(interface).
        /// </summary>
        IRNAdvocaciaXPTO interXPTO = new RNAdvocaciaXPTOManager();
        pptCliente pCliente = null;

        [TestMethod]
        public void Teste1()
        {
            pCliente = new pptCliente();
            pCliente.Processo = new pptProcesso();

            pCliente = interXPTO.GetVlTotalAtivos();

            Assert.IsNotNull(pCliente);
            Assert.IsTrue("1.087.000,00".Equals(pCliente.Processo.VlTotal));
        }

        [TestMethod]
        public void Teste2()
        {
            pCliente = new pptCliente();
            pCliente.Processo = new pptProcesso();

            pCliente = interXPTO.GetMediaEmpresaARJ();

            Assert.IsNotNull(pCliente);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(pCliente.Processo.VlTotal));
            Assert.IsTrue("110.000,00".Equals(pCliente.Processo.VlTotal));
        }

        [TestMethod]
        public void Teste3()
        {
            string qtdProcessos = string.Empty;

            qtdProcessos = interXPTO.GetQtdProcessosMaiorCemMil();

            Assert.IsNotNull(qtdProcessos);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(qtdProcessos));
            Assert.IsTrue("2".Equals(qtdProcessos));
        }

        [TestMethod]
        public void Teste4()
        {
            pCliente = new pptCliente();
            pCliente.Processo = new pptProcesso();

            List<pptCliente> listaCli = new List<pptCliente>();
            listaCli = interXPTO.GetListaProcSetembro2007();

            Assert.IsNotNull(listaCli);
            Assert.AreEqual(1, listaCli.Count());

            foreach (var item in listaCli)
            {
                pCliente.Processo.NrProcesso = item.Processo.NrProcesso;
            }

            Assert.IsTrue("00010TRABAM".Equals(pCliente.Processo.NrProcesso));

        }

        [TestMethod]
        public void Teste5()
        {
            pCliente = new pptCliente();
            pCliente.Processo = new pptProcesso();

            List<pptCliente> listaCli = new List<pptCliente>();
            listaCli = interXPTO.GetClienteProcessoMesmoEstado();

            Assert.IsNotNull(listaCli);
            Assert.AreEqual(4, listaCli.Count());

            int linha = 0;
            foreach (var item in listaCli)
            {
                pCliente.Cliente = item.Cliente;
                pCliente.Processo.NrProcesso = item.Processo.NrProcesso;

                switch (linha)
                {
                    case 0:
                        Assert.IsTrue("EmpresaA".Equals(pCliente.Cliente));
                        Assert.IsTrue("00001CIVELRJ".Equals(pCliente.Processo.NrProcesso));
                        break;

                    case 1:
                        Assert.IsTrue("EmpresaA".Equals(pCliente.Cliente));
                        Assert.IsTrue("00004CIVELRJ".Equals(pCliente.Processo.NrProcesso));
                        break;

                    case 2:
                        Assert.IsTrue("EmpresaB".Equals(pCliente.Cliente));
                        Assert.IsTrue("00008CIVELSP".Equals(pCliente.Processo.NrProcesso));
                        break;

                    case 3:
                        Assert.IsTrue("EmpresaB".Equals(pCliente.Cliente));
                        Assert.IsTrue("00009CIVELSP".Equals(pCliente.Processo.NrProcesso));
                        break;

                    default:
                        break;
                }
                linha++;
            }


        }

        [TestMethod]
        public void Teste6()
        {
            pCliente = new pptCliente();
            pCliente.Processo = new pptProcesso();

            List<pptCliente> listaCli = new List<pptCliente>();
            listaCli = interXPTO.GetProcessosSiglaTRAB();

            Assert.IsNotNull(listaCli);
            Assert.AreEqual(2, listaCli.Count());

            int linha = 0;
            foreach (var item in listaCli)
            {
                pCliente.Cliente = item.Cliente;
                pCliente.Processo.NrProcesso = item.Processo.NrProcesso;

                switch (linha)
                {
                    case 0:
                        Assert.IsTrue("00003TRABMG".Equals(pCliente.Processo.NrProcesso));
                        break;

                    case 1:
                        Assert.IsTrue("00010TRABAM".Equals(pCliente.Processo.NrProcesso));
                        break;
                        
                    default:
                        break;
                }

                linha++;
            }


        }

    }
}
