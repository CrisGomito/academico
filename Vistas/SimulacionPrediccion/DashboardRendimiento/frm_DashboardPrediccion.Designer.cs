namespace DataBase_First.Views.Dashboard
{
    partial class frm_DashboardPrediccion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnCerrar = new Button();
            btnAnalizar = new Button();
            cmbAsignatura = new ComboBox();
            label3 = new Label();
            cmbPeriodo = new ComboBox();
            label2 = new Label();
            lblTitulo = new Label();
            pnlContadores = new Panel();
            pnlCardRiesgo = new Panel();
            lblRiesgo = new Label();
            label7 = new Label();
            pnlCardAprobados = new Panel();
            lblAprobados = new Label();
            label5 = new Label();
            pnlCardTotal = new Panel();
            lblTotalAlumnos = new Label();
            label4 = new Label();
            pnlGraficosContenedor = new Panel();
            pnlGraficoBarras = new Panel();
            pnlGraficoPastel = new Panel();
            dgvPrediccion = new DataGridView();
            pnlTop.SuspendLayout();
            pnlContadores.SuspendLayout();
            pnlCardRiesgo.SuspendLayout();
            pnlCardAprobados.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            pnlGraficosContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrediccion).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(btnCerrar);
            pnlTop.Controls.Add(btnAnalizar);
            pnlTop.Controls.Add(cmbAsignatura);
            pnlTop.Controls.Add(label3);
            pnlTop.Controls.Add(cmbPeriodo);
            pnlTop.Controls.Add(label2);
            pnlTop.Controls.Add(lblTitulo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1280, 127);
            pnlTop.TabIndex = 3;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(1241, 15);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(20, 20);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            btnCerrar.Paint += btnCerrar_Paint;
            // 
            // btnAnalizar
            // 
            btnAnalizar.BackColor = Color.FromArgb(230, 126, 34);
            btnAnalizar.FlatStyle = FlatStyle.Flat;
            btnAnalizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAnalizar.ForeColor = Color.White;
            btnAnalizar.Location = new Point(520, 78);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new Size(150, 32);
            btnAnalizar.TabIndex = 1;
            btnAnalizar.Text = "Analizar Datos";
            btnAnalizar.UseVisualStyleBackColor = false;
            btnAnalizar.Click += btnAnalizar_Click;
            // 
            // cmbAsignatura
            // 
            cmbAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAsignatura.Font = new Font("Segoe UI", 11F);
            cmbAsignatura.Location = new Point(244, 80);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new Size(250, 28);
            cmbAsignatura.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(240, 55);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 3;
            label3.Text = "Asignatura";
            // 
            // cmbPeriodo
            // 
            cmbPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodo.Font = new Font("Segoe UI", 11F);
            cmbPeriodo.Location = new Point(25, 80);
            cmbPeriodo.Name = "cmbPeriodo";
            cmbPeriodo.Size = new Size(200, 28);
            cmbPeriodo.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(21, 55);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 5;
            label2.Text = "Periodo";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(230, 126, 34);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 30);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "DASHBOARD DE PREDICCIÓN";
            // 
            // pnlContadores
            // 
            pnlContadores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlContadores.BackColor = Color.WhiteSmoke;
            pnlContadores.Controls.Add(pnlCardRiesgo);
            pnlContadores.Controls.Add(pnlCardAprobados);
            pnlContadores.Controls.Add(pnlCardTotal);
            pnlContadores.Location = new Point(0, 127);
            pnlContadores.Name = "pnlContadores";
            pnlContadores.Size = new Size(974, 120);
            pnlContadores.TabIndex = 2;
            // 
            // pnlCardRiesgo
            // 
            pnlCardRiesgo.BackColor = Color.FromArgb(231, 76, 60);
            pnlCardRiesgo.Controls.Add(lblRiesgo);
            pnlCardRiesgo.Controls.Add(label7);
            pnlCardRiesgo.Location = new Point(464, 20);
            pnlCardRiesgo.Name = "pnlCardRiesgo";
            pnlCardRiesgo.Size = new Size(227, 80);
            pnlCardRiesgo.TabIndex = 0;
            // 
            // lblRiesgo
            // 
            lblRiesgo.AutoSize = true;
            lblRiesgo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblRiesgo.ForeColor = Color.White;
            lblRiesgo.Location = new Point(10, 30);
            lblRiesgo.Name = "lblRiesgo";
            lblRiesgo.Size = new Size(38, 45);
            lblRiesgo.TabIndex = 0;
            lblRiesgo.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(10, 10);
            label7.Name = "label7";
            label7.Size = new Size(211, 25);
            label7.TabIndex = 1;
            label7.Text = "En Riesgo / Reprobados";
            // 
            // pnlCardAprobados
            // 
            pnlCardAprobados.BackColor = Color.FromArgb(39, 174, 96);
            pnlCardAprobados.Controls.Add(lblAprobados);
            pnlCardAprobados.Controls.Add(label5);
            pnlCardAprobados.Location = new Point(244, 20);
            pnlCardAprobados.Name = "pnlCardAprobados";
            pnlCardAprobados.Size = new Size(200, 80);
            pnlCardAprobados.TabIndex = 1;
            // 
            // lblAprobados
            // 
            lblAprobados.AutoSize = true;
            lblAprobados.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAprobados.ForeColor = Color.White;
            lblAprobados.Location = new Point(10, 30);
            lblAprobados.Name = "lblAprobados";
            lblAprobados.Size = new Size(38, 45);
            lblAprobados.TabIndex = 0;
            lblAprobados.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 10);
            label5.Name = "label5";
            label5.Size = new Size(166, 25);
            label5.TabIndex = 1;
            label5.Text = "Buen Rendimiento";
            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BackColor = Color.FromArgb(52, 152, 219);
            pnlCardTotal.Controls.Add(lblTotalAlumnos);
            pnlCardTotal.Controls.Add(label4);
            pnlCardTotal.Location = new Point(25, 20);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.Size = new Size(200, 80);
            pnlCardTotal.TabIndex = 2;
            // 
            // lblTotalAlumnos
            // 
            lblTotalAlumnos.AutoSize = true;
            lblTotalAlumnos.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalAlumnos.ForeColor = Color.White;
            lblTotalAlumnos.Location = new Point(10, 30);
            lblTotalAlumnos.Name = "lblTotalAlumnos";
            lblTotalAlumnos.Size = new Size(38, 45);
            lblTotalAlumnos.TabIndex = 0;
            lblTotalAlumnos.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(10, 10);
            label4.Name = "label4";
            label4.Size = new Size(122, 25);
            label4.TabIndex = 1;
            label4.Text = "Matriculados";
            // 
            // pnlGraficosContenedor
            // 
            pnlGraficosContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGraficosContenedor.Controls.Add(pnlGraficoBarras);
            pnlGraficosContenedor.Controls.Add(pnlGraficoPastel);
            pnlGraficosContenedor.Location = new Point(980, 127);
            pnlGraficosContenedor.Name = "pnlGraficosContenedor";
            pnlGraficosContenedor.Size = new Size(300, 463);
            pnlGraficosContenedor.TabIndex = 1;
            // 
            // pnlGraficoBarras
            // 
            pnlGraficoBarras.Dock = DockStyle.Fill;
            pnlGraficoBarras.Location = new Point(0, 225);
            pnlGraficoBarras.Name = "pnlGraficoBarras";
            pnlGraficoBarras.Size = new Size(300, 238);
            pnlGraficoBarras.TabIndex = 0;
            // 
            // pnlGraficoPastel
            // 
            pnlGraficoPastel.Dock = DockStyle.Top;
            pnlGraficoPastel.Location = new Point(0, 0);
            pnlGraficoPastel.Name = "pnlGraficoPastel";
            pnlGraficoPastel.Size = new Size(300, 225);
            pnlGraficoPastel.TabIndex = 1;
            // 
            // dgvPrediccion
            // 
            dgvPrediccion.AllowUserToAddRows = false;
            dgvPrediccion.AllowUserToDeleteRows = false;
            dgvPrediccion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvPrediccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrediccion.BackgroundColor = Color.White;
            dgvPrediccion.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 126, 34);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dgvPrediccion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPrediccion.EnableHeadersVisualStyles = false;
            dgvPrediccion.Location = new Point(-6, 247);
            dgvPrediccion.Name = "dgvPrediccion";
            dgvPrediccion.ReadOnly = true;
            dgvPrediccion.RowHeadersVisible = false;
            dgvPrediccion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrediccion.Size = new Size(980, 343);
            dgvPrediccion.TabIndex = 0;
            dgvPrediccion.CellFormatting += dgvPrediccion_CellFormatting;
            // 
            // frm_DashboardPrediccion
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 590);
            Controls.Add(dgvPrediccion);
            Controls.Add(pnlGraficosContenedor);
            Controls.Add(pnlContadores);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_DashboardPrediccion";
            Text = "Dashboard";
            Load += frm_DashboardPrediccion_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlContadores.ResumeLayout(false);
            pnlCardRiesgo.ResumeLayout(false);
            pnlCardRiesgo.PerformLayout();
            pnlCardAprobados.ResumeLayout(false);
            pnlCardAprobados.PerformLayout();
            pnlCardTotal.ResumeLayout(false);
            pnlCardTotal.PerformLayout();
            pnlGraficosContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPrediccion).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbAsignatura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContadores;
        private System.Windows.Forms.Panel pnlCardTotal;
        private System.Windows.Forms.Label lblTotalAlumnos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCardAprobados;
        private System.Windows.Forms.Label lblAprobados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlCardRiesgo;
        private System.Windows.Forms.Label lblRiesgo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlGraficosContenedor;
        private System.Windows.Forms.Panel pnlGraficoPastel;
        private System.Windows.Forms.Panel pnlGraficoBarras;
        private System.Windows.Forms.DataGridView dgvPrediccion;
    }
}