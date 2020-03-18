namespace ConsultaErgonTech.Rotinas.Cliente
{
    partial class frmMainCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainCliente));
            this.dgvCliente = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpfCnpjDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCliente = new ConsultaErgonTech.Rotinas.Cliente.dsCliente();
            this.lblCLiente = new MetroFramework.Controls.MetroLabel();
            this.tbxPalavraChave = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnInserir = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCliente
            // 
            this.dgvCliente.AllowUserToAddRows = false;
            this.dgvCliente.AllowUserToDeleteRows = false;
            this.dgvCliente.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCliente.AutoGenerateColumns = false;
            this.dgvCliente.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.clienteDataGridViewTextBoxColumn,
            this.foneDataGridViewTextBoxColumn,
            this.celularDataGridViewTextBoxColumn,
            this.cpfCnpjDataGridViewTextBoxColumn});
            this.dgvCliente.DataSource = this.clienteBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCliente.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCliente.DoubleBuffered = true;
            this.dgvCliente.EnableHeadersVisualStyles = false;
            this.dgvCliente.GridColor = System.Drawing.Color.Black;
            this.dgvCliente.HeaderBgColor = System.Drawing.Color.Teal;
            this.dgvCliente.HeaderForeColor = System.Drawing.Color.White;
            this.dgvCliente.Location = new System.Drawing.Point(12, 31);
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.ReadOnly = true;
            this.dgvCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCliente.RowHeadersWidth = 20;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCliente.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCliente.Size = new System.Drawing.Size(654, 265);
            this.dgvCliente.TabIndex = 2;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "codigo";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.codigoDataGridViewTextBoxColumn.HeaderText = "ID";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 65;
            // 
            // clienteDataGridViewTextBoxColumn
            // 
            this.clienteDataGridViewTextBoxColumn.DataPropertyName = "cliente";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.clienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.clienteDataGridViewTextBoxColumn.Name = "clienteDataGridViewTextBoxColumn";
            this.clienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDataGridViewTextBoxColumn.Width = 225;
            // 
            // foneDataGridViewTextBoxColumn
            // 
            this.foneDataGridViewTextBoxColumn.DataPropertyName = "fone";
            this.foneDataGridViewTextBoxColumn.HeaderText = "Fone";
            this.foneDataGridViewTextBoxColumn.Name = "foneDataGridViewTextBoxColumn";
            this.foneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // celularDataGridViewTextBoxColumn
            // 
            this.celularDataGridViewTextBoxColumn.DataPropertyName = "celular";
            this.celularDataGridViewTextBoxColumn.HeaderText = "Celular";
            this.celularDataGridViewTextBoxColumn.Name = "celularDataGridViewTextBoxColumn";
            this.celularDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cpfCnpjDataGridViewTextBoxColumn
            // 
            this.cpfCnpjDataGridViewTextBoxColumn.DataPropertyName = "cpfCnpj";
            this.cpfCnpjDataGridViewTextBoxColumn.HeaderText = "CPF/CNPJ";
            this.cpfCnpjDataGridViewTextBoxColumn.Name = "cpfCnpjDataGridViewTextBoxColumn";
            this.cpfCnpjDataGridViewTextBoxColumn.ReadOnly = true;
            this.cpfCnpjDataGridViewTextBoxColumn.Width = 125;
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "cliente";
            this.clienteBindingSource.DataSource = this.dsCliente;
            // 
            // dsCliente
            // 
            this.dsCliente.DataSetName = "dsCliente";
            this.dsCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblCLiente
            // 
            this.lblCLiente.AutoSize = true;
            this.lblCLiente.BackColor = System.Drawing.SystemColors.Control;
            this.lblCLiente.Location = new System.Drawing.Point(8, 9);
            this.lblCLiente.Name = "lblCLiente";
            this.lblCLiente.Size = new System.Drawing.Size(144, 19);
            this.lblCLiente.TabIndex = 1;
            this.lblCLiente.Text = "Clientes encontrados: 0";
            // 
            // tbxPalavraChave
            // 
            // 
            // 
            // 
            this.tbxPalavraChave.CustomButton.Image = null;
            this.tbxPalavraChave.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.tbxPalavraChave.CustomButton.Name = "";
            this.tbxPalavraChave.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbxPalavraChave.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxPalavraChave.CustomButton.TabIndex = 1;
            this.tbxPalavraChave.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxPalavraChave.CustomButton.UseSelectable = true;
            this.tbxPalavraChave.CustomButton.Visible = false;
            this.tbxPalavraChave.Lines = new string[0];
            this.tbxPalavraChave.Location = new System.Drawing.Point(12, 334);
            this.tbxPalavraChave.MaxLength = 32767;
            this.tbxPalavraChave.Name = "tbxPalavraChave";
            this.tbxPalavraChave.PasswordChar = '\0';
            this.tbxPalavraChave.PromptText = "Palavra chave";
            this.tbxPalavraChave.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxPalavraChave.SelectedText = "";
            this.tbxPalavraChave.SelectionLength = 0;
            this.tbxPalavraChave.SelectionStart = 0;
            this.tbxPalavraChave.ShortcutsEnabled = true;
            this.tbxPalavraChave.Size = new System.Drawing.Size(217, 23);
            this.tbxPalavraChave.TabIndex = 0;
            this.tbxPalavraChave.UseSelectable = true;
            this.tbxPalavraChave.WaterMark = "Palavra chave";
            this.tbxPalavraChave.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxPalavraChave.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbxPalavraChave.TextChanged += new System.EventHandler(this.tbxPalavraChave_TextChanged);
            this.tbxPalavraChave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPalavraChave_KeyDown);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(8, 316);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 15);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Pesquisar por:";
            // 
            // btnInserir
            // 
            this.btnInserir.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnInserir.BackColor = System.Drawing.Color.Teal;
            this.btnInserir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInserir.BorderRadius = 0;
            this.btnInserir.ButtonText = "&Inserir";
            this.btnInserir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInserir.DisabledColor = System.Drawing.Color.Gray;
            this.btnInserir.Iconcolor = System.Drawing.Color.Transparent;
            this.btnInserir.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnInserir.Iconimage")));
            this.btnInserir.Iconimage_right = null;
            this.btnInserir.Iconimage_right_Selected = null;
            this.btnInserir.Iconimage_Selected = null;
            this.btnInserir.IconMarginLeft = 0;
            this.btnInserir.IconMarginRight = 0;
            this.btnInserir.IconRightVisible = true;
            this.btnInserir.IconRightZoom = 0D;
            this.btnInserir.IconVisible = true;
            this.btnInserir.IconZoom = 85D;
            this.btnInserir.IsTab = false;
            this.btnInserir.Location = new System.Drawing.Point(567, 329);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Normalcolor = System.Drawing.Color.Teal;
            this.btnInserir.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnInserir.OnHoverTextColor = System.Drawing.Color.White;
            this.btnInserir.selected = false;
            this.btnInserir.Size = new System.Drawing.Size(99, 28);
            this.btnInserir.TabIndex = 1;
            this.btnInserir.Text = "&Inserir";
            this.btnInserir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInserir.Textcolor = System.Drawing.Color.White;
            this.btnInserir.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // frmMainCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(678, 368);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.tbxPalavraChave);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblCLiente);
            this.Controls.Add(this.dgvCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainCliente";
            this.ShowIcon = false;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frmMainCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainCliente_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvCliente;
        private MetroFramework.Controls.MetroLabel lblCLiente;
        private MetroFramework.Controls.MetroTextBox tbxPalavraChave;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private Bunifu.Framework.UI.BunifuFlatButton btnInserir;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn celularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpfCnpjDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private dsCliente dsCliente;
    }
}