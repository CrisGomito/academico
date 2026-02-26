using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Academico.AsignacionDocentes
{
    partial class frm_AsignacionDocentes
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
            lst_Lista_Asignaciones = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            btn_Nuevo = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            cmb_Docente = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cmb_Asignatura = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cmb_Periodo = new System.Windows.Forms.ComboBox();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Cancelar = new System.Windows.Forms.Button();
            btn_Salir = new System.Windows.Forms.Button();
            btn_Eliminar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lst_Lista_Asignaciones
            // 
            lst_Lista_Asignaciones.FormattingEnabled = true;
            lst_Lista_Asignaciones.ItemHeight = 25;
            lst_Lista_Asignaciones.Location = new System.Drawing.Point(354, 68);
            lst_Lista_Asignaciones.Margin = new System.Windows.Forms.Padding(5);
            lst_Lista_Asignaciones.Name = "lst_Lista_Asignaciones";
            lst_Lista_Asignaciones.Size = new System.Drawing.Size(430, 329);
            lst_Lista_Asignaciones.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(220, 9);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(350, 25);
            label1.TabIndex = 1;
            label1.Text = "ASIGNACIÓN DE DOCENTES A CURSOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            label2.Location = new System.Drawing.Point(36, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(91, 25);
            label2.TabIndex = 4;
            label2.Text = "Docente*";
            // 
            // cmb_Docente
            // 
            cmb_Docente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_Docente.Enabled = false;
            cmb_Docente.FormattingEnabled = true;
            cmb_Docente.Location = new System.Drawing.Point(36, 98);
            cmb_Docente.Name = "cmb_Docente";
            cmb_Docente.Size = new System.Drawing.Size(290, 33);
            cmb_Docente.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            label3.Location = new System.Drawing.Point(36, 155);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(113, 25);
            label3.TabIndex = 6;
            label3.Text = "Asignatura*";
            // 
            // cmb_Asignatura
            // 
            cmb_Asignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_Asignatura.Enabled = false;
            cmb_Asignatura.FormattingEnabled = true;
            cmb_Asignatura.Location = new System.Drawing.Point(36, 185);
            cmb_Asignatura.Name = "cmb_Asignatura";
            cmb_Asignatura.Size = new System.Drawing.Size(290, 33);
            cmb_Asignatura.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14F);
            label4.Location = new System.Drawing.Point(36, 245);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(185, 25);
            label4.TabIndex = 8;
            label4.Text = "Periodo Académico*";
            // 
            // cmb_Periodo
            // 
            cmb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_Periodo.Enabled = false;
            cmb_Periodo.FormattingEnabled = true;
            cmb_Periodo.Location = new System.Drawing.Point(36, 275);
            cmb_Periodo.Name = "cmb_Periodo";
            cmb_Periodo.Size = new System.Drawing.Size(290, 33);
            cmb_Periodo.TabIndex = 7;
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
            // btn_Eliminar
            // 
            btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btn_Eliminar.Location = new System.Drawing.Point(292, 469);
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
            // frm_AsignacionDocentes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(820, 530);
            Controls.Add(cmb_Periodo);
            Controls.Add(label4);
            Controls.Add(cmb_Asignatura);
            Controls.Add(label3);
            Controls.Add(cmb_Docente);
            Controls.Add(btn_Eliminar);
            Controls.Add(btn_Salir);
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Guardar);
            Controls.Add(label2);
            Controls.Add(btn_Nuevo);
            Controls.Add(label1);
            Controls.Add(lst_Lista_Asignaciones);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(5);
            Name = "frm_AsignacionDocentes";
            Text = "Asignación de Docentes";
            Load += frm_AsignacionDocentes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ListBox lst_Lista_Asignaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Docente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Asignatura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Periodo;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Button btn_Eliminar;
    }
}