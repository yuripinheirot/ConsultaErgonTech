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

namespace ConsultaErgonTech.Main
{
    class dataMain
    {

        public static string server = Properties.Settings.Default.sqlserver;
        public static SqlConnection conexao = null;

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

    }
}
