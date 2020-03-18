using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaErgonTech.Main
{
    public partial class frmMain : Form
    {
        //metodods
        void atualizaDgvPedidos()
        {
            string dti = Convert.ToDateTime(tbxDtiPed.Text).ToString("yyyy-MM-dd");
            string dtf = Convert.ToDateTime(tbxDtfPed.Text).ToString("yyyy-MM-dd");
            string idCliente()
            {
                if (string.IsNullOrWhiteSpace(tbxIdClientePed.Text))
                {
                    return null;
                }
                else
                {
                    return "and cli.codigo = " + tbxIdClientePed.Text;
                }
            }

            dataMain.AtualizaDgvPedido(dgvPedidos, idCliente(), dti, dtf);
            lblPedEncontrado.Text = "Pedidos encontrados: " + dgvPedidos.RowCount;

            if (dgvPedidos.RowCount == 0)
            {
                MessageBox.Show("Nenhum registro encontrado.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisarPed_Click(object sender, EventArgs e)
        {
            atualizaDgvPedidos();
        }

        private void tbxIdClientePed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Rotinas.Cliente.frmMainCliente cliente = new Rotinas.Cliente.frmMainCliente(this);
                cliente.ShowDialog();
            }
        }

        private void dgvPedidos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataMain.AtualizaDgvPedProduto(dgvProdutos, dgvPedidos.CurrentRow.Cells[0].Value.ToString());
        }

        private void tabPedidos_SizeChanged(object sender, EventArgs e)
        {
            dgvPedidos.Columns[1].Width = dgvPedidos.Width - 692;
            dgvProdutos.Columns[1].Width = dgvPedidos.Width - 638;
        }

        private void tbxIfFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Rotinas.Fornecedor.frmMainFornecedor mainFornecedor = new Rotinas.Fornecedor.frmMainFornecedor(this);
                mainFornecedor.ShowDialog();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }
    }
}
