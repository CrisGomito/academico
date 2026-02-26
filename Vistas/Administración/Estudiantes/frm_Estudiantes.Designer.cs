using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Administracion.Estudiantes
{
    partial class frm_Estudiantes
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

        private void InitializeComponent()
        {
            lst_Lista_Estudiantes = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            btn_Nuevo = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            txt_Cedula = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            chb_Estado = new System.Windows.Forms.CheckBox();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Editar = new System.Windows.Forms.Button();
            btn_Cancelar = new System.Windows.Forms.Button();
            btn_Salir = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            cmb_Usuario = new System.Windows.Forms.ComboBox();
            btn_Eliminar = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            txt_Codigo = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // lst_Lista_Estudiantes
            // 
            lst_Lista_Estudiantes.FormattingEnabled = true;
            lst_Lista_Estudiantes.ItemHeight = 25;
            lst_Lista_Estudiantes.Location = new System.Drawing.Point(294, 68);
            lst_Lista_Estudiantes.Margin = new System.Windows.Forms.Padding(5);
            lst_Lista_Estudiantes.Name = "lst_Lista_Estudiantes";
            lst_Lista_Estudiantes.Size = new System.Drawing.Size(372, 329);
            lst_Lista_Estudiantes.TabIndex = 0;
            lst_Lista_Estudiantes.DoubleClick += lst_Lista_Estudiantes_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(240, 9);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(256, 25);
            label1.TabIndex = 1;
            label1.Text = "GESTIÓN DE ESTUDIANTES";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 14F);
            label7.Location = new System.Drawing.Point(36, 68);
            label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(175, 25);
            label7.TabIndex = 18;
            label7.Text = "Usuario Vinculado*";
            // 
            // cmb_Usuario
            // 
            cmb_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_Usuario.Enabled = false;
            cmb_Usuario.FormattingEnabled = true;
            cmb_Usuario.Location = new System.Drawing.Point(36, 98);
            cmb_Usuario.Name = "cmb_Usuario";
            cmb_Usuario.Size = new System.Drawing.Size(222, 33);
            cmb_Usuario.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            label2.Location = new System.Drawing.Point(36, 145);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(188, 25);
            label2.TabIndex = 4;
            label2.Text = "Número de Cédula*";
            // 
            // txt_Cedula
            // 
            txt_Cedula.Enabled = false;
            txt_Cedula.Location = new System.Drawing.Point(36, 175);
            txt_Cedula.Margin = new System.Windows.Forms.Padding(5);
            txt_Cedula.MaxLength = 10;
            txt_Cedula.Name = "txt_Cedula";
            txt_Cedula.Size = new System.Drawing.Size(222, 32);
            txt_Cedula.TabIndex = 2;
            txt_Cedula.KeyPress += txt_Cedula_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            label3.Location = new System.Drawing.Point(36, 225);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(178, 25);
            label3.TabIndex = 22;
            label3.Text = "Código Estudiante*";
            // 
            // txt_Codigo
            // 
            txt_Codigo.Enabled = false;
            txt_Codigo.Location = new System.Drawing.Point(36, 255);
            txt_Codigo.Margin = new System.Windows.Forms.Padding(5);
            txt_Codigo.MaxLength = 20;
            txt_Codigo.Name = "txt_Codigo";
            txt_Codigo.Size = new System.Drawing.Size(222, 32);
            txt_Codigo.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 14F);
            label6.Location = new System.Drawing.Point(36, 305);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(166, 25);
            label6.TabIndex = 12;
            label6.Text = "Estado Estudiante";
            // 
            // chb_Estado
            // 
            chb_Estado.AutoSize = true;
            chb_Estado.Enabled = false;
            chb_Estado.Location = new System.Drawing.Point(36, 335);
            chb_Estado.Name = "chb_Estado";
            chb_Estado.Size = new System.Drawing.Size(96, 29);
            chb_Estado.TabIndex = 13;
            chb_Estado.Text = "Inactivo";
            chb_Estado.UseVisualStyleBackColor = true;
            chb_Estado.CheckedChanged += chb_Estado_CheckedChanged;
            // 
            // btn_Nuevo
            // 
            btn_Nuevo.Location = new System.Drawing.Point(36, 469);
            btn_Nuevo.Margin = new System.Windows.Forms.Padding(5);
            btn_Nuevo.Name = "btn_Nuevo";
            btn_Nuevo.Size = new System.Drawing.Size(118, 38);
            btn_Nuevo.TabIndex = 3;
            btn_Nuevo.Text = "Nuevo";
            btn_Nuevo.UseVisualStyleBackColor = true;
            btn_Nuevo.Click += btn_Nuevo_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Enabled = false;
            btn_Guardar.Location = new System.Drawing.Point(164, 469);
            btn_Guardar.Margin = new System.Windows.Forms.Padding(5);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(118, 38);
            btn_Guardar.TabIndex = 14;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Editar
            // 
            btn_Editar.Location = new System.Drawing.Point(292, 469);
            btn_Editar.Margin = new System.Windows.Forms.Padding(5);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new System.Drawing.Size(118, 38);
            btn_Editar.TabIndex = 15;
            btn_Editar.Text = "Editar";
            btn_Editar.UseVisualStyleBackColor = true;
            btn_Editar.Click += btn_Editar_Click;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btn_Eliminar.Location = new System.Drawing.Point(420, 407);
            btn_Eliminar.Margin = new System.Windows.Forms.Padding(5);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new System.Drawing.Size(118, 38);
            btn_Eliminar.TabIndex = 20;
            btn_Eliminar.Text = "Eliminar";
            btn_Eliminar.UseVisualStyleBackColor = false;
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.Enabled = false;
            btn_Cancelar.Location = new System.Drawing.Point(420, 469);
            btn_Cancelar.Margin = new System.Windows.Forms.Padding(5);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new System.Drawing.Size(118, 38);
            btn_Cancelar.TabIndex = 16;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.UseVisualStyleBackColor = true;
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // btn_Salir
            // 
            btn_Salir.Location = new System.Drawing.Point(548, 469);
            btn_Salir.Margin = new System.Windows.Forms.Padding(5);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new System.Drawing.Size(118, 38);
            btn_Salir.TabIndex = 17;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = true;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // frm_Estudiantes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(694, 521);
            Controls.Add(txt_Codigo);
            Controls.Add(label3);
            Controls.Add(btn_Eliminar);
            Controls.Add(cmb_Usuario);
            Controls.Add(label7);
            Controls.Add(btn_Salir);
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Editar);
            Controls.Add(btn_Guardar);
            Controls.Add(chb_Estado);
            Controls.Add(label6);
            Controls.Add(txt_Cedula);
            Controls.Add(label2);
            Controls.Add(btn_Nuevo);
            Controls.Add(label1);
            Controls.Add(lst_Lista_Estudiantes);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(5);
            Name = "frm_Estudiantes";
            Text = "Gestión de Estudiantes";
            Load += frm_Estudiantes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ListBox lst_Lista_Estudiantes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Cedula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb_Estado;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_Usuario;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Codigo;
    }
}