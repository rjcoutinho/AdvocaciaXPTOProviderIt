using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using AdvocaciaXPTO.Properts;
using System.Web.Configuration;
using AdvocaciaXPTO.Interface;

namespace AdvocaciaXPTO.Models
{
    public class RNAdvocaciaXPTOManager : IRNAdvocaciaXPTO
    {

        protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["bdAdvocaciaXPTO"].ConnectionString;
                
        public pptCliente GetVlTotalAtivos()
        {
            string sql = "Select sum(VlProcesso) as VlTotal From tbProcesso WHERE Ativo = 1";

            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                pptCliente cli = new pptCliente();

                try
                {
                    conn.Open();
                    cli = new pptCliente();
                    cli.Processo = new pptProcesso();
                    cli.Processo.VlTotal = cmd.ExecuteScalar().ToString();

                    cli.Processo.VlTotal = string.Format("{0:N}", Convert.ToInt32(cli.Processo.VlTotal));
                }
                catch (Exception)
                {
                    conn.Close();
                }

                return cli;

            }
        }

        public pptCliente GetMediaEmpresaARJ()
        {
            string sql = "SELECT c.Cliente, p.VlProcesso FROM tbCliente  c " +
                         "INNER JOIN tbProcesso p ON p.IdCliente = c.IdCliente " +
                         "WHERE Cliente = 'EmpresaA' and p.EstadoProcesso = 'Rio de Janeiro'";

            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<pptCliente> list = new List<pptCliente>();
                pptCliente pCli = null;
                decimal vlTotal = 0;
                int qtdNumProcesso = 0;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            pCli = new pptCliente();
                            pCli.Processo = new pptProcesso();
                            pCli.Cliente = reader["Cliente"].ToString();
                            pCli.Processo.VlProcesso = (decimal)reader["VlProcesso"];
                            list.Add(pCli);

                            if (qtdNumProcesso == 0)
                                vlTotal += pCli.Processo.VlProcesso;
                            else
                                vlTotal = vlTotal + pCli.Processo.VlProcesso;

                            qtdNumProcesso++;
                        }
                    }

                    pCli.Processo.VlTotal = (Convert.ToInt32(vlTotal) / list.Count).ToString();
                    pCli.Processo.VlTotal = string.Format("{0:N}", Convert.ToInt32(pCli.Processo.VlTotal));

                }
                catch (Exception)
                {
                    conn.Close();
                }

                return pCli;
            }
        }

        public string GetQtdProcessosMaiorCemMil()
        {
            string sql = "SELECT count(NrProcesso) AS QtdProcessos From tbProcesso WHERE VlProcesso > 100000";

            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                pptCliente cli = new pptCliente();

                try
                {
                    conn.Open();
                    cli = new pptCliente();
                    cli.Processo = new pptProcesso();
                    cli.Processo.VlTotal = cmd.ExecuteScalar().ToString();

                }
                catch (Exception)
                {
                    conn.Close();
                }

                return cli.Processo.VlTotal;
            }
        }

        public List<pptCliente> GetListaProcSetembro2007()
        {
            string sql = "SELECT NrProcesso FROM tbProcesso " +
                         "WHERE(SELECT DATEPART(MONTH, DtProcesso)) = 9 " +
                         "and(SELECT DATEPART(YEAR, DtProcesso)) = 2007";

            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<pptCliente> list = new List<pptCliente>();
                pptCliente pCli = null;

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            pCli = new pptCliente();
                            pCli.Processo = new pptProcesso();
                            pCli.Processo.NrProcesso = reader["NrProcesso"].ToString();
                            list.Add(pCli);
                        }
                    }
                }
                catch (Exception e)
                {
                    conn.Close();
                    throw e;
                }

                return list;
            }
        }

        public List<pptCliente> GetClienteProcessoMesmoEstado()
        {
            string sql = "SELECT c.Cliente, c.Estado, p.NrProcesso From tbCliente  c " +
                         "INNER JOIN tbProcesso p ON p.IdCliente = c.IdCliente " +
                         "WHERE c.Estado = p.EstadoProcesso Order By p.NrProcesso";

            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<pptCliente> list = new List<pptCliente>();
                pptCliente pCli = null;

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            pCli = new pptCliente();
                            pCli.Processo = new pptProcesso();
                            pCli.Processo.NrProcesso = reader["NrProcesso"].ToString();
                            pCli.Cliente = reader["Cliente"].ToString();
                            pCli.Estado = reader["Estado"].ToString();
                            list.Add(pCli);
                        }
                    }
                }
                catch (Exception e)
                {
                    conn.Close();
                    throw e;
                }

                return list;
            }
        }

        public List<pptCliente> GetProcessosSiglaTRAB()
        {

            string sql = "Select c.Cliente, p.NrProcesso From tbCliente  c " +
                         "INNER JOIN tbProcesso p ON p.IdCliente = c.IdCliente " +
                         "WHERE p.NrProcesso LIKE '%TRAB%'";

            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<pptCliente> list = new List<pptCliente>();
                pptCliente pCli = null;

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            pCli = new pptCliente();
                            pCli.Processo = new pptProcesso();
                            pCli.Processo.NrProcesso = reader["NrProcesso"].ToString();
                            pCli.Cliente = reader["Cliente"].ToString();
                            list.Add(pCli);
                        }
                    }
                }
                catch (Exception e)
                {
                    conn.Close();
                    throw e;
                }

                return list;
            }

        }
    }
}