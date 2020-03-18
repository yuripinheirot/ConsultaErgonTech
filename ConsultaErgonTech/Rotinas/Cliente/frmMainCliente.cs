using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultaErgonTech.Main;

namespace ConsultaErgonTech.Rotinas.Cliente
{
    public partial class frmMainCliente : Form
    {
        //inicializadores
        frmMain main;

        //metodos
        void atualizaDgv()
        {
            try
            {
                dataCliente.AtualizaDgv(dgvCliente, tbxPalavraChave.Text);
                lblCLiente.Text = "Clientes encontrados: " + dgvCliente.RowCount;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        //inicializadores
        public frmMainCliente(frmMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void frmMainCliente_Load(object sender, EventArgs e)
        {
            atualizaDgv();
        }

        private void tbxPalavraChave_TextChanged(object sender, EventArgs e)
        {
            atualizaDgv();
        }

        private void tbxPalavraChave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    bunifuFlatButton1_Click(sender, e);
                }

                if (dgvCliente.Focused == false)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        int i = dgvCliente.CurrentRow.Index - 1;
                        dgvCliente.CurrentCell = dgvCliente.Rows[i].Cells[0];
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        int i = dgvCliente.CurrentRow.Index + 1;
                        dgvCliente.CurrentCell = dgvCliente.Rows[i].Cells[0];
                    }
                }
            }
            catch
            {
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            main.tbxIdClientePed.Text = dgvCliente.CurrentRow.Cells[0].Value.ToString();
            main.tbxNomeClientePed.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
            Close();
        }

        private void frmMainCliente_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
