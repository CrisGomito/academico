namespace DataBase_First.Views.Users
{
    partial class frm_Usuarios
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
            lst_Lista_Usuarios = new ListBox();
            label1 = new Label();
            txt_Nombre = new TextBox();
            btn_Nuevo = new Button();
            label2 = new Label();
            label4 = new Label();
            txt_Correo = new TextBox();
            label5 = new Label();
            txt_Contrasenia = new TextBox();
            label6 = new Label();
            chb_Estado = new CheckBox();
            btn_Guardar = new Button();
            btn_Editar = new Button();
            btn_Cancelar = new Button();
            btn_Salir = new Button();
            label7 = new Label();
            cmb_Rol = new ComboBox();
            btn_Eliminar = new Button();
            label3 = new Label();
            txt_Apellido = new TextBox();
            SuspendLayout();
            // 
            // lst_Lista_Usuarios
            // 
            lst_Lista_Usuarios.FormattingEnabled = true;
            lst_Lista_Usuarios.ItemHeight = 25;
            lst_Lista_Usuarios.Location = new Point(294, 68);
            lst_Lista_Usuarios.Margin = new Padding(5);
            lst_Lista_Usuarios.Name = "lst_Lista_Usuarios";
            lst_Lista_Usuarios.Size = new Size(372, 329);
            lst_Lista_Usuarios.TabIndex = 0;
            lst_Lista_Usuarios.DoubleClick += lst_Lista_Usuarios_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(260, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(222, 25);
            label1.TabIndex = 1;
            label1.Text = "GESTIÓN DE USUARIOS";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Enabled = false;
            txt_Nombre.Location = new Point(36, 98);
            txt_Nombre.Margin = new Padding(5);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(222, 32);
            txt_Nombre.TabIndex = 2;
            // 
            // btn_Nuevo
            // 
            btn_Nuevo.Location = new Point(36, 469);
            btn_Nuevo.Margin = new Padding(5);
            btn_Nuevo.Name = "btn_Nuevo";
            btn_Nuevo.Size = new Size(118, 38);
            btn_Nuevo.TabIndex = 3;
            btn_Nuevo.Text = "Nuevo";
            btn_Nuevo.UseVisualStyleBackColor = true;
            btn_Nuevo.Click += btn_Nuevo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(36, 68);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 4;
            label2.Text = "Nombres*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(36, 202);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(177, 25);
            label4.TabIndex = 8;
            label4.Text = "Correo Electrónico*";
            // 
            // txt_Correo
            // 
            txt_Correo.Enabled = false;
            txt_Correo.Location = new Point(36, 232);
            txt_Correo.Margin = new Padding(5);
            txt_Correo.Name = "txt_Correo";
            txt_Correo.Size = new Size(222, 32);
            txt_Correo.TabIndex = 7;
            txt_Correo.Leave += txt_Correo_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(36, 269);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(116, 25);
            label5.TabIndex = 10;
            label5.Text = "Contraseña*";
            // 
            // txt_Contrasenia
            // 
            txt_Contrasenia.Enabled = false;
            txt_Contrasenia.Location = new Point(36, 299);
            txt_Contrasenia.Margin = new Padding(5);
            txt_Contrasenia.Name = "txt_Contrasenia";
            txt_Contrasenia.Size = new Size(222, 32);
            txt_Contrasenia.TabIndex = 9;
            txt_Contrasenia.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(36, 400);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(138, 25);
            label6.TabIndex = 12;
            label6.Text = "Estado Usuario";
            // 
            // chb_Estado
            // 
            chb_Estado.AutoSize = true;
            chb_Estado.Enabled = false;
            chb_Estado.Location = new Point(36, 428);
            chb_Estado.Name = "chb_Estado";
            chb_Estado.Size = new Size(97, 29);
            chb_Estado.TabIndex = 13;
            chb_Estado.Text = "Inactivo";
            chb_Estado.UseVisualStyleBackColor = true;
            chb_Estado.CheckedChanged += chb_Estado_CheckedChanged;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Enabled = false;
            btn_Guardar.Location = new Point(164, 469);
            btn_Guardar.Margin = new Padding(5);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(118, 38);
            btn_Guardar.TabIndex = 14;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Editar
            // 
            btn_Editar.Location = new Point(292, 469);
            btn_Editar.Margin = new Padding(5);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new Size(118, 38);
            btn_Editar.TabIndex = 15;
            btn_Editar.Text = "Editar";
            btn_Editar.UseVisualStyleBackColor = true;
            btn_Editar.Click += btn_Editar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.Enabled = false;
            btn_Cancelar.Location = new Point(420, 469);
            btn_Cancelar.Margin = new Padding(5);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(118, 38);
            btn_Cancelar.TabIndex = 16;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.UseVisualStyleBackColor = true;
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // btn_Salir
            // 
            btn_Salir.Location = new Point(548, 469);
            btn_Salir.Margin = new Padding(5);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(118, 38);
            btn_Salir.TabIndex = 17;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = true;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(36, 336);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(38, 25);
            label7.TabIndex = 18;
            label7.Text = "Rol";
            // 
            // cmb_Rol
            // 
            cmb_Rol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Rol.Enabled = false;
            cmb_Rol.FormattingEnabled = true;
            cmb_Rol.Location = new Point(36, 364);
            cmb_Rol.Name = "cmb_Rol";
            cmb_Rol.Size = new Size(222, 33);
            cmb_Rol.TabIndex = 19;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.ForeColor = Color.FromArgb(192, 0, 0);
            btn_Eliminar.Location = new Point(420, 407);
            btn_Eliminar.Margin = new Padding(5);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(118, 38);
            btn_Eliminar.TabIndex = 20;
            btn_Eliminar.Text = "Eliminar";
            btn_Eliminar.UseVisualStyleBackColor = false;
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(36, 135);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 6;
            label3.Text = "Apellidos*";
            // 
            // txt_Apellido
            // 
            txt_Apellido.Enabled = false;
            txt_Apellido.Location = new Point(36, 165);
            txt_Apellido.Margin = new Padding(5);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(222, 32);
            txt_Apellido.TabIndex = 5;
            // 
            // frm_Usuarios
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 521);
            Controls.Add(btn_Eliminar);
            Controls.Add(cmb_Rol);
            Controls.Add(label7);
            Controls.Add(btn_Salir);
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Editar);
            Controls.Add(btn_Guardar);
            Controls.Add(chb_Estado);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txt_Contrasenia);
            Controls.Add(label4);
            Controls.Add(txt_Correo);
            Controls.Add(label3);
            Controls.Add(txt_Apellido);
            Controls.Add(label2);
            Controls.Add(btn_Nuevo);
            Controls.Add(txt_Nombre);
            Controls.Add(label1);
            Controls.Add(lst_Lista_Usuarios);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "frm_Usuarios";
            Text = "Gestión de Usuarios";
            Load += frm_Usuarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lst_Lista_Usuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Correo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Contrasenia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb_Estado;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_Rol;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Apellido;
    }
}