namespace _02_CRUD.Vistas
{
    partial class frm_login
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            pnlLogin = new System.Windows.Forms.Panel();
            lblOlvidoPass = new System.Windows.Forms.LinkLabel();
            btn_Ingresar2 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txt_Contrasenia = new System.Windows.Forms.TextBox();
            txt_Correo = new System.Windows.Forms.TextBox();
            pnl2FA = new System.Windows.Forms.Panel();
            lblMensaje2FA = new System.Windows.Forms.Label();
            btn_Verificar2FA = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            txt_Codigo2FA = new System.Windows.Forms.TextBox();

            pnlLogin.SuspendLayout();
            pnl2FA.SuspendLayout();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label1.Location = new System.Drawing.Point(90, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(220, 32);
            label1.Text = "INICIO DE SESIÓN";

            // pnlLogin
            pnlLogin.Controls.Add(lblOlvidoPass);
            pnlLogin.Controls.Add(btn_Ingresar2);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(txt_Contrasenia);
            pnlLogin.Controls.Add(txt_Correo);
            pnlLogin.Location = new System.Drawing.Point(0, 60);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new System.Drawing.Size(400, 300);

            // lblOlvidoPass
            lblOlvidoPass.AutoSize = true;
            lblOlvidoPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblOlvidoPass.LinkColor = System.Drawing.Color.Gray;
            lblOlvidoPass.Location = new System.Drawing.Point(125, 250);
            lblOlvidoPass.Name = "lblOlvidoPass";
            lblOlvidoPass.Size = new System.Drawing.Size(150, 19);
            lblOlvidoPass.Text = "¿Olvidó su contraseña?";
            lblOlvidoPass.LinkClicked += lblOlvidoPass_LinkClicked;

            // btn_Ingresar2
            btn_Ingresar2.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btn_Ingresar2.FlatAppearance.BorderSize = 0;
            btn_Ingresar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Ingresar2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btn_Ingresar2.ForeColor = System.Drawing.Color.White;
            btn_Ingresar2.Location = new System.Drawing.Point(50, 190);
            btn_Ingresar2.Name = "btn_Ingresar2";
            btn_Ingresar2.Size = new System.Drawing.Size(300, 45);
            btn_Ingresar2.Text = "Ingresar al Sistema";
            btn_Ingresar2.UseVisualStyleBackColor = false;
            btn_Ingresar2.Click += btn_Ingresar2_Click;

            // label2
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Gray;
            label2.Location = new System.Drawing.Point(46, 20);
            label2.Name = "label2";
            label2.Text = "CORREO ELECTRÓNICO";

            // txt_Correo
            txt_Correo.BackColor = System.Drawing.Color.WhiteSmoke;
            txt_Correo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_Correo.Font = new System.Drawing.Font("Segoe UI", 12F);
            txt_Correo.Location = new System.Drawing.Point(50, 45);
            txt_Correo.Name = "txt_Correo";
            txt_Correo.Size = new System.Drawing.Size(300, 29);
            txt_Correo.Leave += txt_Correo_Leave;

            // label3
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.Gray;
            label3.Location = new System.Drawing.Point(46, 100);
            label3.Name = "label3";
            label3.Text = "CONTRASEÑA";

            // txt_Contrasenia
            txt_Contrasenia.BackColor = System.Drawing.Color.WhiteSmoke;
            txt_Contrasenia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_Contrasenia.Font = new System.Drawing.Font("Segoe UI", 12F);
            txt_Contrasenia.Location = new System.Drawing.Point(50, 125);
            txt_Contrasenia.Name = "txt_Contrasenia";
            txt_Contrasenia.Size = new System.Drawing.Size(300, 29);
            txt_Contrasenia.UseSystemPasswordChar = true;

            // pnl2FA
            pnl2FA.Controls.Add(lblMensaje2FA);
            pnl2FA.Controls.Add(btn_Verificar2FA);
            pnl2FA.Controls.Add(label4);
            pnl2FA.Controls.Add(txt_Codigo2FA);
            pnl2FA.Location = new System.Drawing.Point(0, 60);
            pnl2FA.Name = "pnl2FA";
            pnl2FA.Size = new System.Drawing.Size(400, 300);
            pnl2FA.Visible = false;

            // lblMensaje2FA
            lblMensaje2FA.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblMensaje2FA.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblMensaje2FA.Location = new System.Drawing.Point(50, 20);
            lblMensaje2FA.Name = "lblMensaje2FA";
            lblMensaje2FA.Size = new System.Drawing.Size(300, 45);
            lblMensaje2FA.Text = "Se ha enviado un código de 6 dígitos a su correo electrónico.";
            lblMensaje2FA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // label4
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.Gray;
            label4.Location = new System.Drawing.Point(155, 90);
            label4.Name = "label4";
            label4.Text = "CÓDIGO 2FA";

            // txt_Codigo2FA
            txt_Codigo2FA.BackColor = System.Drawing.Color.WhiteSmoke;
            txt_Codigo2FA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_Codigo2FA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            txt_Codigo2FA.Location = new System.Drawing.Point(100, 115);
            txt_Codigo2FA.MaxLength = 6;
            txt_Codigo2FA.Name = "txt_Codigo2FA";
            txt_Codigo2FA.Size = new System.Drawing.Size(200, 36);
            txt_Codigo2FA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // btn_Verificar2FA
            btn_Verificar2FA.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btn_Verificar2FA.FlatAppearance.BorderSize = 0;
            btn_Verificar2FA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Verificar2FA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btn_Verificar2FA.ForeColor = System.Drawing.Color.White;
            btn_Verificar2FA.Location = new System.Drawing.Point(100, 190);
            btn_Verificar2FA.Name = "btn_Verificar2FA";
            btn_Verificar2FA.Size = new System.Drawing.Size(200, 45);
            btn_Verificar2FA.Text = "Verificar Código";
            btn_Verificar2FA.UseVisualStyleBackColor = false;
            btn_Verificar2FA.Click += btn_Verificar2FA_Click;

            // frm_login
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(400, 380);
            Controls.Add(label1);
            Controls.Add(pnlLogin);
            Controls.Add(pnl2FA);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Acceso al Sistema";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnl2FA.ResumeLayout(false);
            pnl2FA.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btn_Ingresar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Contrasenia;
        private System.Windows.Forms.TextBox txt_Correo;
        private System.Windows.Forms.Panel pnl2FA;
        private System.Windows.Forms.Label lblMensaje2FA;
        private System.Windows.Forms.Button btn_Verificar2FA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Codigo2FA;
        private System.Windows.Forms.LinkLabel lblOlvidoPass;
    }
}