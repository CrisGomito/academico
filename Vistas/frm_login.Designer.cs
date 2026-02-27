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
            this.btnCerrarForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblOlvidoPass = new System.Windows.Forms.LinkLabel();
            this.btn_Ingresar2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Contrasenia = new System.Windows.Forms.TextBox();
            this.txt_Correo = new System.Windows.Forms.TextBox();
            this.pnl2FA = new System.Windows.Forms.Panel();
            this.lblVolverLoginDe2FA = new System.Windows.Forms.LinkLabel();
            this.lblMensaje2FA = new System.Windows.Forms.Label();
            this.btn_Verificar2FA = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Codigo2FA = new System.Windows.Forms.TextBox();
            this.pnlRecuperar = new System.Windows.Forms.Panel();
            this.lblVolverLogin = new System.Windows.Forms.LinkLabel();
            this.btnEnviarRecuperacion = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCorreoRecuperacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnl2FA.SuspendLayout();
            this.pnlRecuperar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrarForm
            // 
            this.btnCerrarForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrarForm.FlatAppearance.BorderSize = 0;
            this.btnCerrarForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarForm.Location = new System.Drawing.Point(365, 10);
            this.btnCerrarForm.Name = "btnCerrarForm";
            this.btnCerrarForm.Size = new System.Drawing.Size(20, 20);
            this.btnCerrarForm.TabIndex = 0;
            this.btnCerrarForm.UseVisualStyleBackColor = false;
            this.btnCerrarForm.Click += new System.EventHandler(this.btnCerrarForm_Click);
            this.btnCerrarForm.Paint += new System.Windows.Forms.PaintEventHandler(this.btnCerrarForm_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(100, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "BIENVENIDO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.lblOlvidoPass);
            this.pnlLogin.Controls.Add(this.btn_Ingresar2);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.txt_Contrasenia);
            this.pnlLogin.Controls.Add(this.txt_Correo);
            this.pnlLogin.Location = new System.Drawing.Point(0, 90);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(400, 300);
            this.pnlLogin.TabIndex = 7;
            // 
            // lblOlvidoPass
            // 
            this.lblOlvidoPass.AutoSize = true;
            this.lblOlvidoPass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblOlvidoPass.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblOlvidoPass.Location = new System.Drawing.Point(125, 250);
            this.lblOlvidoPass.Name = "lblOlvidoPass";
            this.lblOlvidoPass.Size = new System.Drawing.Size(143, 17);
            this.lblOlvidoPass.TabIndex = 12;
            this.lblOlvidoPass.TabStop = true;
            this.lblOlvidoPass.Text = "¿Olvidó su contraseña?";
            this.lblOlvidoPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOlvidoPass_LinkClicked);
            // 
            // btn_Ingresar2
            // 
            this.btn_Ingresar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_Ingresar2.FlatAppearance.BorderSize = 0;
            this.btn_Ingresar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ingresar2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Ingresar2.ForeColor = System.Drawing.Color.White;
            this.btn_Ingresar2.Location = new System.Drawing.Point(50, 190);
            this.btn_Ingresar2.Name = "btn_Ingresar2";
            this.btn_Ingresar2.Size = new System.Drawing.Size(300, 45);
            this.btn_Ingresar2.TabIndex = 11;
            this.btn_Ingresar2.Text = "Ingresar al Sistema";
            this.btn_Ingresar2.UseVisualStyleBackColor = false;
            this.btn_Ingresar2.Click += new System.EventHandler(this.btn_Ingresar2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(46, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "CONTRASEÑA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(46, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "CORREO ELECTRÓNICO";
            // 
            // txt_Contrasenia
            // 
            this.txt_Contrasenia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Contrasenia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Contrasenia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_Contrasenia.Location = new System.Drawing.Point(50, 125);
            this.txt_Contrasenia.Name = "txt_Contrasenia";
            this.txt_Contrasenia.Size = new System.Drawing.Size(300, 29);
            this.txt_Contrasenia.TabIndex = 8;
            this.txt_Contrasenia.UseSystemPasswordChar = true;
            // 
            // txt_Correo
            // 
            this.txt_Correo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Correo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Correo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_Correo.Location = new System.Drawing.Point(50, 45);
            this.txt_Correo.Name = "txt_Correo";
            this.txt_Correo.Size = new System.Drawing.Size(300, 29);
            this.txt_Correo.TabIndex = 7;
            this.txt_Correo.Leave += new System.EventHandler(this.txt_Correo_Leave);
            // 
            // pnl2FA
            // 
            this.pnl2FA.Controls.Add(this.lblVolverLoginDe2FA);
            this.pnl2FA.Controls.Add(this.lblMensaje2FA);
            this.pnl2FA.Controls.Add(this.btn_Verificar2FA);
            this.pnl2FA.Controls.Add(this.label4);
            this.pnl2FA.Controls.Add(this.txt_Codigo2FA);
            this.pnl2FA.Location = new System.Drawing.Point(0, 90);
            this.pnl2FA.Name = "pnl2FA";
            this.pnl2FA.Size = new System.Drawing.Size(400, 300);
            this.pnl2FA.TabIndex = 8;
            this.pnl2FA.Visible = false;
            // 
            // lblVolverLoginDe2FA
            // 
            this.lblVolverLoginDe2FA.AutoSize = true;
            this.lblVolverLoginDe2FA.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblVolverLoginDe2FA.LinkColor = System.Drawing.Color.Gray;
            this.lblVolverLoginDe2FA.Location = new System.Drawing.Point(135, 250);
            this.lblVolverLoginDe2FA.Name = "lblVolverLoginDe2FA";
            this.lblVolverLoginDe2FA.Size = new System.Drawing.Size(121, 17);
            this.lblVolverLoginDe2FA.TabIndex = 13;
            this.lblVolverLoginDe2FA.TabStop = true;
            this.lblVolverLoginDe2FA.Text = "Volver al login";
            this.lblVolverLoginDe2FA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblVolverLoginDe2FA_LinkClicked);
            // 
            // lblMensaje2FA
            // 
            this.lblMensaje2FA.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMensaje2FA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblMensaje2FA.Location = new System.Drawing.Point(50, 20);
            this.lblMensaje2FA.Name = "lblMensaje2FA";
            this.lblMensaje2FA.Size = new System.Drawing.Size(300, 45);
            this.lblMensaje2FA.TabIndex = 12;
            this.lblMensaje2FA.Text = "Se ha enviado un código de 6 dígitos a su correo electrónico.";
            this.lblMensaje2FA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Verificar2FA
            // 
            this.btn_Verificar2FA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Verificar2FA.FlatAppearance.BorderSize = 0;
            this.btn_Verificar2FA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Verificar2FA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Verificar2FA.ForeColor = System.Drawing.Color.White;
            this.btn_Verificar2FA.Location = new System.Drawing.Point(100, 190);
            this.btn_Verificar2FA.Name = "btn_Verificar2FA";
            this.btn_Verificar2FA.Size = new System.Drawing.Size(200, 45);
            this.btn_Verificar2FA.TabIndex = 11;
            this.btn_Verificar2FA.Text = "Verificar Código";
            this.btn_Verificar2FA.UseVisualStyleBackColor = false;
            this.btn_Verificar2FA.Click += new System.EventHandler(this.btn_Verificar2FA_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(155, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "CÓDIGO 2FA";
            // 
            // txt_Codigo2FA
            // 
            this.txt_Codigo2FA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Codigo2FA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Codigo2FA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txt_Codigo2FA.Location = new System.Drawing.Point(100, 115);
            this.txt_Codigo2FA.MaxLength = 6;
            this.txt_Codigo2FA.Name = "txt_Codigo2FA";
            this.txt_Codigo2FA.Size = new System.Drawing.Size(200, 36);
            this.txt_Codigo2FA.TabIndex = 7;
            this.txt_Codigo2FA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlRecuperar
            // 
            this.pnlRecuperar.Controls.Add(this.lblVolverLogin);
            this.pnlRecuperar.Controls.Add(this.btnEnviarRecuperacion);
            this.pnlRecuperar.Controls.Add(this.label5);
            this.pnlRecuperar.Controls.Add(this.txtCorreoRecuperacion);
            this.pnlRecuperar.Controls.Add(this.label6);
            this.pnlRecuperar.Location = new System.Drawing.Point(0, 90);
            this.pnlRecuperar.Name = "pnlRecuperar";
            this.pnlRecuperar.Size = new System.Drawing.Size(400, 300);
            this.pnlRecuperar.TabIndex = 9;
            this.pnlRecuperar.Visible = false;
            // 
            // lblVolverLogin
            // 
            this.lblVolverLogin.AutoSize = true;
            this.lblVolverLogin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblVolverLogin.LinkColor = System.Drawing.Color.Gray;
            this.lblVolverLogin.Location = new System.Drawing.Point(155, 250);
            this.lblVolverLogin.Name = "lblVolverLogin";
            this.lblVolverLogin.Size = new System.Drawing.Size(89, 17);
            this.lblVolverLogin.TabIndex = 13;
            this.lblVolverLogin.TabStop = true;
            this.lblVolverLogin.Text = "Volver al login";
            this.lblVolverLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblVolverLogin_LinkClicked);
            // 
            // btnEnviarRecuperacion
            // 
            this.btnEnviarRecuperacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnEnviarRecuperacion.FlatAppearance.BorderSize = 0;
            this.btnEnviarRecuperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarRecuperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEnviarRecuperacion.ForeColor = System.Drawing.Color.White;
            this.btnEnviarRecuperacion.Location = new System.Drawing.Point(50, 190);
            this.btnEnviarRecuperacion.Name = "btnEnviarRecuperacion";
            this.btnEnviarRecuperacion.Size = new System.Drawing.Size(300, 45);
            this.btnEnviarRecuperacion.TabIndex = 11;
            this.btnEnviarRecuperacion.Text = "Recuperar Contraseña";
            this.btnEnviarRecuperacion.UseVisualStyleBackColor = false;
            this.btnEnviarRecuperacion.Click += new System.EventHandler(this.btnEnviarRecuperacion_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(46, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "CORREO ELECTRÓNICO";
            // 
            // txtCorreoRecuperacion
            // 
            this.txtCorreoRecuperacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCorreoRecuperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreoRecuperacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCorreoRecuperacion.Location = new System.Drawing.Point(50, 125);
            this.txtCorreoRecuperacion.Name = "txtCorreoRecuperacion";
            this.txtCorreoRecuperacion.Size = new System.Drawing.Size(300, 29);
            this.txtCorreoRecuperacion.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(50, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 60);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ingrese su correo registrado. Le enviaremos una clave temporal para que pueda acceder.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.btnCerrarForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnl2FA);
            this.Controls.Add(this.pnlRecuperar);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnl2FA.ResumeLayout(false);
            this.pnl2FA.PerformLayout();
            this.pnlRecuperar.ResumeLayout(false);
            this.pnlRecuperar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarForm;
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
        private System.Windows.Forms.LinkLabel lblVolverLoginDe2FA;

        // Panel Recuperación
        private System.Windows.Forms.Panel pnlRecuperar;
        private System.Windows.Forms.LinkLabel lblVolverLogin;
        private System.Windows.Forms.Button btnEnviarRecuperacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCorreoRecuperacion;
        private System.Windows.Forms.Label label6;
    }
}