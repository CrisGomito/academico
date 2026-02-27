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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtNuevoCorreo = new System.Windows.Forms.TextBox();
            btnEnviarCodigo = new System.Windows.Forms.Button();
            pnlValidacion = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            txtCodigo = new System.Windows.Forms.TextBox();
            btnConfirmar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            pnlValidacion.SuspendLayout();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            label1.Location = new System.Drawing.Point(50, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(359, 30);
            label1.Text = "CAMBIAR CORREO ELECTRÓNICO";

            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(50, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(232, 25);
            label2.Text = "Nuevo Correo Electrónico";

            txtNuevoCorreo.Location = new System.Drawing.Point(50, 120);
            txtNuevoCorreo.Name = "txtNuevoCorreo";
            txtNuevoCorreo.Size = new System.Drawing.Size(350, 32);

            btnEnviarCodigo.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnEnviarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEnviarCodigo.ForeColor = System.Drawing.Color.White;
            btnEnviarCodigo.Location = new System.Drawing.Point(50, 165);
            btnEnviarCodigo.Name = "btnEnviarCodigo";
            btnEnviarCodigo.Size = new System.Drawing.Size(200, 40);
            btnEnviarCodigo.Text = "Enviar Código";
            btnEnviarCodigo.UseVisualStyleBackColor = false;
            btnEnviarCodigo.Click += btnEnviarCodigo_Click;

            pnlValidacion.Controls.Add(label3);
            pnlValidacion.Controls.Add(txtCodigo);
            pnlValidacion.Controls.Add(btnConfirmar);
            pnlValidacion.Location = new System.Drawing.Point(50, 230);
            pnlValidacion.Name = "pnlValidacion";
            pnlValidacion.Size = new System.Drawing.Size(400, 150);
            pnlValidacion.Visible = false;

            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(0, 10);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(342, 25);
            label3.Text = "Ingrese el código enviado a su correo:";

            txtCodigo.Location = new System.Drawing.Point(0, 45);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new System.Drawing.Size(200, 32);
            txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            btnConfirmar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirmar.ForeColor = System.Drawing.Color.White;
            btnConfirmar.Location = new System.Drawing.Point(0, 95);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new System.Drawing.Size(200, 40);
            btnConfirmar.Text = "Confirmar Cambio";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;

            btnCerrar.BackColor = System.Drawing.Color.Silver;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Location = new System.Drawing.Point(260, 165);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(140, 40);
            btnCerrar.Text = "Cancelar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(800, 500);
            Controls.Add(btnCerrar);
            Controls.Add(pnlValidacion);
            Controls.Add(btnEnviarCodigo);
            Controls.Add(txtNuevoCorreo);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "frm_CambiarCorreo";
            Text = "Cambiar Correo";
            pnlValidacion.ResumeLayout(false);
            pnlValidacion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

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