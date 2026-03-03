namespace DataBase_First.Views.Simulacion
{
    partial class frm_SimuladorNotas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEstudianteInfo = new System.Windows.Forms.Label();
            this.btnCargarMateria = new System.Windows.Forms.Button();
            this.cmbAsignatura = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvSimulador = new System.Windows.Forms.DataGridView();
            this.pnlResultados = new System.Windows.Forms.Panel();
            this.btnSimularFinal = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulador)).BeginInit();
            this.pnlResultados.SuspendLayout();
            this.SuspendLayout();

            // --- PANEL FILTROS ---
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.btnCerrar);
            this.pnlFiltros.Controls.Add(this.lblEstudianteInfo);
            this.pnlFiltros.Controls.Add(this.btnCargarMateria);
            this.pnlFiltros.Controls.Add(this.cmbAsignatura);
            this.pnlFiltros.Controls.Add(this.label3);
            this.pnlFiltros.Controls.Add(this.cmbPeriodo);
            this.pnlFiltros.Controls.Add(this.label2);
            this.pnlFiltros.Controls.Add(this.lblTitulo);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1024, 140);

            // btnCerrar (Rojo Circular)
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(985, 15);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.Paint += new System.Windows.Forms.PaintEventHandler(this.btnCerrar_Paint);

            // lblEstudianteInfo
            this.lblEstudianteInfo.AutoSize = true;
            this.lblEstudianteInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblEstudianteInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEstudianteInfo.Location = new System.Drawing.Point(360, 20);
            this.lblEstudianteInfo.Name = "lblEstudianteInfo";
            this.lblEstudianteInfo.Size = new System.Drawing.Size(168, 21);
            this.lblEstudianteInfo.Text = "Estudiante: Cargando...";

            // btnCargarMateria
            this.btnCargarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnCargarMateria.FlatAppearance.BorderSize = 0;
            this.btnCargarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarMateria.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCargarMateria.ForeColor = System.Drawing.Color.White;
            this.btnCargarMateria.Location = new System.Drawing.Point(630, 88);
            this.btnCargarMateria.Name = "btnCargarMateria";
            this.btnCargarMateria.Size = new System.Drawing.Size(150, 32);
            this.btnCargarMateria.Text = "Cargar Materia";
            this.btnCargarMateria.UseVisualStyleBackColor = false;
            this.btnCargarMateria.Click += new System.EventHandler(this.btnCargarMateria_Click);

            // cmbAsignatura
            this.cmbAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsignatura.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbAsignatura.FormattingEnabled = true;
            this.cmbAsignatura.Location = new System.Drawing.Point(304, 90);
            this.cmbAsignatura.Name = "cmbAsignatura";
            this.cmbAsignatura.Size = new System.Drawing.Size(300, 28);

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(300, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.Text = "Asignatura";

            // cmbPeriodo
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(25, 90);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(250, 28);
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(21, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.Text = "Periodo";

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(312, 30);
            this.lblTitulo.Text = "SIMULADOR DE PROMEDIOS";

            // --- DATA GRID VIEW ---
            this.dgvSimulador.AllowUserToAddRows = false;
            this.dgvSimulador.AllowUserToDeleteRows = false;
            this.dgvSimulador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSimulador.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSimulador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSimulador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvSimulador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSimulador.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(212)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSimulador.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSimulador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSimulador.EnableHeadersVisualStyles = false;
            this.dgvSimulador.Location = new System.Drawing.Point(0, 140);
            this.dgvSimulador.Name = "dgvSimulador";
            this.dgvSimulador.RowHeadersVisible = false;
            this.dgvSimulador.RowTemplate.Height = 35;
            this.dgvSimulador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSimulador.Size = new System.Drawing.Size(1024, 380);
            this.dgvSimulador.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSimulador_CellEndEdit);

            // --- PANEL RESULTADOS ---
            this.pnlResultados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlResultados.Controls.Add(this.btnSimularFinal);
            this.pnlResultados.Controls.Add(this.lblEstado);
            this.pnlResultados.Controls.Add(this.lblPromedio);
            this.pnlResultados.Controls.Add(this.label5);
            this.pnlResultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResultados.Location = new System.Drawing.Point(0, 520);
            this.pnlResultados.Name = "pnlResultados";
            this.pnlResultados.Size = new System.Drawing.Size(1024, 100);

            // btnSimularFinal
            this.btnSimularFinal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnSimularFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSimularFinal.FlatAppearance.BorderSize = 0;
            this.btnSimularFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimularFinal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSimularFinal.ForeColor = System.Drawing.Color.White;
            this.btnSimularFinal.Location = new System.Drawing.Point(820, 28);
            this.btnSimularFinal.Name = "btnSimularFinal";
            this.btnSimularFinal.Size = new System.Drawing.Size(180, 45);
            this.btnSimularFinal.Text = "Simular Promedio";
            this.btnSimularFinal.UseVisualStyleBackColor = false;
            this.btnSimularFinal.Click += new System.EventHandler(this.btnSimularFinal_Click);

            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new Point(480, 28);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 41);

            // lblPromedio
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblPromedio.ForeColor = System.Drawing.Color.Black;
            this.lblPromedio.Location = new Point(360, 22);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(98, 51);
            this.lblPromedio.Text = "0.00";

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new Point(30, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(331, 32);
            this.label5.Text = "Promedio Final Proyectado:";

            // frm_SimuladorNotas
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 620);
            this.Controls.Add(this.dgvSimulador);
            this.Controls.Add(this.pnlResultados);
            this.Controls.Add(this.pnlFiltros);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_SimuladorNotas";
            this.Text = "Simulador de Notas";
            this.Load += new System.EventHandler(this.frm_SimuladorNotas_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulador)).EndInit();
            this.pnlResultados.ResumeLayout(false);
            this.pnlResultados.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstudianteInfo;
        private System.Windows.Forms.ComboBox cmbAsignatura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCargarMateria;
        private System.Windows.Forms.DataGridView dgvSimulador;
        private System.Windows.Forms.Panel pnlResultados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnSimularFinal;
    }
}