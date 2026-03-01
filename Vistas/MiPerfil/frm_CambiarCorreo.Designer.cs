using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Perfil
{
    partial class frm_CambiarCorreo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            lblCorreoActual = new Label();
            label2 = new Label();
            txtNuevoCorreo = new TextBox();
            btnEnviarCodigo = new Button();
            pnlValidacion = new Panel();
            label3 = new Label();
            txtCodigo = new TextBox();
            btnConfirmar = new Button();
            btnCerrar = new Button();
            pnlValidacion.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(361, 30);
            label1.TabIndex = 6;
            label1.Text = "CAMBIAR CORREO ELECTRÓNICO";
            // 
            // lblCorreoActual
            // 
            lblCorreoActual.AutoSize = true;
            lblCorreoActual.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Italic);
            lblCorreoActual.ForeColor = Color.DimGray;
            lblCorreoActual.Location = new Point(50, 70);
            lblCorreoActual.Name = "lblCorreoActual";
            lblCorreoActual.Size = new Size(175, 20);
            lblCorreoActual.TabIndex = 5;
            lblCorreoActual.Text = "Correo actual: Cargando...";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(455, 130);
            label2.Name = "label2";
            label2.Size = new Size(229, 25);
            label2.TabIndex = 4;
            label2.Text = "Nuevo Correo Electrónico";
            // 
            // txtNuevoCorreo
            // 
            txtNuevoCorreo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNuevoCorreo.Location = new Point(455, 160);
            txtNuevoCorreo.Name = "txtNuevoCorreo";
            txtNuevoCorreo.Size = new Size(350, 32);
            txtNuevoCorreo.TabIndex = 3;
            // 
            // btnEnviarCodigo
            // 
            btnEnviarCodigo.Anchor = AnchorStyles.Left;
            btnEnviarCodigo.BackColor = Color.FromArgb(52, 152, 219);
            btnEnviarCodigo.FlatStyle = FlatStyle.Flat;
            btnEnviarCodigo.ForeColor = Color.White;
            btnEnviarCodigo.Location = new Point(455, 205);
            btnEnviarCodigo.Name = "btnEnviarCodigo";
            btnEnviarCodigo.Size = new Size(200, 40);
            btnEnviarCodigo.TabIndex = 2;
            btnEnviarCodigo.Text = "Enviar Código";
            btnEnviarCodigo.UseVisualStyleBackColor = false;
            btnEnviarCodigo.Click += btnEnviarCodigo_Click;
            // 
            // pnlValidacion
            // 
            pnlValidacion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pnlValidacion.Controls.Add(label3);
            pnlValidacion.Controls.Add(txtCodigo);
            pnlValidacion.Controls.Add(btnConfirmar);
            pnlValidacion.Location = new Point(455, 260);
            pnlValidacion.Name = "pnlValidacion";
            pnlValidacion.Size = new Size(400, 150);
            pnlValidacion.TabIndex = 1;
            pnlValidacion.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 10);
            label3.Name = "label3";
            label3.Size = new Size(332, 25);
            label3.TabIndex = 0;
            label3.Text = "Ingrese el código enviado a su correo:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(0, 45);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 32);
            txtCodigo.TabIndex = 1;
            txtCodigo.TextAlign = HorizontalAlignment.Center;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(39, 174, 96);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(0, 95);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(200, 40);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar Cambio";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Right;
            btnCerrar.BackColor = Color.Silver;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(665, 205);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(140, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cancelar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frm_CambiarCorreo
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 590);
            Controls.Add(btnCerrar);
            Controls.Add(pnlValidacion);
            Controls.Add(btnEnviarCodigo);
            Controls.Add(txtNuevoCorreo);
            Controls.Add(label2);
            Controls.Add(lblCorreoActual);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_CambiarCorreo";
            Text = "Cambiar Correo";
            Load += frm_CambiarCorreo_Load;
            pnlValidacion.ResumeLayout(false);
            pnlValidacion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblCorreoActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNuevoCorreo;
        private System.Windows.Forms.Button btnEnviarCodigo;
        private System.Windows.Forms.Panel pnlValidacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCerrar;
    }
}