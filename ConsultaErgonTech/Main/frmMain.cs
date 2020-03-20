using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;

namespace ConsultaErgonTech.Main
{
    public partial class frmMain : Form
    {
        //METODODS
        void atualizaDgvPedidos()
        {
            //string dti = Convert.ToDateTime(tbxDtiPed.Text).ToString("yyyy-MM-dd");
            //string dtf = Convert.ToDateTime(tbxDtfPed.Text).ToString("yyyy-MM-dd");
            string dti = Convert.ToDateTime(tbxDtiPed.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string dtf = Convert.ToDateTime(tbxDtfPed.Value.ToShortDateString()).ToString("yyyy-MM-dd");

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
        void atualizaDgvProdutos()
        {
            string grupo()
            {
                if (tbxGrupoEst.Text.Contains(","))
                {
                    return $" and grp.codigo in ({tbxGrupoEst.Text.Substring(0, tbxGrupoEst.Text.Length - 1)})";
                }
                else if (string.IsNullOrWhiteSpace(tbxGrupoEst.Text))
                {
                    return "";
                }
                else
                {
                    return $" and grp.codigo = " + tbxGrupoEst.Text;
                }
            }
            string fornecedor()
            {
                if (string.IsNullOrWhiteSpace(tbxIdFornecedor.Text))
                {
                    return null;
                }
                else
                {
                    return " and nfe.cliente = " + tbxIdFornecedor.Text;
                }
            }

            string dti = tbxDtiEst.Value.ToShortDateString();
            string dtf = tbxDtfEst.Value.ToShortDateString();
            //string dti = Convert.ToDateTime(tbxDtiEst.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            //string dtf = Convert.ToDateTime(tbxDtfEst.Value.ToShortDateString()).ToString("yyyy-MM-dd");

            dataMain.AtualizaDgvCompra(dgvCompras, grupo(), fornecedor(), dti, dtf,report1);
            lblCompras.Text = "Compras encontradas: " + dgvCompras.RowCount;

            if (dgvCompras.RowCount == 0)
            {
                MessageBox.Show("Nenhum registro encontrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dataMain.estoqueEco(dgvCompras,progressBar);
            }
        }

        //INCIIALIZADORES
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            metroTabControl.SelectedTab = tabPedidos;
        }


        //PEDIDOS
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

        //ESTOQUE
        private void tbxGrupoEst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Rotinas.Grupo.frmMainGrupo grupo = new Rotinas.Grupo.frmMainGrupo(this);
                grupo.ShowDialog();
            }
        }

        private void btnPesquisarEst_Click(object sender, EventArgs e)
        {
            atualizaDgvProdutos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            report1.RegisterData(dsMain, "compras");
            report1.Show();
        }
    }
}
