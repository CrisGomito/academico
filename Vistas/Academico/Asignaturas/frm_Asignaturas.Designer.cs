namespace DataBase_First.Views.Academico.Asignaturas
{
    partial class frm_Asignaturas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

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
            txt_Creditos = new TextBox();
            label3 = new Label();
            txt_Nombre = new TextBox();
            label2 = new Label();
            lst_Lista_Asignaturas = new ListBox();
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
            pnlCabecera.Size = new Size(1175, 50);
            pnlCabecera.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(1140, 15);
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
            lblTitulo.Size = new Size(1175, 50);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "GESTIÓN DE ASIGNATURAS";
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
            pnlContenedorCentral.Controls.Add(txt_Creditos);
            pnlContenedorCentral.Controls.Add(label3);
            pnlContenedorCentral.Controls.Add(txt_Nombre);
            pnlContenedorCentral.Controls.Add(label2);
            pnlContenedorCentral.Controls.Add(lst_Lista_Asignaturas);
            pnlContenedorCentral.Location = new Point(137, 70);
            pnlContenedorCentral.Name = "pnlContenedorCentral";
            pnlContenedorCentral.Size = new Size(908, 500);
            pnlContenedorCentral.TabIndex = 0;
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
            btn_Eliminar.Location = new Point(744, 430);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(130, 40);
            btn_Eliminar.TabIndex = 0;
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
            btn_Cancelar.Location = new Point(571, 430);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(130, 40);
            btn_Cancelar.TabIndex = 1;
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
            btn_Editar.Location = new Point(401, 430);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new Size(120, 40);
            btn_Editar.TabIndex = 2;
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
            btn_Guardar.Location = new Point(216, 430);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(130, 40);
            btn_Guardar.TabIndex = 3;
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
            btn_Nuevo.Location = new Point(40, 430);
            btn_Nuevo.Name = "btn_Nuevo";
            btn_Nuevo.Size = new Size(120, 40);
            btn_Nuevo.TabIndex = 4;
            btn_Nuevo.Text = " Nuevo";
            btn_Nuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Nuevo.UseVisualStyleBackColor = false;
            btn_Nuevo.Click += btn_Nuevo_Click;
            // 
            // txt_Creditos
            // 
            txt_Creditos.BackColor = Color.WhiteSmoke;
            txt_Creditos.BorderStyle = BorderStyle.FixedSingle;
            txt_Creditos.Enabled = false;
            txt_Creditos.Font = new Font("Segoe UI", 12F);
            txt_Creditos.Location = new Point(40, 235);
            txt_Creditos.MaxLength = 2;
            txt_Creditos.Name = "txt_Creditos";
            txt_Creditos.Size = new Size(120, 29);
            txt_Creditos.TabIndex = 5;
            txt_Creditos.KeyPress += txt_Creditos_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(36, 210);
            label3.Name = "label3";
            label3.Size = new Size(80, 19);
            label3.TabIndex = 6;
            label3.Text = "CRÉDITOS*";
            // 
            // txt_Nombre
            // 
            txt_Nombre.BackColor = Color.WhiteSmoke;
            txt_Nombre.BorderStyle = BorderStyle.FixedSingle;
            txt_Nombre.Enabled = false;
            txt_Nombre.Font = new Font("Segoe UI", 12F);
            txt_Nombre.Location = new Point(40, 145);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(300, 29);
            txt_Nombre.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(36, 120);
            label2.Name = "label2";
            label2.Size = new Size(209, 19);
            label2.TabIndex = 8;
            label2.Text = "NOMBRE DE LA ASIGNATURA*";
            // 
            // lst_Lista_Asignaturas
            // 
            lst_Lista_Asignaturas.BorderStyle = BorderStyle.None;
            lst_Lista_Asignaturas.Font = new Font("Segoe UI", 12F);
            lst_Lista_Asignaturas.ForeColor = Color.FromArgb(64, 64, 64);
            lst_Lista_Asignaturas.FormattingEnabled = true;
            lst_Lista_Asignaturas.ItemHeight = 21;
            lst_Lista_Asignaturas.Location = new Point(380, 40);
            lst_Lista_Asignaturas.Name = "lst_Lista_Asignaturas";
            lst_Lista_Asignaturas.Size = new Size(494, 357);
            lst_Lista_Asignaturas.TabIndex = 9;
            lst_Lista_Asignaturas.DoubleClick += lst_Lista_Asignaturas_DoubleClick;
            // 
            // frm_Asignaturas
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 246);
            ClientSize = new Size(1175, 600);
            Controls.Add(pnlContenedorCentral);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_Asignaturas";
            Text = "Gestión de Asignaturas";
            Load += frm_Asignaturas_Load;
            pnlCabecera.ResumeLayout(false);
            pnlContenedorCentral.ResumeLayout(false);
            pnlContenedorCentral.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorCentral;

        private System.Windows.Forms.ListBox lst_Lista_Asignaturas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Creditos;

        private FontAwesome.Sharp.IconButton btn_Nuevo;
        private FontAwesome.Sharp.IconButton btn_Guardar;
        private FontAwesome.Sharp.IconButton btn_Editar;
        private FontAwesome.Sharp.IconButton btn_Cancelar;
        private FontAwesome.Sharp.IconButton btn_Eliminar;
    }
}