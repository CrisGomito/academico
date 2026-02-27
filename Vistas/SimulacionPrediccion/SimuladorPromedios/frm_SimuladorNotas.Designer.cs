using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Simulacion
{
    partial class frm_SimuladorNotas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            pnlFiltros = new System.Windows.Forms.Panel();
            lblEstudianteInfo = new System.Windows.Forms.Label();
            btnSimular = new System.Windows.Forms.Button();
            cmbAsignatura = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cmbPeriodo = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            dgvSimulador = new System.Windows.Forms.DataGridView();
            pnlResultados = new System.Windows.Forms.Panel();
            lblEstado = new System.Windows.Forms.Label();
            lblPromedio = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            btnCerrar = new System.Windows.Forms.Button();

            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSimulador).BeginInit();
            pnlResultados.SuspendLayout();
            SuspendLayout();

            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = System.Drawing.Color.White;
            pnlFiltros.Controls.Add(lblEstudianteInfo);
            pnlFiltros.Controls.Add(btnSimular);
            pnlFiltros.Controls.Add(cmbAsignatura);
            pnlFiltros.Controls.Add(label3);
            pnlFiltros.Controls.Add(cmbPeriodo);
            pnlFiltros.Controls.Add(label2);
            pnlFiltros.Controls.Add(lblTitulo);
            pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFiltros.Location = new System.Drawing.Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new System.Drawing.Size(1024, 140);
            pnlFiltros.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(142, 68, 173); // Morado para diferenciarlo
            lblTitulo.Location = new System.Drawing.Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(325, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SIMULADOR DE PROMEDIOS";

            // 
            // lblEstudianteInfo
            // 
            lblEstudianteInfo.AutoSize = true;
            lblEstudianteInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            lblEstudianteInfo.ForeColor = System.Drawing.Color.Gray;
            lblEstudianteInfo.Location = new System.Drawing.Point(360, 22);
            lblEstudianteInfo.Name = "lblEstudianteInfo";
            lblEstudianteInfo.Size = new System.Drawing.Size(150, 20);
            lblEstudianteInfo.TabIndex = 8;
            lblEstudianteInfo.Text = "Estudiante: Cargando...";

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(21, 65);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 20);
            label2.TabIndex = 1;
            label2.Text = "Periodo";

            // 
            // cmbPeriodo
            // 
            cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPeriodo.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbPeriodo.FormattingEnabled = true;
            cmbPeriodo.Location = new System.Drawing.Point(25, 90);
            cmbPeriodo.Name = "cmbPeriodo";
            cmbPeriodo.Size = new System.Drawing.Size(250, 28);
            cmbPeriodo.TabIndex = 2;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(300, 65);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(86, 20);
            label3.TabIndex = 3;
            label3.Text = "Asignatura";

            // 
            // cmbAsignatura
            // 
            cmbAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAsignatura.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbAsignatura.FormattingEnabled = true;
            cmbAsignatura.Location = new System.Drawing.Point(304, 90);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new System.Drawing.Size(300, 28);
            cmbAsignatura.TabIndex = 4;

            // 
            // btnSimular
            // 
            btnSimular.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            btnSimular.FlatAppearance.BorderSize = 0;
            btnSimular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSimular.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSimular.ForeColor = System.Drawing.Color.White;
            btnSimular.Location = new System.Drawing.Point(630, 88);
            btnSimular.Name = "btnSimular";
            btnSimular.Size = new System.Drawing.Size(150, 32);
            btnSimular.TabIndex = 7;
            btnSimular.Text = "Cargar Modelo";
            btnSimular.UseVisualStyleBackColor = false;
            btnSimular.Click += btnSimular_Click;

            // 
            // dgvSimulador
            // 
            dgvSimulador.AllowUserToAddRows = false;
            dgvSimulador.AllowUserToDeleteRows = false;
            dgvSimulador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvSimulador.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvSimulador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvSimulador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvSimulador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSimulador.ColumnHeadersHeight = 40;
            dgvSimulador.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 212, 248);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvSimulador.DefaultCellStyle = dataGridViewCellStyle2;

            dgvSimulador.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvSimulador.Location = new System.Drawing.Point(0, 140);
            dgvSimulador.Name = "dgvSimulador";
            dgvSimulador.RowHeadersVisible = false;
            dgvSimulador.RowTemplate.Height = 35;
            dgvSimulador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dgvSimulador.Size = new System.Drawing.Size(1024, 380);
            dgvSimulador.TabIndex = 1;
            dgvSimulador.CellEndEdit += dgvSimulador_CellEndEdit;
            dgvSimulador.CellValidating += dgvSimulador_CellValidating;

            // 
            // pnlResultados
            // 
            pnlResultados.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            pnlResultados.Controls.Add(btnCerrar);
            pnlResultados.Controls.Add(lblEstado);
            pnlResultados.Controls.Add(lblPromedio);
            pnlResultados.Controls.Add(label5);
            pnlResultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlResultados.Location = new System.Drawing.Point(0, 520);
            pnlResultados.Name = "pnlResultados";
            pnlResultados.Size = new System.Drawing.Size(1024, 100);
            pnlResultados.TabIndex = 2;

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(30, 32);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(342, 32);
            label5.TabIndex = 0;
            label5.Text = "Promedio Final Proyectado:";

            // 
            // lblPromedio
            // 
            lblPromedio.AutoSize = true;
            lblPromedio.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblPromedio.ForeColor = System.Drawing.Color.Black;
            lblPromedio.Location = new System.Drawing.Point(380, 22);
            lblPromedio.Name = "lblPromedio";
            lblPromedio.Size = new System.Drawing.Size(96, 51);
            lblPromedio.TabIndex = 1;
            lblPromedio.Text = "0.00";

            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblEstado.Location = new System.Drawing.Point(500, 28);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(0, 41);
            lblEstado.TabIndex = 2;

            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCerrar.BackColor = System.Drawing.Color.Silver;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnCerrar.Location = new System.Drawing.Point(890, 30);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(100, 45);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            // 
            // frm_SimuladorNotas
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1024, 620);
            Controls.Add(dgvSimulador);
            Controls.Add(pnlResultados);
            Controls.Add(pnlFiltros);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "frm_SimuladorNotas";
            Text = "Simulador de Notas";
            Load += frm_SimuladorNotas_Load;

            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSimulador).EndInit();
            pnlResultados.ResumeLayout(false);
            pnlResultados.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstudianteInfo;
        private System.Windows.Forms.ComboBox cmbAsignatura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.DataGridView dgvSimulador;
        private System.Windows.Forms.Panel pnlResultados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnCerrar;
    }
}