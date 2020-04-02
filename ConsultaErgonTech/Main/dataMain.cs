using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Bunifu.Framework.UI;
using System.IO;

namespace ConsultaErgonTech.Main
{
    class dataMain
    {
        static SqlConnection conexao = null;
        static string server = Properties.Settings.Default.sqlserver;

        //PEDIDOS
        public static void AtualizaDgvPedido(BunifuCustomDataGrid dgv, string idCliente, string dti, string dtf)
        {
            try
            {
                conexao = new SqlConnection(server);
                conexao.Open();
                string query =
                    "select                                                               " +
                    "vnd.codigo,                                                          " +
                    "vnd.data as DataCadastro,                                            " +
                    "vdd.Descricao as vendedor,                                           " +
                    "vnd.TotalVenda,                                                      " +
                    "nfe.NumeroNF,                                                        " +
                    "nfe.NFeNumero,                                                       " +
                    "CONCAT(cli.Codigo,'-',cli.Descricao) as Cliente,                     " +
                    "vnd.Usuario                                                          " +
                    "from vendas vnd                                                      " +
                    "left outer join planos pla on (vnd.CondicoesPagamento = pla.Codigo)  " +
                    "left outer join clientes cli on (vnd.Cliente = cli.Codigo)           " +
                    "left outer join Vendedor vdd on (vnd.Vendedor = vdd.Codigo)          " +
                    "left outer join NotasFiscaisPropria  nfe on (vnd.Codigo = nfe.Venda )" +
                    "where cast(vnd.data as date) between @dti and @dtf                   " + idCliente +
                    "order by vnd.data,cli.Descricao desc                                 ";
                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@dti", dti);
                cmd.Parameters.AddWithValue("@dtf", dtf);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                dgv.DataSource = table;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }

        }

