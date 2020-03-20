using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaErgonTech.Rotinas.Grupo
{
    public partial class frmMainGrupo : Form
    {
        Main.frmMain main;

        void atualizaDgv()
        {
            dataGrupo.AtualizaDgvGrupo(dgvGrupo, tbxPalavraChave.Text);
            lblGrupos.Text = "Grupos encontrados: " + dgvGrupo.RowCount;
        }

        public frmMainGrupo(Main.frmMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void frmMainGrupo_Load(object sender, EventArgs e)
        {
            atualizaDgv();
        }

        private void tbxPalavraChave_TextChanged(object sender, EventArgs e)
        {
            atualizaDgv();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(main.tbxGrupoEst.Text))
            {
                main.tbxGrupoEst.Text = dgvGrupo.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                main.tbxGrupoEst.Text += "," + dgvGrupo.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void tbxPalavraChave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnInserir_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }

                if (dgvGrupo.Focused == false)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        int i = dgvGrupo.CurrentRow.Index - 1;
                        dgvGrupo.CurrentCell = dgvGrupo.Rows[i].Cells[0];
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        int i = dgvGrupo.CurrentRow.Index + 1;
                        dgvGrupo.CurrentCell = dgvGrupo.Rows[i].Cells[0];
                    }
                }
            }
            catch
            {
            }
        }
    }
}
