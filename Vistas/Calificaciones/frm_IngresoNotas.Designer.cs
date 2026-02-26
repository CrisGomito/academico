using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Calificaciones
{
    partial class frm_IngresoNotas
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
            btnNuevaEval = new System.Windows.Forms.Button();
            btnCargar = new System.Windows.Forms.Button();
            cmbEvaluacion = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cmbAsignatura = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cmbPeriodo = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            dgvAlumnos = new System.Windows.Forms.DataGridView();
            pnlFooter = new System.Windows.Forms.Panel();
            btnGuardar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();

            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();

            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = System.Drawing.Color.White;
            pnlFiltros.Controls.Add(btnNuevaEval);
            pnlFiltros.Controls.Add(btnCargar);
            pnlFiltros.Controls.Add(cmbEvaluacion);
            pnlFiltros.Controls.Add(label4);
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
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitulo.Location = new System.Drawing.Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(324, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE CALIFICACIONES";

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
            cmbPeriodo.Size = new System.Drawing.Size(200, 28);
            cmbPeriodo.TabIndex = 2;
            cmbPeriodo.SelectedIndexChanged += cmbPeriodo_SelectedIndexChanged;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(240, 65);
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
            cmbAsignatura.Location = new System.Drawing.Point(244, 90);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new System.Drawing.Size(250, 28);
            cmbAsignatura.TabIndex = 4;
            cmbAsignatura.SelectedIndexChanged += cmbAsignatura_SelectedIndexChanged;

            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(510, 65);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(84, 20);
            label4.TabIndex = 5;
            label4.Text = "Evaluación";

            // 
            // cmbEvaluacion
            // 
            cmbEvaluacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEvaluacion.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbEvaluacion.FormattingEnabled = true;
            cmbEvaluacion.Location = new System.Drawing.Point(514, 90);
            cmbEvaluacion.Name = "cmbEvaluacion";
            cmbEvaluacion.Size = new System.Drawing.Size(250, 28);
            cmbEvaluacion.TabIndex = 6;

            // 
            // btnCargar
            // 
            btnCargar.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            btnCargar.FlatAppearance.BorderSize = 0;
            btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCargar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCargar.ForeColor = System.Drawing.Color.White;
            btnCargar.Location = new System.Drawing.Point(790, 88);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new System.Drawing.Size(130, 32);
            btnCargar.TabIndex = 7;
            btnCargar.Text = "Cargar Lista";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;

            // 
            // btnNuevaEval
            // 
            btnNuevaEval.BackColor = System.Drawing.Color.LightGray;
            btnNuevaEval.FlatAppearance.BorderSize = 0;
            btnNuevaEval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNuevaEval.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnNuevaEval.Location = new System.Drawing.Point(600, 62);
            btnNuevaEval.Name = "btnNuevaEval";
            btnNuevaEval.Size = new System.Drawing.Size(164, 25);
            btnNuevaEval.TabIndex = 8;
            btnNuevaEval.Text = "+ Crear Evaluación";
            btnNuevaEval.UseVisualStyleBackColor = false;
            btnNuevaEval.Click += btnNuevaEval_Click;

            // 
            // dgvAlumnos
            // 
            dgvAlumnos.AllowUserToAddRows = false;
            dgvAlumnos.AllowUserToDeleteRows = false;
            dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlumnos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvAlumnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;

            // Estilo de los encabezados (MODERNO)
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAlumnos.ColumnHeadersHeight = 40;
            dgvAlumnos.EnableHeadersVisualStyles = false;

            // Estilo de las filas
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(204, 232, 255);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvAlumnos.DefaultCellStyle = dataGridViewCellStyle2;

            dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAlumnos.GridColor = System.Drawing.Color.LightGray;
            dgvAlumnos.Location = new System.Drawing.Point(0, 140);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.RowHeadersVisible = false;
            dgvAlumnos.RowTemplate.Height = 35;
            dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dgvAlumnos.Size = new System.Drawing.Size(1024, 400);
            dgvAlumnos.TabIndex = 1;
            dgvAlumnos.CellValidating += dgvAlumnos_CellValidating;

            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = System.Drawing.Color.White;
            pnlFooter.Controls.Add(btnCerrar);
            pnlFooter.Controls.Add(btnGuardar);
            pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlFooter.Location = new System.Drawing.Point(0, 540);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new System.Drawing.Size(1024, 80);
            pnlFooter.TabIndex = 2;

            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(820, 20);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(180, 45);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar Notas";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCerrar.BackColor = System.Drawing.Color.Silver;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnCerrar.Location = new System.Drawing.Point(700, 20);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(100, 45);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            // 
            // frm_IngresoNotas
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1024, 620);
            Controls.Add(dgvAlumnos);
            Controls.Add(pnlFooter);
            Controls.Add(pnlFiltros);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button btnNuevaEval;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
    }
}