        public static void AtualizaDgvPedProduto(BunifuCustomDataGrid dgv, string idPedido)
        {
            try
            {
                conexao = new SqlConnection(server);
                conexao.Open();
                string query =
                    "select                                                                                   " +
                    "ivd.produto,                                                                             " +
                    "ivd.descricao,                                                                           " +
                    "ivd.numero,                                                                              " +
                    "ivd.qtd as quantidade,                                                                   " +
                    "cast(ivd.PrecoVenda as numeric(18,2)) as PrecoUnitario,                                  " +
                    "ivd.DescontoGeral$,                                                                      " +
                    "cast(((ivd.precovenda * ivd.qtd) - ivd.DescontoGeral$) as numeric(18,2)) as TotalLiquido " +
                    "from ItemsVenda ivd                                                                      " +
                    "inner join Vendas vda on (ivd.Codigo = vda.Codigo)                                       " +
                    "where vda.codigo = @codigo                                                               " +
                    "order by vda.codigo desc                                                                 ";

                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@codigo", idPedido);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                dgv.DataSource = table;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }

        }

        //ESTOQUE
        public static void AtualizaDgvCompra(BunifuCustomDataGrid dgv, string grupo, string fornecedor, string dti, string dtf, FastReport.Report rpt)
        {
            try
            {
                conexao = new SqlConnection(server);
                conexao.Open();
                string query =
                    "select	distinct                        									    " +
                    "																			    " +
                    "pdt.codigo as codProduto,                                                      " +
                    "pdt.Descricao as descProduto,                                                  " +
                    "pdt.Numero,                                                                    " +
                    "pdt.Numero1,                                                                   " +
                    "pdt.Numero2,                                                                   " +
                    "pdt.Numero3,                                                                   " +
                    "pdt.Numero4,                                                                   " +
                    "pdt.RefFornecedor,                                                             " +
                    "'' as estoqueEco,                                                              " +
                    "                                                                               " +
                    "(SELECT                                                                        " +
                    "sum(a.Qtd)                                                                     " +
                    "from ItemsVenda a                                                              " +
                    "left outer join vendas b on (a.Codigo  = b.Codigo )                            " +
                    "where                                                                          " +
                    "b.[Data] between @dti and @dtf                                                 " +
                    "and a.Produto  = pdt.Codigo                                                    " +
                    "and a.Cancelada  = 0) as qtdVendida,                                           " +
                    "                                                                               " +
                    "pdt.PrecoCompra,                                                               " +
                    "pdt.PrecoVenda,                                                                " +
                    "                                                                               " +
                    "(select top 1                                                                  " +
                    "nfe.Cliente                                                                    " +
                    "from NFItemsEntrada nie                                                        " +
                    "left outer join NotasFiscaisEntrada nfe on (nie.NumeroNF = nfe.NumeroNF and    " +
                    "                                            nie.Modelo = nfe.Modelo and        " +
                    "											nie.Serie = nfe.Serie)              " +
                    "where                                                                          " +
                   $"nie.Produto = pdt.Codigo {fornecedor}                                          " +
                    "order by nfe.DataLanc desc) as fornecedor,                                     " +
                    "                                                                               " +
                    "(select top 1                                                                  " +
                    "cast(nfe.DataLanc as date) as DataLanc                                         " +
                    "from NFItemsEntrada nie                                                        " +
                    "left outer join NotasFiscaisEntrada nfe on (nie.NumeroNF = nfe.NumeroNF and    " +
                    "                                            nie.Modelo = nfe.Modelo and        " +
                    "											nie.Serie = nfe.Serie)              " +
                    "where                                                                          " +
                   $"nie.Produto = pdt.Codigo {fornecedor}                                          " +
                    "order by nfe.DataLanc desc) as DataUltimaCompra,                               " +
                    "                                                                               " +
                    "(select top 1                                                                  " +
                    "nie.Qtd                                                                        " +
                    "from NFItemsEntrada nie                                                        " +
                    "left outer join NotasFiscaisEntrada nfe on (nie.NumeroNF = nfe.NumeroNF and    " +
                    "                                            nie.Modelo = nfe.Modelo and        " +
                    "											nie.Serie = nfe.Serie)              " +
                    "where                                                                          " +
                   $"nie.Produto = pdt.Codigo   {fornecedor}                                        " +
                    "order by nfe.DataLanc desc) as qtdUltimaEnt,                                   " +
                    "                                                                               " +
                    "(select top 1                                                                  " +
                    "cast(a.Data as date)                                                           " +
                    "from Vendas a                                                                  " +
                    "inner join ItemsVenda b on (a.Codigo = b.Codigo)                               " +
                    "where b.Produto = pdt.Codigo                                                   " +
                    "order by a.Data desc) as DataUltimaVenda,                                      " +
                    "                                                                               " +
                    "grp.Codigo as codGrupo,                                                        " +
                    "grp.Descricao as descGrupo                                                     " +
                    "																			    " +
                    "                                                                               " +
                    "from produtos pdt                                                              " +
                    "left outer join NFItemsEntrada nie on (pdt.Codigo = nie.Produto)               " +
                    "left outer join NotasFiscaisEntrada nfe on (nie.NumeroNF = nfe.NumeroNF and    " +
                    "                                            nie.Modelo = nfe.Modelo and        " +
                    "											nie.Serie = nfe.Serie)              " +
                    "left outer join ItemsVenda ivd on (pdt.Codigo = ivd.Codigo)	                " +
                    "left outer join Fornecedor fcd on (nfe.Cliente = fcd.Codigo)                   " +
                    "left outer join GrupoProdutos grp on (pdt.Grupo = grp.codigo)                  " +
                    "WHERE                                                                          " +
                    "nfe.DataLanc between @dti and @dtf                                             " + 
                    grupo + fornecedor;

                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@dti", dti);
                cmd.Parameters.AddWithValue("@dtf", dtf);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                

                dgv.DataSource = table;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }

        }

        public async static void estoqueEco(BunifuCustomDataGrid dgv, BunifuProgressBar pbr)
        {
            try
            {
                string codigos = "";
                dgv.Rows.Cast<DataGridViewRow>().ToList().ForEach(p => codigos += p.Cells[0].Value.ToString() + ",");
                codigos = codigos.Substring(0, codigos.Length - 1);
                List<KeyValuePair<string, string>> pdtEstoque = new List<KeyValuePair<string, string>>();
                codigos.Replace(" ", "");

                FbConnection conexao = new FbConnection(Properties.Settings.Default.firebird);
                conexao.Open();
                string query = "select cast(a.produto as int) as produto,(A.ESTDISPONIVEL + A.ESTRESERVADO + A.ESTCONDICIONAL) as ESTECO from TESTESTOQUE A where cast(A.PRODUTO as int) in (" + codigos + ") group by 1,2;";
                FbCommand cmd = new FbCommand(query, conexao);
                FbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pdtEstoque.Add(new KeyValuePair<string, string>(reader["produto"].ToString(), reader["esteco"].ToString()));
                }
                conexao.Close();

                await Task.Run(() =>
                {
                    pbr.MaximumValue = dgv.RowCount;
                    pbr.Visible = true;

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        foreach (KeyValuePair<string, string> key in pdtEstoque)
                        {
                            if (row.Cells[0].Value.ToString() == key.Key)
                            {
                                row.Cells["estoqueEcoDataGridViewTextBoxColumn"].Value = key.Value;
                            }
                        }

                        pbr.Value++;
                    }

                    pbr.Visible = false;
                    pbr.Value = 0;
                });


            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }

