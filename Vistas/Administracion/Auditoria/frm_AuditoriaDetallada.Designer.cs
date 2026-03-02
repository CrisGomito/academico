namespace DataBase_First.Views.Administracion.Auditoria
{
    partial class frm_AuditoriaDetallada
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlCabecera = new Panel();
            btnCerrar = new Button();
            lblTitulo = new Label();
            pnlContenedorCentral = new Panel();
            dgvAuditoria = new DataGridView();
            pnlBuscador = new Panel();
            txtBuscar = new TextBox();
            iconBuscar = new FontAwesome.Sharp.IconPictureBox();
            tmrAutoRefresh = new System.Windows.Forms.Timer(components);
            pnlCabecera.SuspendLayout();
            pnlContenedorCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconBuscar).BeginInit();
            SuspendLayout();
            // 
            // pnlCabecera
            // 
            pnlCabecera.BackColor = Color.White;
            pnlCabecera.Controls.Add(btnCerrar);
            pnlCabecera.Controls.Add(lblTitulo);
            pnlCabecera.Dock = DockStyle.Top;
            pnlCabecera.Location = new Point(0, 0);
            pnlCabecera.Name = "pnlCabecera";
            pnlCabecera.Size = new Size(950, 50);
            pnlCabecera.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(915, 15);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(20, 20);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            btnCerrar.Paint += btnCerrar_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(950, 50);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "AUDITORÍA DETALLADA Y LOGINS - AÑO ACTUAL";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContenedorCentral
            // 
            pnlContenedorCentral.BackColor = Color.FromArgb(240, 243, 246);
            pnlContenedorCentral.Controls.Add(dgvAuditoria);
            pnlContenedorCentral.Controls.Add(pnlBuscador);
            pnlContenedorCentral.Dock = DockStyle.Fill;
            pnlContenedorCentral.Location = new Point(0, 50);
            pnlContenedorCentral.Name = "pnlContenedorCentral";
            pnlContenedorCentral.Padding = new Padding(30);
            pnlContenedorCentral.Size = new Size(950, 550);
            pnlContenedorCentral.TabIndex = 1;
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.AllowUserToDeleteRows = false;
            dgvAuditoria.AllowUserToResizeRows = false;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditoria.BackgroundColor = Color.White;
            dgvAuditoria.BorderStyle = BorderStyle.None;
            dgvAuditoria.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuditoria.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dgvAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAuditoria.ColumnHeadersHeight = 40;
            dgvAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAuditoria.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAuditoria.Dock = DockStyle.Fill;
            dgvAuditoria.EnableHeadersVisualStyles = false;
            dgvAuditoria.Location = new Point(30, 75);
            dgvAuditoria.MultiSelect = false;
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.RowHeadersVisible = false;
            dgvAuditoria.RowTemplate.Height = 35;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.Size = new Size(890, 445);
            dgvAuditoria.TabIndex = 1;
            // 
            // pnlBuscador
            // 
            pnlBuscador.BackColor = Color.White;
            pnlBuscador.Controls.Add(txtBuscar);
            pnlBuscador.Controls.Add(iconBuscar);
            pnlBuscador.Dock = DockStyle.Top;
            pnlBuscador.Location = new Point(30, 30);
            pnlBuscador.Name = "pnlBuscador";
            pnlBuscador.Size = new Size(890, 45);
            pnlBuscador.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Segoe UI", 12F);
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Location = new Point(50, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(800, 22);
            txtBuscar.TabIndex = 0;
            txtBuscar.Text = "Buscar por usuario, acción, tabla o valores cambiados...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            txtBuscar.Enter += txtBuscar_Enter;
            txtBuscar.Leave += txtBuscar_Leave;
            // 
            // iconBuscar
            // 
            iconBuscar.BackColor = Color.White;
            iconBuscar.ForeColor = Color.Gray;
            iconBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconBuscar.IconColor = Color.Gray;
            iconBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconBuscar.IconSize = 25;
            iconBuscar.Location = new Point(15, 10);
            iconBuscar.Name = "iconBuscar";
            iconBuscar.Size = new Size(25, 25);
            iconBuscar.TabIndex = 1;
            iconBuscar.TabStop = false;
            // 
            // frm_AuditoriaDetallada
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 246);
            ClientSize = new Size(950, 600);
            Controls.Add(pnlContenedorCentral);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_AuditoriaDetallada";
            Text = "Auditoría Detallada";
            Load += frm_AuditoriaDetallada_Load;
            pnlCabecera.ResumeLayout(false);
            pnlContenedorCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).EndInit();
            pnlBuscador.ResumeLayout(false);
            pnlBuscador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconBuscar).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorCentral;
        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.TextBox txtBuscar;
        private FontAwesome.Sharp.IconPictureBox iconBuscar;
        private System.Windows.Forms.DataGridView dgvAuditoria;
        private System.Windows.Forms.Timer tmrAutoRefresh;
    }
}