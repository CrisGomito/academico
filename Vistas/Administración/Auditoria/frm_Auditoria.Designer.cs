using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Administracion.Auditoria
{
    partial class frm_Auditoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            label1 = new System.Windows.Forms.Label();
            dgv_Auditoria = new System.Windows.Forms.DataGridView();
            btn_Salir = new System.Windows.Forms.Button();
            txt_Buscar = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            btn_Actualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgv_Auditoria).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(31, 18);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(242, 25);
            label1.TabIndex = 2;
            label1.Text = "AUDITORÍA DEL SISTEMA";
            // 
            // dgv_Auditoria
            // 
            dgv_Auditoria.AllowUserToAddRows = false;
            dgv_Auditoria.AllowUserToDeleteRows = false;
            dgv_Auditoria.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgv_Auditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Auditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv_Auditoria.DefaultCellStyle = dataGridViewCellStyle1;
            dgv_Auditoria.Location = new System.Drawing.Point(36, 120);
            dgv_Auditoria.Name = "dgv_Auditoria";
            dgv_Auditoria.ReadOnly = true;
            dgv_Auditoria.RowHeadersVisible = false;
            dgv_Auditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_Auditoria.Size = new System.Drawing.Size(950, 420);
            dgv_Auditoria.TabIndex = 3;
            // 
            // btn_Salir
            // 
            btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Salir.Location = new System.Drawing.Point(868, 560);
            btn_Salir.Margin = new System.Windows.Forms.Padding(5);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new System.Drawing.Size(118, 38);
            btn_Salir.TabIndex = 18;
            btn_Salir.Text = "Cerrar";
            btn_Salir.UseVisualStyleBackColor = true;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // txt_Buscar
            // 
            txt_Buscar.Location = new System.Drawing.Point(109, 68);
            txt_Buscar.Name = "txt_Buscar";
            txt_Buscar.Size = new System.Drawing.Size(300, 32);
            txt_Buscar.TabIndex = 19;
            txt_Buscar.TextChanged += txt_Buscar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(31, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 25);
            label2.TabIndex = 20;
            label2.Text = "Buscar:";
            // 
            // btn_Actualizar
            // 
            btn_Actualizar.Location = new System.Drawing.Point(426, 65);
            btn_Actualizar.Name = "btn_Actualizar";
            btn_Actualizar.Size = new System.Drawing.Size(120, 35);
            btn_Actualizar.TabIndex = 21;
            btn_Actualizar.Text = "Actualizar";
            btn_Actualizar.UseVisualStyleBackColor = true;
            btn_Actualizar.Click += btn_Actualizar_Click;
            // 
            // frm_Auditoria
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1024, 620);
            Controls.Add(btn_Actualizar);
            Controls.Add(label2);
            Controls.Add(txt_Buscar);
            Controls.Add(btn_Salir);
            Controls.Add(dgv_Auditoria);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(5);
            Name = "frm_Auditoria";
            Text = "Auditoría del Sistema";
            Load += frm_Auditoria_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Auditoria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Auditoria;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Actualizar;
    }
}