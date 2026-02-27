using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Perfil
{
    partial class frm_EditarInfoPerfil
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtApellido = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtCorreo = new System.Windows.Forms.TextBox();
            btnValidarCorreo = new System.Windows.Forms.Button();
            txtCodigo = new System.Windows.Forms.TextBox();
            btnConfirmarCodigo = new System.Windows.Forms.Button();
            lblVerificado = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            label1.Location = new System.Drawing.Point(50, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(250, 30);
            label1.Text = "EDITAR INFORMACIÓN";

            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(50, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 25);
            label2.Text = "Nombres";

            txtNombre.Location = new System.Drawing.Point(50, 120);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(300, 32);
            txtNombre.TextChanged += campos_TextChanged;

            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(370, 90);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(90, 25);
            label3.Text = "Apellidos";

            txtApellido.Location = new System.Drawing.Point(370, 120);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new System.Drawing.Size(300, 32);
            txtApellido.TextChanged += campos_TextChanged;

            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(50, 180);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(169, 25);
            label4.Text = "Correo Electrónico";

            txtCorreo.Location = new System.Drawing.Point(50, 210);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new System.Drawing.Size(300, 32);
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            txtCorreo.Leave += txtCorreo_Leave;

            btnValidarCorreo.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnValidarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnValidarCorreo.ForeColor = System.Drawing.Color.White;
            btnValidarCorreo.Location = new System.Drawing.Point(360, 208);
            btnValidarCorreo.Name = "btnValidarCorreo";
            btnValidarCorreo.Size = new System.Drawing.Size(100, 35);
            btnValidarCorreo.Text = "Validar";
            btnValidarCorreo.UseVisualStyleBackColor = false;
            btnValidarCorreo.Visible = false;
            btnValidarCorreo.Click += btnValidarCorreo_Click;

            txtCodigo.Location = new System.Drawing.Point(470, 210);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new System.Drawing.Size(100, 32);
            txtCodigo.Visible = false;

            btnConfirmarCodigo.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnConfirmarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirmarCodigo.ForeColor = System.Drawing.Color.White;
            btnConfirmarCodigo.Location = new System.Drawing.Point(580, 208);
            btnConfirmarCodigo.Name = "btnConfirmarCodigo";
            btnConfirmarCodigo.Size = new System.Drawing.Size(100, 35);
            btnConfirmarCodigo.Text = "Ok";
            btnConfirmarCodigo.UseVisualStyleBackColor = false;
            btnConfirmarCodigo.Visible = false;
            btnConfirmarCodigo.Click += btnConfirmarCodigo_Click;

            lblVerificado.AutoSize = true;
            lblVerificado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblVerificado.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            lblVerificado.Location = new System.Drawing.Point(360, 215);
            lblVerificado.Name = "lblVerificado";
            lblVerificado.Size = new System.Drawing.Size(104, 21);
            lblVerificado.Text = "✓ Verificado";
            lblVerificado.Visible = false;

            btnGuardar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnGuardar.Enabled = false; // Solo se habilita si hay cambios
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(50, 320);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(140, 40);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.BackColor = System.Drawing.Color.Silver;
            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(210, 320);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(140, 40);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(800, 500);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblVerificado);
            Controls.Add(btnConfirmarCodigo);
            Controls.Add(txtCodigo);
            Controls.Add(btnValidarCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(label4);
            Controls.Add(txtApellido);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "frm_EditarInfoPerfil";
            Text = "Editar Perfil";
            Load += frm_EditarInfoPerfil_Load;
            FormClosing += frm_EditarInfoPerfil_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button btnValidarCorreo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnConfirmarCodigo;
        private System.Windows.Forms.Label lblVerificado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}