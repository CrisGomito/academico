using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Academico.Periodos
{
    partial class frm_Periodos
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
            lst_Lista_Periodos = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            btn_Nuevo = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            txt_Nombre = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            dtp_FechaInicio = new System.Windows.Forms.DateTimePicker();
            label4 = new System.Windows.Forms.Label();
            dtp_FechaFin = new System.Windows.Forms.DateTimePicker();
            label5 = new System.Windows.Forms.Label();
            cmb_Estado = new System.Windows.Forms.ComboBox();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Editar = new System.Windows.Forms.Button();
            btn_Cancelar = new System.Windows.Forms.Button();
            btn_Salir = new System.Windows.Forms.Button();
            btn_Eliminar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lst_Lista_Periodos
            // 
            lst_Lista_Periodos.FormattingEnabled = true;
            lst_Lista_Periodos.ItemHeight = 25;
            lst_Lista_Periodos.Location = new System.Drawing.Point(294, 68);
            lst_Lista_Periodos.Margin = new System.Windows.Forms.Padding(5);
            lst_Lista_Periodos.Name = "lst_Lista_Periodos";
            lst_Lista_Periodos.Size = new System.Drawing.Size(372, 329);
            lst_Lista_Periodos.TabIndex = 0;
            lst_Lista_Periodos.DoubleClick += lst_Lista_Periodos_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(200, 9);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(335, 25);
            label1.TabIndex = 1;
            label1.Text = "GESTIÓN DE PERIODOS ACADÉMICOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            label2.Location = new System.Drawing.Point(36, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(185, 25);
            label2.TabIndex = 4;
            label2.Text = "Nombre del Periodo*";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Enabled = false;
            txt_Nombre.Location = new System.Drawing.Point(36, 98);
            txt_Nombre.MaxLength = 30;
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new System.Drawing.Size(222, 32);
            txt_Nombre.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            label3.Location = new System.Drawing.Point(36, 145);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(121, 25);
            label3.TabIndex = 6;
            label3.Text = "Fecha Inicio*";
            // 
            // dtp_FechaInicio
            // 
            dtp_FechaInicio.Enabled = false;
            dtp_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtp_FechaInicio.Location = new System.Drawing.Point(36, 175);
            dtp_FechaInicio.Name = "dtp_FechaInicio";
            dtp_FechaInicio.Size = new System.Drawing.Size(222, 32);
            dtp_FechaInicio.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14F);
            label4.Location = new System.Drawing.Point(36, 222);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(100, 25);
            label4.TabIndex = 8;
            label4.Text = "Fecha Fin*";
            // 
            // dtp_FechaFin
            // 
            dtp_FechaFin.Enabled = false;
            dtp_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtp_FechaFin.Location = new System.Drawing.Point(36, 252);
            dtp_FechaFin.Name = "dtp_FechaFin";
            dtp_FechaFin.Size = new System.Drawing.Size(222, 32);
            dtp_FechaFin.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 14F);
            label5.Location = new System.Drawing.Point(36, 300);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(76, 25);
            label5.TabIndex = 10;
            label5.Text = "Estado*";
            // 
            // cmb_Estado
            // 
            cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_Estado.Enabled = false;
            cmb_Estado.FormattingEnabled = true;
            cmb_Estado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmb_Estado.Location = new System.Drawing.Point(36, 330);
            cmb_Estado.Name = "cmb_Estado";
            cmb_Estado.Size = new System.Drawing.Size(222, 33);
            cmb_Estado.TabIndex = 11;
            // 
            // btn_Nuevo
            // 
            btn_Nuevo.Location = new System.Drawing.Point(36, 469);
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
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new System.Drawing.Size(118, 38);
            btn_Salir.TabIndex = 17;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = true;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // frm_Periodos
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(694, 521);
            Controls.Add(cmb_Estado);
            Controls.Add(label5);
            Controls.Add(dtp_FechaFin);
            Controls.Add(label4);
            Controls.Add(dtp_FechaInicio);
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
            Controls.Add(lst_Lista_Periodos);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(5);
            Name = "frm_Periodos";
            Text = "Gestión de Periodos";
            Load += frm_Periodos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ListBox lst_Lista_Periodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_FechaInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_FechaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Estado;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Button btn_Eliminar;
    }
}