namespace DataBase_First.Views.Academico.Matriculas
{
    partial class frm_Matriculas
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
            btn_Guardar = new FontAwesome.Sharp.IconButton();
            btn_Nuevo = new FontAwesome.Sharp.IconButton();
            cmb_Periodo = new ComboBox();
            label4 = new Label();
            cmb_Asignatura = new ComboBox();
            label3 = new Label();
            cmb_Estudiante = new ComboBox();
            label2 = new Label();
            lst_Lista_Matriculas = new ListBox();
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
            lblTitulo.Text = "GESTIÓN DE MATRÍCULAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContenedorCentral
            // 
            pnlContenedorCentral.Anchor = AnchorStyles.Top;
            pnlContenedorCentral.BackColor = Color.White;
            pnlContenedorCentral.Controls.Add(btn_Eliminar);
            pnlContenedorCentral.Controls.Add(btn_Cancelar);
            pnlContenedorCentral.Controls.Add(btn_Guardar);
            pnlContenedorCentral.Controls.Add(btn_Nuevo);
            pnlContenedorCentral.Controls.Add(cmb_Periodo);
            pnlContenedorCentral.Controls.Add(label4);
            pnlContenedorCentral.Controls.Add(cmb_Asignatura);
            pnlContenedorCentral.Controls.Add(label3);
            pnlContenedorCentral.Controls.Add(cmb_Estudiante);
            pnlContenedorCentral.Controls.Add(label2);
            pnlContenedorCentral.Controls.Add(lst_Lista_Matriculas);
            pnlContenedorCentral.Location = new Point(12, 70);
            pnlContenedorCentral.Name = "pnlContenedorCentral";
            pnlContenedorCentral.Size = new Size(1148, 500);
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
            btn_Eliminar.Location = new Point(992, 439);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(130, 40);
            btn_Eliminar.TabIndex = 0;
            btn_Eliminar.Text = " Anular";
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
            btn_Cancelar.Location = new Point(668, 439);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(130, 40);
            btn_Cancelar.TabIndex = 1;
            btn_Cancelar.Text = " Cancelar";
            btn_Cancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Cancelar.UseVisualStyleBackColor = false;
            btn_Cancelar.Click += btn_Cancelar_Click;
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
            btn_Guardar.Location = new Point(347, 439);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(130, 40);
            btn_Guardar.TabIndex = 2;
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
            btn_Nuevo.Location = new Point(40, 439);
            btn_Nuevo.Name = "btn_Nuevo";
            btn_Nuevo.Size = new Size(120, 40);
            btn_Nuevo.TabIndex = 3;
            btn_Nuevo.Text = " Nuevo";
            btn_Nuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Nuevo.UseVisualStyleBackColor = false;
            btn_Nuevo.Click += btn_Nuevo_Click;
            // 
            // cmb_Periodo
            // 
            cmb_Periodo.BackColor = Color.WhiteSmoke;
            cmb_Periodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Periodo.Enabled = false;
            cmb_Periodo.FlatStyle = FlatStyle.Flat;
            cmb_Periodo.Font = new Font("Segoe UI", 12F);
            cmb_Periodo.Location = new Point(40, 225);
            cmb_Periodo.Name = "cmb_Periodo";
            cmb_Periodo.Size = new Size(320, 29);
            cmb_Periodo.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(36, 200);
            label4.Name = "label4";
            label4.Size = new Size(163, 19);
            label4.TabIndex = 5;
            label4.Text = "PERIODO ACADÉMICO*";
            // 
            // cmb_Asignatura
            // 
            cmb_Asignatura.BackColor = Color.WhiteSmoke;
            cmb_Asignatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Asignatura.Enabled = false;
            cmb_Asignatura.FlatStyle = FlatStyle.Flat;
            cmb_Asignatura.Font = new Font("Segoe UI", 12F);
            cmb_Asignatura.Location = new Point(40, 145);
            cmb_Asignatura.Name = "cmb_Asignatura";
            cmb_Asignatura.Size = new Size(320, 29);
            cmb_Asignatura.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(36, 120);
            label3.Name = "label3";
            label3.Size = new Size(103, 19);
            label3.TabIndex = 7;
            label3.Text = "ASIGNATURA*";
            // 
            // cmb_Estudiante
            // 
            cmb_Estudiante.BackColor = Color.WhiteSmoke;
            cmb_Estudiante.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Estudiante.Enabled = false;
            cmb_Estudiante.FlatStyle = FlatStyle.Flat;
            cmb_Estudiante.Font = new Font("Segoe UI", 12F);
            cmb_Estudiante.Location = new Point(40, 65);
            cmb_Estudiante.Name = "cmb_Estudiante";
            cmb_Estudiante.Size = new Size(320, 29);
            cmb_Estudiante.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(36, 40);
            label2.Name = "label2";
            label2.Size = new Size(98, 19);
            label2.TabIndex = 9;
            label2.Text = "ESTUDIANTE*";
            // 
            // lst_Lista_Matriculas
            // 
            lst_Lista_Matriculas.BorderStyle = BorderStyle.None;
            lst_Lista_Matriculas.Font = new Font("Segoe UI", 12F);
            lst_Lista_Matriculas.ForeColor = Color.FromArgb(64, 64, 64);
            lst_Lista_Matriculas.FormattingEnabled = true;
            lst_Lista_Matriculas.ItemHeight = 21;
            lst_Lista_Matriculas.Location = new Point(395, 40);
            lst_Lista_Matriculas.Name = "lst_Lista_Matriculas";
            lst_Lista_Matriculas.Size = new Size(727, 357);
            lst_Lista_Matriculas.TabIndex = 10;
            lst_Lista_Matriculas.DoubleClick += lst_Lista_Matriculas_DoubleClick;
            // 
            // frm_Matriculas
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 246);
            ClientSize = new Size(1175, 650);
            Controls.Add(pnlContenedorCentral);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_Matriculas";
            Text = "Gestión de Matrículas";
            Load += frm_Matriculas_Load;
            pnlCabecera.ResumeLayout(false);
            pnlContenedorCentral.ResumeLayout(false);
            pnlContenedorCentral.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorCentral;

        private System.Windows.Forms.ListBox lst_Lista_Matriculas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Estudiante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Asignatura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Periodo;

        private FontAwesome.Sharp.IconButton btn_Nuevo;
        private FontAwesome.Sharp.IconButton btn_Guardar;
        private FontAwesome.Sharp.IconButton btn_Cancelar;
        private FontAwesome.Sharp.IconButton btn_Eliminar;
    }
}