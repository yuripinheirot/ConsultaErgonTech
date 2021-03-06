﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultaErgonTech.Main;

namespace ConsultaErgonTech.Rotinas.Fornecedor
{
    public partial class frmMainFornecedor : Form
    {
        //instancias
        frmMain main;
        //metodos
        void atualizaDgv()
        {
            dataFornecedor.AtualizaDgv(dgvFornecedor, tbxPalavraChave.Text);
            lblFornecedores.Text = "Fornecedores encontrados: " + dgvFornecedor.RowCount;
        }

        public frmMainFornecedor(frmMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void frmMainFornecedor_Load(object sender, EventArgs e)
        {
            atualizaDgv();
        }

        private void tbxPalavraChave_TextChanged(object sender, EventArgs e)
        {
            atualizaDgv();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            main.tbxIdFornecedor.Text = dgvFornecedor.CurrentRow.Cells[0].Value.ToString();
            main.tbxNomeFornecedor.Text = dgvFornecedor.CurrentRow.Cells[1].Value.ToString();
            Close();
        }

        private void tbxPalavraChave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnInserir_Click(sender, e);
                }

                if (dgvFornecedor.Focused == false)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        int i = dgvFornecedor.CurrentRow.Index - 1;
                        dgvFornecedor.CurrentCell = dgvFornecedor.Rows[i].Cells[0];
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        int i = dgvFornecedor.CurrentRow.Index + 1;
                        dgvFornecedor.CurrentCell = dgvFornecedor.Rows[i].Cells[0];
                    }
                }
            }
            catch
            {
            }
        }
    }
}
