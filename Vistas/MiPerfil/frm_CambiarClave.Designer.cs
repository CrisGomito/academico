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
            label1 = new Label();
            label2 = new Label();
            txtClaveActual = new TextBox();
            label3 = new Label();
            txtNuevaClave = new TextBox();
            label4 = new Label();
            txtConfirmar = new TextBox();
            btnGuardar = new Button();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(265, 30);
            label1.TabIndex = 8;
            label1.Text = "CAMBIAR CONTRASEÑA";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(450, 130);
            label2.Name = "label2";
            label2.Size = new Size(166, 25);
            label2.TabIndex = 7;
            label2.Text = "Contraseña Actual";
            // 
            // txtClaveActual
            // 
            txtClaveActual.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtClaveActual.Location = new Point(450, 158);
            txtClaveActual.Name = "txtClaveActual";
            txtClaveActual.Size = new Size(300, 32);
            txtClaveActual.TabIndex = 6;
            txtClaveActual.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(450, 210);
            label3.Name = "label3";
            label3.Size = new Size(167, 25);
            label3.TabIndex = 5;
            label3.Text = "Nueva Contraseña";
            // 
            // txtNuevaClave
            // 
            txtNuevaClave.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNuevaClave.Location = new Point(450, 238);
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.Size = new Size(300, 32);
            txtNuevaClave.TabIndex = 4;
            txtNuevaClave.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(450, 288);
            label4.Name = "label4";
            label4.Size = new Size(257, 25);
            label4.TabIndex = 3;
            label4.Text = "Confirmar Nueva Contraseña";
            // 
            // txtConfirmar
            // 
            txtConfirmar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmar.Location = new Point(450, 318);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(300, 32);
            txtConfirmar.TabIndex = 2;
            txtConfirmar.UseSystemPasswordChar = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Left;
            btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(450, 388);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 40);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Actualizar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Right;
            btnCerrar.BackColor = Color.Silver;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(610, 388);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(140, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cancelar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frm_CambiarClave
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 590);
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
            FormBorderStyle = FormBorderStyle.None;
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