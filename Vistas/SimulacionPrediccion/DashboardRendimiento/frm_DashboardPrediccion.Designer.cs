using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Dashboard
{
    partial class frm_DashboardPrediccion
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

            pnlTop = new System.Windows.Forms.Panel();
            btnAnalizar = new System.Windows.Forms.Button();
            cmbAsignatura = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cmbPeriodo = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();

            pnlContadores = new System.Windows.Forms.Panel();
            pnlCardRiesgo = new System.Windows.Forms.Panel();
            lblRiesgo = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            pnlCardAprobados = new System.Windows.Forms.Panel();
            lblAprobados = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            pnlCardTotal = new System.Windows.Forms.Panel();
            lblTotalAlumnos = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();

            pnlGrafico = new System.Windows.Forms.Panel();
            dgvPrediccion = new System.Windows.Forms.DataGridView();
            btnCerrar = new System.Windows.Forms.Button();

            pnlTop.SuspendLayout();
            pnlContadores.SuspendLayout();
            pnlCardRiesgo.SuspendLayout();
            pnlCardAprobados.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrediccion).BeginInit();
            SuspendLayout();

            // pnlTop
            pnlTop.BackColor = System.Drawing.Color.White;
            pnlTop.Controls.Add(btnCerrar);
            pnlTop.Controls.Add(btnAnalizar);
            pnlTop.Controls.Add(cmbAsignatura);
            pnlTop.Controls.Add(label3);
            pnlTop.Controls.Add(cmbPeriodo);
            pnlTop.Controls.Add(label2);
            pnlTop.Controls.Add(lblTitulo);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1024, 100);

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34); // Color Naranja
            lblTitulo.Location = new System.Drawing.Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(325, 30);
            lblTitulo.Text = "DASHBOARD DE PREDICCIÓN";

            // Filtros
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(21, 55);
            label2.Name = "label2";
            label2.Text = "Periodo";

            cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPeriodo.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbPeriodo.Location = new System.Drawing.Point(25, 80);
            cmbPeriodo.Name = "cmbPeriodo";
            cmbPeriodo.Size = new System.Drawing.Size(200, 28);

            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(240, 55);
            label3.Name = "label3";
            label3.Text = "Asignatura";

            cmbAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAsignatura.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbAsignatura.Location = new System.Drawing.Point(244, 80);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new System.Drawing.Size(250, 28);

            btnAnalizar.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            btnAnalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAnalizar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnAnalizar.ForeColor = System.Drawing.Color.White;
            btnAnalizar.Location = new System.Drawing.Point(520, 78);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new System.Drawing.Size(150, 32);
            btnAnalizar.Text = "Analizar Datos";
            btnAnalizar.UseVisualStyleBackColor = false;
            btnAnalizar.Click += btnAnalizar_Click;

            // btnCerrar
            btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCerrar.BackColor = System.Drawing.Color.Silver;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCerrar.Location = new System.Drawing.Point(900, 15);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(100, 32);
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            // pnlContadores
            pnlContadores.BackColor = System.Drawing.Color.WhiteSmoke;
            pnlContadores.Controls.Add(pnlCardRiesgo);
            pnlContadores.Controls.Add(pnlCardAprobados);
            pnlContadores.Controls.Add(pnlCardTotal);
            pnlContadores.Dock = System.Windows.Forms.DockStyle.Top;
            pnlContadores.Location = new System.Drawing.Point(0, 100);
            pnlContadores.Name = "pnlContadores";
            pnlContadores.Size = new System.Drawing.Size(1024, 120);

            // pnlCardTotal
            pnlCardTotal.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            pnlCardTotal.Controls.Add(lblTotalAlumnos);
            pnlCardTotal.Controls.Add(label4);
            pnlCardTotal.Location = new System.Drawing.Point(25, 20);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.Size = new System.Drawing.Size(200, 80);

            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(10, 10);
            label4.Name = "label4";
            label4.Text = "Matriculados";

            lblTotalAlumnos.AutoSize = true;
            lblTotalAlumnos.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblTotalAlumnos.ForeColor = System.Drawing.Color.White;
            lblTotalAlumnos.Location = new System.Drawing.Point(10, 30);
            lblTotalAlumnos.Name = "lblTotalAlumnos";
            lblTotalAlumnos.Text = "0";

            // pnlCardAprobados
            pnlCardAprobados.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            pnlCardAprobados.Controls.Add(lblAprobados);
            pnlCardAprobados.Controls.Add(label5);
            pnlCardAprobados.Location = new System.Drawing.Point(244, 20);
            pnlCardAprobados.Name = "pnlCardAprobados";
            pnlCardAprobados.Size = new System.Drawing.Size(200, 80);

            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(10, 10);
            label5.Text = "Buen Rendimiento";

            lblAprobados.AutoSize = true;
            lblAprobados.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblAprobados.ForeColor = System.Drawing.Color.White;
            lblAprobados.Location = new System.Drawing.Point(10, 30);
            lblAprobados.Text = "0";

            // pnlCardRiesgo
            pnlCardRiesgo.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            pnlCardRiesgo.Controls.Add(lblRiesgo);
            pnlCardRiesgo.Controls.Add(label7);
            pnlCardRiesgo.Location = new System.Drawing.Point(464, 20);
            pnlCardRiesgo.Name = "pnlCardRiesgo";
            pnlCardRiesgo.Size = new System.Drawing.Size(200, 80);

            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(10, 10);
            label7.Text = "En Riesgo / Reprobados";

            lblRiesgo.AutoSize = true;
            lblRiesgo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblRiesgo.ForeColor = System.Drawing.Color.White;
            lblRiesgo.Location = new System.Drawing.Point(10, 30);
            lblRiesgo.Text = "0";

            // pnlGrafico
            pnlGrafico.Dock = System.Windows.Forms.DockStyle.Right;
            pnlGrafico.Location = new System.Drawing.Point(624, 220);
            pnlGrafico.Name = "pnlGrafico";
            pnlGrafico.Size = new System.Drawing.Size(400, 400);
            pnlGrafico.Padding = new System.Windows.Forms.Padding(10);

            // dgvPrediccion
            dgvPrediccion.AllowUserToAddRows = false;
            dgvPrediccion.AllowUserToDeleteRows = false;
            dgvPrediccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrediccion.BackgroundColor = System.Drawing.Color.White;
            dgvPrediccion.BorderStyle = System.Windows.Forms.BorderStyle.None;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dgvPrediccion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPrediccion.EnableHeadersVisualStyles = false;
            dgvPrediccion.ReadOnly = true;
            dgvPrediccion.RowHeadersVisible = false;
            dgvPrediccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPrediccion.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPrediccion.Location = new System.Drawing.Point(0, 220);
            dgvPrediccion.Name = "dgvPrediccion";
            dgvPrediccion.CellFormatting += dgvPrediccion_CellFormatting;

            // frm_DashboardPrediccion
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1024, 620);
            Controls.Add(dgvPrediccion);
            Controls.Add(pnlGrafico);
            Controls.Add(pnlContadores);
            Controls.Add(pnlTop);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private System.Windows.Forms.Panel pnlGrafico;
        private System.Windows.Forms.DataGridView dgvPrediccion;
    }
}