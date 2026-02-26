using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Academico.Asignaturas
{
    partial class frm_Asignaturas
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
            lst_Lista_Asignaturas = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            btn_Nuevo = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            txt_Nombre = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txt_Creditos = new System.Windows.Forms.TextBox();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Editar = new System.Windows.Forms.Button();
            btn_Cancelar = new System.Windows.Forms.Button();
            btn_Salir = new System.Windows.Forms.Button();
            btn_Eliminar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lst_Lista_Asignaturas
            // 
            lst_Lista_Asignaturas.FormattingEnabled = true;
            lst_Lista_Asignaturas.ItemHeight = 25;
            lst_Lista_Asignaturas.Location = new System.Drawing.Point(294, 68);
            lst_Lista_Asignaturas.Margin = new System.Windows.Forms.Padding(5);
            lst_Lista_Asignaturas.Name = "lst_Lista_Asignaturas";
            lst_Lista_Asignaturas.Size = new System.Drawing.Size(372, 329);
            lst_Lista_Asignaturas.TabIndex = 0;
            lst_Lista_Asignaturas.DoubleClick += lst_Lista_Asignaturas_DoubleClick;
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
            label1.Text = "GESTIÓN DE ASIGNATURAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            label2.Location = new System.Drawing.Point(36, 68);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(193, 25);
            label2.TabIndex = 4;
            label2.Text = "Nombre Asignatura*";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Enabled = false;
            txt_Nombre.Location = new System.Drawing.Point(36, 98);
            txt_Nombre.Margin = new System.Windows.Forms.Padding(5);
            txt_Nombre.MaxLength = 60;
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new System.Drawing.Size(222, 32);
            txt_Nombre.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            label3.Location = new System.Drawing.Point(36, 155);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(94, 25);
            label3.TabIndex = 6;
            label3.Text = "Créditos*";
            // 
            // txt_Creditos
            // 
            txt_Creditos.Enabled = false;
            txt_Creditos.Location = new System.Drawing.Point(36, 185);
            txt_Creditos.Margin = new System.Windows.Forms.Padding(5);
            txt_Creditos.MaxLength = 2;
            txt_Creditos.Name = "txt_Creditos";
            txt_Creditos.Size = new System.Drawing.Size(222, 32);
            txt_Creditos.TabIndex = 5;
            txt_Creditos.KeyPress += txt_Creditos_KeyPress;
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
            // frm_Asignaturas
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(694, 521);
            Controls.Add(txt_Creditos);
            Controls.Add(label3);
            Controls.Add(btn_Eliminar);
            Controls.Add(btn_Salir);
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Editar);
            Controls.Add(btn_Guardar);
            Controls.Add(txt_Nombre);
            Controls.Add(label2);
            Controls.Add(btn_Nuevo);
            Controls.Add(label1);
            Controls.Add(lst_Lista_Asignaturas);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(5);
            Name = "frm_Asignaturas";
            Text = "Gestión de Asignaturas";
            Load += frm_Asignaturas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ListBox lst_Lista_Asignaturas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Creditos;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Button btn_Eliminar;
    }
}