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
            pnlCabecera = new Panel();
            btnCerrar = new Button();
            lblTitulo = new Label();
            pnlContenedorCentral = new Panel();
            btn_Eliminar = new FontAwesome.Sharp.IconButton();
            btn_Cancelar = new FontAwesome.Sharp.IconButton();
            btn_Editar = new FontAwesome.Sharp.IconButton();
            btn_Guardar = new FontAwesome.Sharp.IconButton();
            btn_Nuevo = new FontAwesome.Sharp.IconButton();
            chb_Estado = new CheckBox();
            label6 = new Label();
            cmb_Rol = new ComboBox();
            label7 = new Label();
            txt_Contrasenia = new TextBox();
            label5 = new Label();
            txt_Correo = new TextBox();
            label4 = new Label();
            txt_Apellido = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txt_Nombre = new TextBox();
            lst_Lista_Usuarios = new ListBox();
            pnlCabecera.SuspendLayout();
            pnlContenedorCentral.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCabecera
            // 
            pnlCabecera.BackColor = Color.White;
            pnlCabecera.Controls.Add(btnCerrar);
            pnlCabecera.Controls.Add(lblTitulo);
            pnlCabecera.Dock = DockStyle.Top;
            pnlCabecera.Location = new Point(0, 0);
            pnlCabecera.Name = "pnlCabecera";
            pnlCabecera.Size = new Size(950, 50);
            pnlCabecera.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(915, 15);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(20, 20);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            btnCerrar.Paint += btnCerrar_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(950, 50);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "GESTIÓN DE USUARIOS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContenedorCentral
            // 
            pnlContenedorCentral.Anchor = AnchorStyles.Top;
            pnlContenedorCentral.BackColor = Color.White;
            pnlContenedorCentral.Controls.Add(btn_Eliminar);
            pnlContenedorCentral.Controls.Add(btn_Cancelar);
            pnlContenedorCentral.Controls.Add(btn_Editar);
            pnlContenedorCentral.Controls.Add(btn_Guardar);
            pnlContenedorCentral.Controls.Add(btn_Nuevo);
            pnlContenedorCentral.Controls.Add(chb_Estado);
            pnlContenedorCentral.Controls.Add(label6);
            pnlContenedorCentral.Controls.Add(cmb_Rol);
            pnlContenedorCentral.Controls.Add(label7);
            pnlContenedorCentral.Controls.Add(txt_Contrasenia);
            pnlContenedorCentral.Controls.Add(label5);
            pnlContenedorCentral.Controls.Add(txt_Correo);
            pnlContenedorCentral.Controls.Add(label4);
            pnlContenedorCentral.Controls.Add(txt_Apellido);
            pnlContenedorCentral.Controls.Add(label3);
            pnlContenedorCentral.Controls.Add(label2);
            pnlContenedorCentral.Controls.Add(txt_Nombre);
            pnlContenedorCentral.Controls.Add(lst_Lista_Usuarios);
            pnlContenedorCentral.Location = new Point(50, 70);
            pnlContenedorCentral.Name = "pnlContenedorCentral";
            pnlContenedorCentral.Size = new Size(850, 500);
            pnlContenedorCentral.TabIndex = 2;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.BackColor = Color.FromArgb(231, 76, 60);
            btn_Eliminar.FlatAppearance.BorderSize = 0;
            btn_Eliminar.FlatStyle = FlatStyle.Flat;
            btn_Eliminar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Eliminar.ForeColor = Color.White;
            btn_Eliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btn_Eliminar.IconColor = Color.White;
            btn_Eliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn_Eliminar.IconSize = 24;
            btn_Eliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Eliminar.Location = new Point(600, 420);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Padding = new Padding(10, 0, 0, 0);
            btn_Eliminar.Size = new Size(130, 40);
            btn_Eliminar.TabIndex = 20;
            btn_Eliminar.Text = " Eliminar";
            btn_Eliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Eliminar.UseVisualStyleBackColor = false;
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.BackColor = Color.FromArgb(149, 165, 166);
            btn_Cancelar.Enabled = false;
            btn_Cancelar.FlatAppearance.BorderSize = 0;
            btn_Cancelar.FlatStyle = FlatStyle.Flat;
            btn_Cancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Cancelar.ForeColor = Color.White;
            btn_Cancelar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btn_Cancelar.IconColor = Color.White;
            btn_Cancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn_Cancelar.IconSize = 24;
            btn_Cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Cancelar.Location = new Point(455, 420);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Padding = new Padding(10, 0, 0, 0);
            btn_Cancelar.Size = new Size(130, 40);
            btn_Cancelar.TabIndex = 16;
            btn_Cancelar.Text = " Cancelar";
            btn_Cancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Cancelar.UseVisualStyleBackColor = false;
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // btn_Editar
            // 
            btn_Editar.BackColor = Color.FromArgb(26, 188, 156);
            btn_Editar.FlatAppearance.BorderSize = 0;
            btn_Editar.FlatStyle = FlatStyle.Flat;
            btn_Editar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Editar.ForeColor = Color.White;
            btn_Editar.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btn_Editar.IconColor = Color.White;
            btn_Editar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn_Editar.IconSize = 24;
            btn_Editar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Editar.Location = new Point(320, 420);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Padding = new Padding(10, 0, 0, 0);
            btn_Editar.Size = new Size(120, 40);
            btn_Editar.TabIndex = 15;
            btn_Editar.Text = " Editar";
            btn_Editar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Editar.UseVisualStyleBackColor = false;
            btn_Editar.Click += btn_Editar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = Color.FromArgb(39, 174, 96);
            btn_Guardar.Enabled = false;
            btn_Guardar.FlatAppearance.BorderSize = 0;
            btn_Guardar.FlatStyle = FlatStyle.Flat;
            btn_Guardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Guardar.ForeColor = Color.White;
            btn_Guardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btn_Guardar.IconColor = Color.White;
            btn_Guardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn_Guardar.IconSize = 24;
            btn_Guardar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Guardar.Location = new Point(175, 420);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Padding = new Padding(10, 0, 0, 0);
            btn_Guardar.Size = new Size(130, 40);
            btn_Guardar.TabIndex = 14;
            btn_Guardar.Text = " Guardar";
            btn_Guardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Nuevo
            // 
            btn_Nuevo.BackColor = Color.FromArgb(52, 152, 219);
            btn_Nuevo.FlatAppearance.BorderSize = 0;
            btn_Nuevo.FlatStyle = FlatStyle.Flat;
            btn_Nuevo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Nuevo.ForeColor = Color.White;
            btn_Nuevo.IconChar = FontAwesome.Sharp.IconChar.Add;
            btn_Nuevo.IconColor = Color.White;
            btn_Nuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn_Nuevo.IconSize = 24;
            btn_Nuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Nuevo.Location = new Point(40, 420);
            btn_Nuevo.Name = "btn_Nuevo";
            btn_Nuevo.Padding = new Padding(10, 0, 0, 0);
            btn_Nuevo.Size = new Size(120, 40);
            btn_Nuevo.TabIndex = 3;
            btn_Nuevo.Text = " Nuevo";
            btn_Nuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Nuevo.UseVisualStyleBackColor = false;
            btn_Nuevo.Click += btn_Nuevo_Click;
            // 
            // chb_Estado
            // 
            chb_Estado.AutoSize = true;
            chb_Estado.Enabled = false;
            chb_Estado.Font = new Font("Segoe UI", 11F);
            chb_Estado.Location = new Point(240, 343);
            chb_Estado.Name = "chb_Estado";
            chb_Estado.Size = new Size(80, 24);
            chb_Estado.TabIndex = 13;
            chb_Estado.Text = "Inactivo";
            chb_Estado.UseVisualStyleBackColor = true;
            chb_Estado.CheckedChanged += chb_Estado_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(236, 315);
            label6.Name = "label6";
            label6.Size = new Size(62, 19);
            label6.TabIndex = 21;
            label6.Text = "ESTADO";
            // 
            // cmb_Rol
            // 
            cmb_Rol.BackColor = Color.WhiteSmoke;
            cmb_Rol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Rol.Enabled = false;
            cmb_Rol.FlatStyle = FlatStyle.Flat;
            cmb_Rol.Font = new Font("Segoe UI", 12F);
            cmb_Rol.FormattingEnabled = true;
            cmb_Rol.Location = new Point(40, 340);
            cmb_Rol.Name = "cmb_Rol";
            cmb_Rol.Size = new Size(180, 29);
            cmb_Rol.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(36, 315);
            label7.Name = "label7";
            label7.Size = new Size(36, 19);
            label7.TabIndex = 22;
            label7.Text = "ROL";
            // 
            // txt_Contrasenia
            // 
            txt_Contrasenia.BackColor = Color.WhiteSmoke;
            txt_Contrasenia.BorderStyle = BorderStyle.FixedSingle;
            txt_Contrasenia.Enabled = false;
            txt_Contrasenia.Font = new Font("Segoe UI", 12F);
            txt_Contrasenia.Location = new Point(40, 270);
            txt_Contrasenia.Name = "txt_Contrasenia";
            txt_Contrasenia.Size = new Size(300, 29);
            txt_Contrasenia.TabIndex = 9;
            txt_Contrasenia.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(36, 245);
            label5.Name = "label5";
            label5.Size = new Size(108, 19);
            label5.TabIndex = 23;
            label5.Text = "CONTRASEÑA*";
            // 
            // txt_Correo
            // 
            txt_Correo.BackColor = Color.WhiteSmoke;
            txt_Correo.BorderStyle = BorderStyle.FixedSingle;
            txt_Correo.Enabled = false;
            txt_Correo.Font = new Font("Segoe UI", 12F);
            txt_Correo.Location = new Point(40, 200);
            txt_Correo.Name = "txt_Correo";
            txt_Correo.Size = new Size(300, 29);
            txt_Correo.TabIndex = 7;
            txt_Correo.Leave += txt_Correo_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(36, 175);
            label4.Name = "label4";
            label4.Size = new Size(168, 19);
            label4.TabIndex = 24;
            label4.Text = "CORREO ELECTRÓNICO*";
            // 
            // txt_Apellido
            // 
            txt_Apellido.BackColor = Color.WhiteSmoke;
            txt_Apellido.BorderStyle = BorderStyle.FixedSingle;
            txt_Apellido.Enabled = false;
            txt_Apellido.Font = new Font("Segoe UI", 12F);
            txt_Apellido.Location = new Point(40, 130);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(300, 29);
            txt_Apellido.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(36, 105);
            label3.Name = "label3";
            label3.Size = new Size(88, 19);
            label3.TabIndex = 25;
            label3.Text = "APELLIDOS*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(36, 35);
            label2.Name = "label2";
            label2.Size = new Size(83, 19);
            label2.TabIndex = 26;
            label2.Text = "NOMBRES*";
            // 
            // txt_Nombre
            // 
            txt_Nombre.BackColor = Color.WhiteSmoke;
            txt_Nombre.BorderStyle = BorderStyle.FixedSingle;
            txt_Nombre.Enabled = false;
            txt_Nombre.Font = new Font("Segoe UI", 12F);
            txt_Nombre.Location = new Point(40, 60);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(300, 29);
            txt_Nombre.TabIndex = 2;
            // 
            // lst_Lista_Usuarios
            // 
            lst_Lista_Usuarios.BorderStyle = BorderStyle.None;
            lst_Lista_Usuarios.Font = new Font("Segoe UI", 12F);
            lst_Lista_Usuarios.ForeColor = Color.FromArgb(64, 64, 64);
            lst_Lista_Usuarios.FormattingEnabled = true;
            lst_Lista_Usuarios.ItemHeight = 21;
            lst_Lista_Usuarios.Location = new Point(380, 40);
            lst_Lista_Usuarios.Name = "lst_Lista_Usuarios";
            lst_Lista_Usuarios.Size = new Size(430, 336);
            lst_Lista_Usuarios.TabIndex = 0;
            lst_Lista_Usuarios.DoubleClick += lst_Lista_Usuarios_DoubleClick;
            // 
            // frm_Usuarios
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 246);
            ClientSize = new Size(950, 600);
            Controls.Add(pnlContenedorCentral);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_Usuarios";
            Text = "Gestión de Usuarios";
            Load += frm_Usuarios_Load;
            pnlCabecera.ResumeLayout(false);
            pnlContenedorCentral.ResumeLayout(false);
            pnlContenedorCentral.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorCentral;

        private System.Windows.Forms.ListBox lst_Lista_Usuarios;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Correo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Contrasenia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_Rol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb_Estado;

        private FontAwesome.Sharp.IconButton btn_Nuevo;
        private FontAwesome.Sharp.IconButton btn_Guardar;
        private FontAwesome.Sharp.IconButton btn_Editar;
        private FontAwesome.Sharp.IconButton btn_Cancelar;
        private FontAwesome.Sharp.IconButton btn_Eliminar;
    }
}