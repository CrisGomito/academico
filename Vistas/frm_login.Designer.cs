namespace _02_CRUD.Vistas
{
    partial class frm_login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txt_Correo = new TextBox();
            txt_Contrasenia = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btn_Ingresar2 = new Button();
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
            // txt_Correo
            // 
            txt_Correo.Location = new Point(57, 85);
            txt_Correo.Name = "txt_Correo";
            txt_Correo.Size = new Size(248, 32);
            txt_Correo.TabIndex = 2;
            txt_Correo.Leave += txt_Correo_Leave;
            // 
            // txt_Contrasenia
            // 
            txt_Contrasenia.Location = new Point(57, 148);
            txt_Contrasenia.Name = "txt_Contrasenia";
            txt_Contrasenia.Size = new Size(248, 32);
            txt_Contrasenia.TabIndex = 3;
            txt_Contrasenia.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 57);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 4;
            label2.Text = "Correo Electrónico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 120);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 5;
            label3.Text = "Contraseña";
            // 
            // btn_Ingresar2
            // 
            btn_Ingresar2.Location = new Point(120, 213);
            btn_Ingresar2.Margin = new Padding(5);
            btn_Ingresar2.Name = "btn_Ingresar2";
            btn_Ingresar2.Size = new Size(106, 36);
            btn_Ingresar2.TabIndex = 6;
            btn_Ingresar2.Text = "Ingresar";
            btn_Ingresar2.UseVisualStyleBackColor = true;
            btn_Ingresar2.Click += btn_Ingresar2_Click;
            // 
            // frm_login
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 284);
            Controls.Add(btn_Ingresar2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_Contrasenia);
            Controls.Add(txt_Correo);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "frm_login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txt_Correo;
        private TextBox txt_Contrasenia;
        private Label label2;
        private Label label3;
        private Button btn_Ingresar2;
    }
}