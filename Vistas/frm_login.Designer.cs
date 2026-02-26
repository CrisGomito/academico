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
            label1 = new Label();
            pnlLogin = new Panel();
            btn_Ingresar2 = new Button();
            label3 = new Label();
            label2 = new Label();
            txt_Contrasenia = new TextBox();
            txt_Correo = new TextBox();
            pnl2FA = new Panel();
            lblMensaje2FA = new Label();
            btn_Verificar2FA = new Button();
            label4 = new Label();
            txt_Codigo2FA = new TextBox();
            pnlLogin.SuspendLayout();
            pnl2FA.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(98, 9);
            label1.Name = "label1";
            label1.Size = new Size(172, 25);
            label1.TabIndex = 1;
            label1.Text = "INICIO DE SESIÓN";
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(btn_Ingresar2);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(txt_Contrasenia);
            pnlLogin.Controls.Add(txt_Correo);
            pnlLogin.Location = new Point(0, 37);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(360, 246);
            pnlLogin.TabIndex = 7;
            // 
            // btn_Ingresar2
            // 
            btn_Ingresar2.Location = new Point(120, 176);
            btn_Ingresar2.Margin = new Padding(5);
            btn_Ingresar2.Name = "btn_Ingresar2";
            btn_Ingresar2.Size = new Size(106, 36);
            btn_Ingresar2.TabIndex = 11;
            btn_Ingresar2.Text = "Ingresar";
            btn_Ingresar2.UseVisualStyleBackColor = true;
            btn_Ingresar2.Click += btn_Ingresar2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 83);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 10;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 20);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 9;
            label2.Text = "Correo Electrónico";
            // 
            // txt_Contrasenia
            // 
            txt_Contrasenia.Location = new Point(57, 111);
            txt_Contrasenia.Name = "txt_Contrasenia";
            txt_Contrasenia.Size = new Size(248, 32);
            txt_Contrasenia.TabIndex = 8;
            txt_Contrasenia.UseSystemPasswordChar = true;
            // 
            // txt_Correo
            // 
            txt_Correo.Location = new Point(57, 48);
            txt_Correo.Name = "txt_Correo";
            txt_Correo.Size = new Size(248, 32);
            txt_Correo.TabIndex = 7;
            txt_Correo.Leave += txt_Correo_Leave;
            // 
            // pnl2FA
            // 
            pnl2FA.Controls.Add(lblMensaje2FA);
            pnl2FA.Controls.Add(btn_Verificar2FA);
            pnl2FA.Controls.Add(label4);
            pnl2FA.Controls.Add(txt_Codigo2FA);
            pnl2FA.Location = new Point(0, 37);
            pnl2FA.Name = "pnl2FA";
            pnl2FA.Size = new Size(360, 246);
            pnl2FA.TabIndex = 8;
            pnl2FA.Visible = false;
            // 
            // lblMensaje2FA
            // 
            lblMensaje2FA.Font = new Font("Segoe UI", 10F);
            lblMensaje2FA.Location = new Point(23, 20);
            lblMensaje2FA.Name = "lblMensaje2FA";
            lblMensaje2FA.Size = new Size(315, 45);
            lblMensaje2FA.TabIndex = 12;
            lblMensaje2FA.Text = "Se ha enviado un código de 6 dígitos a su correo electrónico.";
            lblMensaje2FA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Verificar2FA
            // 
            btn_Verificar2FA.Location = new Point(120, 150);
            btn_Verificar2FA.Margin = new Padding(5);
            btn_Verificar2FA.Name = "btn_Verificar2FA";
            btn_Verificar2FA.Size = new Size(106, 36);
            btn_Verificar2FA.TabIndex = 11;
            btn_Verificar2FA.Text = "Verificar";
            btn_Verificar2FA.UseVisualStyleBackColor = true;
            btn_Verificar2FA.Click += btn_Verificar2FA_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 83);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 9;
            label4.Text = "Código 2FA";
            // 
            // txt_Codigo2FA
            // 
            txt_Codigo2FA.Location = new Point(57, 111);
            txt_Codigo2FA.MaxLength = 6;
            txt_Codigo2FA.Name = "txt_Codigo2FA";
            txt_Codigo2FA.Size = new Size(248, 32);
            txt_Codigo2FA.TabIndex = 7;
            txt_Codigo2FA.TextAlign = HorizontalAlignment.Center;
            // 
            // frm_login
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 284);
            Controls.Add(label1);
            Controls.Add(pnlLogin);
            Controls.Add(pnl2FA);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "frm_login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
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
    }
}