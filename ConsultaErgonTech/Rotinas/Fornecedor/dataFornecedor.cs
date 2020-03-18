using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace ConsultaErgonTech.Rotinas.Fornecedor
{
    class dataFornecedor
    {
        public static string server = Properties.Settings.Default.sqlserver;
        public static SqlConnection conexao = null;

        public static void AtualizaDgv(BunifuCustomDataGrid dgv, string PalavraChave)
        {
            try
            {
                conexao = new SqlConnection(server);
                conexao.Open();
                string query =
                    "select                                                   " +
                    "codigo COD,                                              " +
                    "descricao as RAZAO,                                      " +
                    "fantasia AS FANTASIA,                                    " +
                    "a.[Cgc ou Cpf] as CPFCNPJ,                               " +
                    "fone AS TELEFONE,                                        " +
                    "IIF(uf IS NULL, '', UF) AS UF                            " +
                    "from Fornecedor a                                        " +
                    "where fantasia like '%" + PalavraChave + "%';";
                SqlCommand cmd = new SqlCommand(query, conexao);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
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