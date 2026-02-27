using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Reportes
{
    partial class frm_Reportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cmbTipoReporte = new System.Windows.Forms.ComboBox();
            btnGenerar = new System.Windows.Forms.Button();
            btnCerrarForm = new System.Windows.Forms.Button();
            pnlContenedorReporte = new System.Windows.Forms.Panel();

            pnlTop.SuspendLayout();
            SuspendLayout();

            // pnlTop
            pnlTop.BackColor = System.Drawing.Color.White;
            pnlTop.Controls.Add(btnCerrarForm);
            pnlTop.Controls.Add(btnGenerar);
            pnlTop.Controls.Add(cmbTipoReporte);
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(lblTitulo);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1024, 100);

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitulo.Location = new System.Drawing.Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(325, 30);
            lblTitulo.Text = "MÓDULO DE REPORTES (PDF)";

            // label1
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(21, 55);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(123, 20);
            label1.Text = "Tipo de Reporte:";

            // cmbTipoReporte
            cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbTipoReporte.Items.AddRange(new object[] {
            "Rendimiento Académico Final",
            "Auditoría de Seguridad (Accesos del Año)"});
            cmbTipoReporte.Location = new System.Drawing.Point(150, 52);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new System.Drawing.Size(350, 28);
            cmbTipoReporte.SelectedIndex = 0;

            // btnGenerar
            btnGenerar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGenerar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnGenerar.ForeColor = System.Drawing.Color.White;
            btnGenerar.Location = new System.Drawing.Point(520, 50);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new System.Drawing.Size(150, 32);
            btnGenerar.Text = "Cargar Datos";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;

            // btnCerrarForm (Botón Circular)
            btnCerrarForm.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnCerrarForm.FlatAppearance.BorderSize = 0;
            btnCerrarForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarForm.Location = new System.Drawing.Point(985, 15);
            btnCerrarForm.Name = "btnCerrarForm";
            btnCerrarForm.Size = new System.Drawing.Size(20, 20);
            btnCerrarForm.UseVisualStyleBackColor = false;
            btnCerrarForm.Click += btnCerrarForm_Click;
            btnCerrarForm.Paint += btnCerrarForm_Paint;

            // pnlContenedorReporte
            pnlContenedorReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContenedorReporte.Location = new System.Drawing.Point(0, 100);
            pnlContenedorReporte.Name = "pnlContenedorReporte";
            pnlContenedorReporte.Size = new System.Drawing.Size(1024, 520);

            // frm_Reportes
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(1024, 620);
            Controls.Add(pnlContenedorReporte);
            Controls.Add(pnlTop);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "frm_Reportes";
            Text = "Reportes";
            Load += frm_Reportes_Load;

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnCerrarForm;
        private System.Windows.Forms.Panel pnlContenedorReporte;
    }
}