        //ORCAMENTO
        public static void AtualizaDgvOrcamento(BunifuCustomDataGrid dgv, string idCliente,string status, string dti, string dtf)
        {
            try
            {
                conexao = new SqlConnection(server);
                conexao.Open();
                string query =
                    "SELECT                                                       " +
                    "orc.codigo,                                                  " +
                    "cast(orc.[Data] as date) as data,                            " +
                    "concat(orc.Cliente,'-',clt.Descricao ) as cliente,           " +
                    "vdd.Descricao as vendedor,                                   " +
                    "orc.Obs ,                                                    " +
                    "orc.Descontos ,                                              " +
                    "orc.TotalVenda ,                                             " +
                    "orc.Comprador ,                                              " +
                    "case                                                         " +
                    "when orc.Fechada = 0 then 'NÃO' else 'SIM'                   " +
                    "end as fechada                                               " +
                    "from orcamento orc                                           " +
                    "left outer join clientes clt on (orc.Cliente = clt.Codigo)   " +
                    "left outer join Vendedor vdd on (orc.Vendedor = vdd.Codigo ) " +
                    "left outer join Planos pag on (orc.Plano = pag.Codigo )      " +
                    "WHERE                                                        " +
                    "cast(orc.[Data] as date) between @dti and @dtf               " + idCliente + status +
                    "order by orc.[Data] desc                                     ";
                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@dti", dti);
                cmd.Parameters.AddWithValue("@dtf", dtf);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                dgv.DataSource = table;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }

        }

        public static void AtualizaDgvOrcProduto(BunifuCustomDataGrid dgv, string idPedido)
        {
            try
            {
                conexao = new SqlConnection(server);
                conexao.Open();
                string query =
                    "SELECT                                                    " +
                    "pdt.Codigo,                                               " +
                    "ior.descricao as  produto,                                " +
                    "ior.Numero,                                               " +
                    "ior.Qtd as qtde,                                          " +
                    "ior.PrecoVenda ,                                          " +
                    "ior.Desconto$  as desconto                                " +
                    "FROM ItemsOrc ior                                         " +
                    "left outer join Orcamento orc on(ior.Codigo = orc.Codigo) " +
                    "left outer join Produtos pdt on(ior.Produto = pdt.Codigo) " +
                    "WHERE                                                     " +
                    "ior.Codigo = @codigo                                      ";

                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@codigo", idPedido);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                dgv.DataSource = table;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}
