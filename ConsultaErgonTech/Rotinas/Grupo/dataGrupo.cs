using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace ConsultaErgonTech.Rotinas.Grupo
{
    class dataGrupo
    {
        public static string server = Properties.Settings.Default.sqlserver;
        public static SqlConnection conexao = null;

        public static void AtualizaDgvGrupo(BunifuCustomDataGrid dgv, string PalavraChave)
        {
            try
            {
                conexao = new SqlConnection(server);
                conexao.Open();
                string query = "select a.codigo, a.Descricao from GrupoProdutos a where a.Descricao like '%" + PalavraChave + "%' order by codigo asc;";
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
