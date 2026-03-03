namespace DataBase_First.Views.Calificaciones
{
    partial class frm_IngresoNotas
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlFiltros = new Panel();
            btnCerrar = new Button();
            btnCargar = new Button();
            cmbEvaluacion = new ComboBox();
            label4 = new Label();
            cmbAsignatura = new ComboBox();
            label3 = new Label();
            cmbPeriodo = new ComboBox();
            label2 = new Label();
            lblTitulo = new Label();
            dgvAlumnos = new DataGridView();
            pnlFooter = new Panel();
            btnGuardar = new Button();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Controls.Add(btnCerrar);
            pnlFiltros.Controls.Add(btnCargar);
            pnlFiltros.Controls.Add(cmbEvaluacion);
            pnlFiltros.Controls.Add(label4);
            pnlFiltros.Controls.Add(cmbAsignatura);
            pnlFiltros.Controls.Add(label3);
            pnlFiltros.Controls.Add(cmbPeriodo);
            pnlFiltros.Controls.Add(label2);
            pnlFiltros.Controls.Add(lblTitulo);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1280, 140);
            pnlFiltros.TabIndex = 2;
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
            // btnCargar
            // 
            btnCargar.BackColor = Color.FromArgb(44, 62, 80);
            btnCargar.FlatAppearance.BorderSize = 0;
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCargar.ForeColor = Color.White;
            btnCargar.Location = new Point(833, 86);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(130, 32);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "Cargar Lista";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // cmbEvaluacion
            // 
            cmbEvaluacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEvaluacion.Font = new Font("Segoe UI", 11F);
            cmbEvaluacion.FormattingEnabled = true;
            cmbEvaluacion.Location = new Point(514, 90);
            cmbEvaluacion.Name = "cmbEvaluacion";
            cmbEvaluacion.Size = new Size(297, 28);
            cmbEvaluacion.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(510, 65);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 3;
            label4.Text = "Evaluación";
            // 
            // cmbAsignatura
            // 
            cmbAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAsignatura.Font = new Font("Segoe UI", 11F);
            cmbAsignatura.FormattingEnabled = true;
            cmbAsignatura.Location = new Point(244, 90);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new Size(250, 28);
            cmbAsignatura.TabIndex = 4;
            cmbAsignatura.SelectedIndexChanged += cmbAsignatura_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(240, 65);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 5;
            label3.Text = "Asignatura";
            // 
            // cmbPeriodo
            // 
            cmbPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodo.Font = new Font("Segoe UI", 11F);
            cmbPeriodo.FormattingEnabled = true;
            cmbPeriodo.Location = new Point(25, 90);
            cmbPeriodo.Name = "cmbPeriodo";
            cmbPeriodo.Size = new Size(200, 28);
            cmbPeriodo.TabIndex = 6;
            cmbPeriodo.SelectedIndexChanged += cmbPeriodo_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(21, 65);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 7;
            label2.Text = "Periodo";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(331, 30);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "REGISTRO DE CALIFICACIONES";
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.AllowUserToAddRows = false;
            dgvAlumnos.AllowUserToDeleteRows = false;
            dgvAlumnos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlumnos.BackgroundColor = Color.WhiteSmoke;
            dgvAlumnos.BorderStyle = BorderStyle.None;
            dgvAlumnos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dgvAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAlumnos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 232, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAlumnos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAlumnos.EnableHeadersVisualStyles = false;
            dgvAlumnos.GridColor = Color.LightGray;
            dgvAlumnos.Location = new Point(0, 140);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.RowHeadersVisible = false;
            dgvAlumnos.RowTemplate.Height = 35;
            dgvAlumnos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvAlumnos.Size = new Size(1280, 384);
            dgvAlumnos.TabIndex = 0;
            dgvAlumnos.CellEndEdit += dgvAlumnos_CellEndEdit;
            dgvAlumnos.CellValueChanged += dgvAlumnos_CellValueChanged;
            // 
            // pnlFooter
            // 
            pnlFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlFooter.BackColor = Color.White;
            pnlFooter.Controls.Add(btnGuardar);
            pnlFooter.Location = new Point(0, 522);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1280, 68);
            pnlFooter.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(1076, 8);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 45);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar Notas";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frm_IngresoNotas
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 590);
            Controls.Add(dgvAlumnos);
            Controls.Add(pnlFooter);
            Controls.Add(pnlFiltros);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_IngresoNotas";
            Text = "Ingreso de Calificaciones";
            Load += frm_IngresoNotas_Load;
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbEvaluacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAsignatura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
    }
}