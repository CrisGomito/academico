namespace DataBase_First.Views.Academico.Periodos
{
    partial class frm_Periodos
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
            this.lst_Lista_Periodos = new System.Windows.Forms.ListBox();

            this.label2 = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.TextBox();

            this.label3 = new System.Windows.Forms.Label();
            this.dtp_FechaInicio = new System.Windows.Forms.DateTimePicker();

            this.label4 = new System.Windows.Forms.Label();
            this.dtp_FechaFin = new System.Windows.Forms.DateTimePicker();

            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Estado = new System.Windows.Forms.ComboBox();

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
            this.lblTitulo.Text = "GESTIÓN DE PERIODOS ACADÉMICOS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // --- PANEL CONTENEDOR CENTRAL ---
            this.pnlContenedorCentral.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlContenedorCentral.BackColor = System.Drawing.Color.White;
            this.pnlContenedorCentral.Controls.Add(this.btn_Eliminar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Cancelar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Editar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Guardar);
            this.pnlContenedorCentral.Controls.Add(this.btn_Nuevo);
            this.pnlContenedorCentral.Controls.Add(this.cmb_Estado);
            this.pnlContenedorCentral.Controls.Add(this.label5);
            this.pnlContenedorCentral.Controls.Add(this.dtp_FechaFin);
            this.pnlContenedorCentral.Controls.Add(this.label4);
            this.pnlContenedorCentral.Controls.Add(this.dtp_FechaInicio);
            this.pnlContenedorCentral.Controls.Add(this.label3);
            this.pnlContenedorCentral.Controls.Add(this.txt_Nombre);
            this.pnlContenedorCentral.Controls.Add(this.label2);
            this.pnlContenedorCentral.Controls.Add(this.lst_Lista_Periodos);
            this.pnlContenedorCentral.Location = new System.Drawing.Point(50, 70);
            this.pnlContenedorCentral.Name = "pnlContenedorCentral";
            this.pnlContenedorCentral.Size = new System.Drawing.Size(850, 500);

            // lst_Lista_Periodos
            this.lst_Lista_Periodos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_Lista_Periodos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lst_Lista_Periodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_Lista_Periodos.FormattingEnabled = true;
            this.lst_Lista_Periodos.ItemHeight = 21;
            this.lst_Lista_Periodos.Location = new System.Drawing.Point(380, 40);
            this.lst_Lista_Periodos.Name = "lst_Lista_Periodos";
            this.lst_Lista_Periodos.Size = new System.Drawing.Size(430, 336);
            this.lst_Lista_Periodos.DoubleClick += new System.EventHandler(this.lst_Lista_Periodos_DoubleClick);

            // label2 (Nombre)
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(36, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 19);
            this.label2.Text = "NOMBRE DEL PERIODO*";

            // txt_Nombre
            this.txt_Nombre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nombre.Enabled = false;
            this.txt_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_Nombre.Location = new System.Drawing.Point(40, 65);
            this.txt_Nombre.MaxLength = 30;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(300, 29);

            // label3 (Fecha Inicio)
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(36, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.Text = "FECHA INICIO*";

            // dtp_FechaInicio
            this.dtp_FechaInicio.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke;
            this.dtp_FechaInicio.Enabled = false;
            this.dtp_FechaInicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtp_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaInicio.Location = new System.Drawing.Point(40, 135);
            this.dtp_FechaInicio.Name = "dtp_FechaInicio";
            this.dtp_FechaInicio.Size = new System.Drawing.Size(300, 29);

            // label4 (Fecha Fin)
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(36, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.Text = "FECHA FIN*";

            // dtp_FechaFin
            this.dtp_FechaFin.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke;
            this.dtp_FechaFin.Enabled = false;
            this.dtp_FechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtp_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaFin.Location = new System.Drawing.Point(40, 205);
            this.dtp_FechaFin.Name = "dtp_FechaFin";
            this.dtp_FechaFin.Size = new System.Drawing.Size(300, 29);

            // label5 (Estado)
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(36, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.Text = "ESTADO*";

            // cmb_Estado
            this.cmb_Estado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Estado.Enabled = false;
            this.cmb_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Estado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmb_Estado.FormattingEnabled = true;
            this.cmb_Estado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            this.cmb_Estado.Location = new System.Drawing.Point(40, 275);
            this.cmb_Estado.Name = "cmb_Estado";
            this.cmb_Estado.Size = new System.Drawing.Size(300, 29);

            // --- BOTONES MODERNOS ---
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

            // frm_Periodos
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.pnlContenedorCentral);
            this.Controls.Add(this.pnlCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Periodos";
            this.Text = "Gestión de Periodos";
            this.Load += new System.EventHandler(this.frm_Periodos_Load);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlContenedorCentral.ResumeLayout(false);
            this.pnlContenedorCentral.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorCentral;

        private System.Windows.Forms.ListBox lst_Lista_Periodos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_FechaInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_FechaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Estado;

        private FontAwesome.Sharp.IconButton btn_Nuevo;
        private FontAwesome.Sharp.IconButton btn_Guardar;
        private FontAwesome.Sharp.IconButton btn_Editar;
        private FontAwesome.Sharp.IconButton btn_Cancelar;
        private FontAwesome.Sharp.IconButton btn_Eliminar;
    }
}