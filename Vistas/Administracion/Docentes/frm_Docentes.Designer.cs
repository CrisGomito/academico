namespace DataBase_First.Views.Administracion.Docentes
{
    partial class frm_Docentes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlContenedorCentral = new System.Windows.Forms.Panel();
            this.lst_Lista_Docentes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Usuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Cedula = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chb_Estado = new System.Windows.Forms.CheckBox();
            this.btn_Nuevo = new FontAwesome.Sharp.IconButton();
            this.btn_Guardar = new FontAwesome.Sharp.IconButton();
            this.btn_Editar = new FontAwesome.Sharp.IconButton();
            this.btn_Cancelar = new FontAwesome.Sharp.IconButton();
            this.btn_Eliminar = new FontAwesome.Sharp.IconButton();

            this.pnlCabecera.SuspendLayout();
            this.pnlContenedorCentral.SuspendLayout();
            this.SuspendLayout();

            // --- PANEL CABECERA ---
            this.pnlCabecera.BackColor = System.Drawing.Color.White;
            this.pnlCabecera.Controls.Add(this.btnCerrar);
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(950, 50);

            // btnCerrar (Botón Circular Rojo)
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(915, 15);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.Paint += new System.Windows.Forms.PaintEventHandler(this.btnCerrar_Paint);

            // lblTitulo
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(950, 50);
            this.lblTitulo.Text = "GESTIÓN DE DOCENTES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // --- PANEL CONTENEDOR CENTRAL ---
            this.pnlContenedorCentral.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlContenedorCentral.BackColor = System.Drawing.Color.White;
            this.pnlContenedorCentral.Controls.Add(this.btn_Eliminar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Cancelar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Editar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Guardar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Nuevo);
            this.pnlContenedorCentral.Controls.Add(this.chb_Estado);
            this.pnlContenedorCentral.Controls.Add(this.label6);
            this.pnlContenedorCentral.Controls.Add(this.txt_Cedula);
            this.pnlContenedorCentral.Controls.Add(this.label3);
            this.pnlContenedorCentral.Controls.Add(this.cmb_Usuario);
            this.pnlContenedorCentral.Controls.Add(this.label2);
            this.pnlContenedorCentral.Controls.Add(this.lst_Lista_Docentes);
            this.pnlContenedorCentral.Location = new System.Drawing.Point(50, 70);
            this.pnlContenedorCentral.Name = "pnlContenedorCentral";
            this.pnlContenedorCentral.Size = new System.Drawing.Size(850, 500);

            // lst_Lista_Docentes
            this.lst_Lista_Docentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_Lista_Docentes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lst_Lista_Docentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_Lista_Docentes.FormattingEnabled = true;
            this.lst_Lista_Docentes.ItemHeight = 21;
            this.lst_Lista_Docentes.Location = new System.Drawing.Point(380, 40);
            this.lst_Lista_Docentes.Name = "lst_Lista_Docentes";
            this.lst_Lista_Docentes.Size = new System.Drawing.Size(430, 336);
            this.lst_Lista_Docentes.DoubleClick += new System.EventHandler(this.lst_Lista_Docentes_DoubleClick);

            // label2 (Usuario)
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(36, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 19);
            this.label2.Text = "VINCULAR A USUARIO*";

            // cmb_Usuario
            this.cmb_Usuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Usuario.Enabled = false;
            this.cmb_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Usuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmb_Usuario.Location = new System.Drawing.Point(40, 65);
            this.cmb_Usuario.Name = "cmb_Usuario";
            this.cmb_Usuario.Size = new System.Drawing.Size(300, 29);

            // label3 (Cédula)
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(36, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.Text = "CÉDULA*";

            // txt_Cedula
            this.txt_Cedula.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Cedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Cedula.Enabled = false;
            this.txt_Cedula.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_Cedula.Location = new System.Drawing.Point(40, 145);
            this.txt_Cedula.Name = "txt_Cedula";
            this.txt_Cedula.Size = new System.Drawing.Size(300, 29);
            this.txt_Cedula.MaxLength = 10;
            this.txt_Cedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Cedula_KeyPress);

            // label6 (Estado)
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(36, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.Text = "ESTADO";

            // chb_Estado
            this.chb_Estado.AutoSize = true;
            this.chb_Estado.Enabled = false;
            this.chb_Estado.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chb_Estado.Location = new System.Drawing.Point(40, 225);
            this.chb_Estado.Name = "chb_Estado";
            this.chb_Estado.Size = new System.Drawing.Size(79, 24);
            this.chb_Estado.Text = "Inactivo";
            this.chb_Estado.UseVisualStyleBackColor = true;
            this.chb_Estado.CheckedChanged += new System.EventHandler(this.chb_Estado_CheckedChanged);

            // --- BOTONES ---
            // btn_Nuevo
            this.btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_Nuevo.FlatAppearance.BorderSize = 0;
            this.btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Nuevo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Nuevo.ForeColor = System.Drawing.Color.White;
            this.btn_Nuevo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btn_Nuevo.IconColor = System.Drawing.Color.White;
            this.btn_Nuevo.IconSize = 24;
            this.btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Nuevo.Location = new System.Drawing.Point(40, 420);
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(120, 40);
            this.btn_Nuevo.Text = " Nuevo";
            this.btn_Nuevo.UseVisualStyleBackColor = false;
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);

            // btn_Guardar
            this.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Guardar.Enabled = false;
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btn_Guardar.IconColor = System.Drawing.Color.White;
            this.btn_Guardar.IconSize = 24;
            this.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Guardar.Location = new System.Drawing.Point(175, 420);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(130, 40);
            this.btn_Guardar.Text = " Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);

            // btn_Editar (Turquesa)
            this.btn_Editar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_Editar.FlatAppearance.BorderSize = 0;
            this.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Editar.ForeColor = System.Drawing.Color.White;
            this.btn_Editar.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btn_Editar.IconColor = System.Drawing.Color.White;
            this.btn_Editar.IconSize = 24;
            this.btn_Editar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Editar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Editar.Location = new System.Drawing.Point(320, 420);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(120, 40);
            this.btn_Editar.Text = " Editar";
            this.btn_Editar.UseVisualStyleBackColor = false;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);

            // btn_Cancelar
            this.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btn_Cancelar.Enabled = false;
            this.btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btn_Cancelar.IconColor = System.Drawing.Color.White;
            this.btn_Cancelar.IconSize = 24;
            this.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Cancelar.Location = new System.Drawing.Point(455, 420);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(130, 40);
            this.btn_Cancelar.Text = " Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);

            // btn_Eliminar
            this.btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btn_Eliminar.FlatAppearance.BorderSize = 0;
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Eliminar.ForeColor = System.Drawing.Color.White;
            this.btn_Eliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btn_Eliminar.IconColor = System.Drawing.Color.White;
            this.btn_Eliminar.IconSize = 24;
            this.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Eliminar.Location = new System.Drawing.Point(600, 420);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(130, 40);
            this.btn_Eliminar.Text = " Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);

            // frm_Docentes
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.pnlContenedorCentral);
            this.Controls.Add(this.pnlCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Docentes";
            this.Text = "Gestión de Docentes";
            this.Load += new System.EventHandler(this.frm_Docentes_Load);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlContenedorCentral.ResumeLayout(false);
            this.pnlContenedorCentral.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorCentral;

        private System.Windows.Forms.ListBox lst_Lista_Docentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Usuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Cedula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb_Estado;

        private FontAwesome.Sharp.IconButton btn_Nuevo;
        private FontAwesome.Sharp.IconButton btn_Guardar;
        private FontAwesome.Sharp.IconButton btn_Editar;
        private FontAwesome.Sharp.IconButton btn_Cancelar;
        private FontAwesome.Sharp.IconButton btn_Eliminar;
    }
}