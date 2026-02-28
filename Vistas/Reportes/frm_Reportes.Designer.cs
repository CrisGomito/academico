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
            pnlTop = new Panel();
            btnCerrarForm = new Button();
            btnGenerar = new Button();
            cmbTipoReporte = new ComboBox();
            label1 = new Label();
            lblTitulo = new Label();
            pnlContenedorReporte = new Panel();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(btnCerrarForm);
            pnlTop.Controls.Add(btnGenerar);
            pnlTop.Controls.Add(cmbTipoReporte);
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(lblTitulo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1207, 100);
            pnlTop.TabIndex = 1;
            // 
            // btnCerrarForm
            // 
            btnCerrarForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarForm.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrarForm.FlatAppearance.BorderSize = 0;
            btnCerrarForm.FlatStyle = FlatStyle.Flat;
            btnCerrarForm.Location = new Point(1175, 12);
            btnCerrarForm.Name = "btnCerrarForm";
            btnCerrarForm.Size = new Size(20, 20);
            btnCerrarForm.TabIndex = 0;
            btnCerrarForm.UseVisualStyleBackColor = false;
            btnCerrarForm.Click += btnCerrarForm_Click;
            btnCerrarForm.Paint += btnCerrarForm_Paint;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.FromArgb(39, 174, 96);
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(520, 50);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(150, 32);
            btnGenerar.TabIndex = 1;
            btnGenerar.Text = "Cargar Datos";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbTipoReporte.Items.AddRange(new object[] { "Rendimiento Académico Final", "Auditoría de Seguridad (Accesos del Año)" });
            cmbTipoReporte.Location = new Point(150, 52);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(350, 28);
            cmbTipoReporte.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(21, 55);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 3;
            label1.Text = "Tipo de Reporte:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 30);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "MÓDULO DE REPORTES - PDF";
            // 
            // pnlContenedorReporte
            // 
            pnlContenedorReporte.Dock = DockStyle.Fill;
            pnlContenedorReporte.Location = new Point(0, 100);
            pnlContenedorReporte.Name = "pnlContenedorReporte";
            pnlContenedorReporte.Size = new Size(1207, 520);
            pnlContenedorReporte.TabIndex = 0;
            // 
            // frm_Reportes
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1207, 620);
            Controls.Add(pnlContenedorReporte);
            Controls.Add(pnlTop);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
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