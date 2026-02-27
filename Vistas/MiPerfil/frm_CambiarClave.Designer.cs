using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Perfil
{
    partial class frm_CambiarClave
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
            txtClaveActual = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtNuevaClave = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtConfirmar = new System.Windows.Forms.TextBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            label1.Location = new System.Drawing.Point(50, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(268, 30);
            label1.Text = "CAMBIAR CONTRASEÑA";

            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(50, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(161, 25);
            label2.Text = "Contraseña Actual";

            txtClaveActual.Location = new System.Drawing.Point(50, 120);
            txtClaveActual.Name = "txtClaveActual";
            txtClaveActual.Size = new System.Drawing.Size(300, 32);
            txtClaveActual.UseSystemPasswordChar = true;

            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(50, 170);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(166, 25);
            label3.Text = "Nueva Contraseña";

            txtNuevaClave.Location = new System.Drawing.Point(50, 200);
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.Size = new System.Drawing.Size(300, 32);
            txtNuevaClave.UseSystemPasswordChar = true;

            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(50, 250);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(248, 25);
            label4.Text = "Confirmar Nueva Contraseña";

            txtConfirmar.Location = new System.Drawing.Point(50, 280);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new System.Drawing.Size(300, 32);
            txtConfirmar.UseSystemPasswordChar = true;

            btnGuardar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(50, 350);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(140, 40);
            btnGuardar.Text = "Actualizar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnCerrar.BackColor = System.Drawing.Color.Silver;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Location = new System.Drawing.Point(210, 350);
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
            Controls.Add(btnGuardar);
            Controls.Add(txtConfirmar);
            Controls.Add(label4);
            Controls.Add(txtNuevaClave);
            Controls.Add(label3);
            Controls.Add(txtClaveActual);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "frm_CambiarClave";
            Text = "Cambiar Contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
    }
}