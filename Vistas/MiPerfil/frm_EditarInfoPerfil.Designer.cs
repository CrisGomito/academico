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
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtApellido = new TextBox();
            label4 = new Label();
            txtCorreo = new TextBox();
            btnValidarCorreo = new Button();
            txtCodigo = new TextBox();
            btnConfirmarCodigo = new Button();
            lblVerificado = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnCancelarValidacion = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(251, 30);
            label1.TabIndex = 12;
            label1.Text = "EDITAR INFORMACIÓN";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(391, 120);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 11;
            label2.Text = "Nombres";
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Left;
            txtNombre.Location = new Point(391, 150);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 32);
            txtNombre.TabIndex = 10;
            txtNombre.TextChanged += campos_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(711, 120);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 9;
            label3.Text = "Apellidos";
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Left;
            txtApellido.Location = new Point(711, 150);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(300, 32);
            txtApellido.TabIndex = 8;
            txtApellido.TextChanged += campos_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(391, 210);
            label4.Name = "label4";
            label4.Size = new Size(169, 25);
            label4.TabIndex = 7;
            label4.Text = "Correo Electrónico";
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Left;
            txtCorreo.Location = new Point(391, 240);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(300, 32);
            txtCorreo.TabIndex = 6;
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            // 
            // btnValidarCorreo
            // 
            btnValidarCorreo.Anchor = AnchorStyles.Left;
            btnValidarCorreo.BackColor = Color.FromArgb(52, 152, 219);
            btnValidarCorreo.FlatStyle = FlatStyle.Flat;
            btnValidarCorreo.ForeColor = Color.White;
            btnValidarCorreo.Location = new Point(701, 238);
            btnValidarCorreo.Name = "btnValidarCorreo";
            btnValidarCorreo.Size = new Size(100, 35);
            btnValidarCorreo.TabIndex = 5;
            btnValidarCorreo.Text = "Validar";
            btnValidarCorreo.UseVisualStyleBackColor = false;
            btnValidarCorreo.Visible = false;
            btnValidarCorreo.Click += btnValidarCorreo_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Anchor = AnchorStyles.Left;
            txtCodigo.Location = new Point(811, 240);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 32);
            txtCodigo.TabIndex = 4;
            txtCodigo.Visible = false;
            // 
            // btnConfirmarCodigo
            // 
            btnConfirmarCodigo.Anchor = AnchorStyles.Left;
            btnConfirmarCodigo.BackColor = Color.FromArgb(39, 174, 96);
            btnConfirmarCodigo.FlatStyle = FlatStyle.Flat;
            btnConfirmarCodigo.ForeColor = Color.White;
            btnConfirmarCodigo.Location = new Point(921, 238);
            btnConfirmarCodigo.Name = "btnConfirmarCodigo";
            btnConfirmarCodigo.Size = new Size(100, 35);
            btnConfirmarCodigo.TabIndex = 3;
            btnConfirmarCodigo.Text = "Ok";
            btnConfirmarCodigo.UseVisualStyleBackColor = false;
            btnConfirmarCodigo.Visible = false;
            btnConfirmarCodigo.Click += btnConfirmarCodigo_Click;
            // 
            // lblVerificado
            // 
            lblVerificado.Anchor = AnchorStyles.Left;
            lblVerificado.AutoSize = true;
            lblVerificado.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            lblVerificado.ForeColor = Color.FromArgb(39, 174, 96);
            lblVerificado.Location = new Point(701, 245);
            lblVerificado.Name = "lblVerificado";
            lblVerificado.Size = new Size(105, 21);
            lblVerificado.TabIndex = 2;
            lblVerificado.Text = "✓ Verificado";
            lblVerificado.Visible = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Left;
            btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
            btnGuardar.Enabled = false;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(391, 350);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 40);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Left;
            btnCancelar.BackColor = Color.Silver;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(551, 350);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 40);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnCancelarValidacion
            // 
            btnCancelarValidacion.Anchor = AnchorStyles.Left;
            btnCancelarValidacion.BackColor = Color.FromArgb(231, 76, 60);
            btnCancelarValidacion.FlatStyle = FlatStyle.Flat;
            btnCancelarValidacion.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelarValidacion.ForeColor = Color.White;
            btnCancelarValidacion.Location = new Point(1026, 238);
            btnCancelarValidacion.Name = "btnCancelarValidacion";
            btnCancelarValidacion.Size = new Size(35, 35);
            btnCancelarValidacion.TabIndex = 13;
            btnCancelarValidacion.Text = "X";
            btnCancelarValidacion.UseVisualStyleBackColor = false;
            btnCancelarValidacion.Visible = false;
            btnCancelarValidacion.Click += btnCancelarValidacion_Click;
            // 
            // frm_EditarInfoPerfil
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 590);
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
            Controls.Add(btnCancelarValidacion);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_EditarInfoPerfil";
            Text = "Editar Perfil";
            FormClosing += frm_EditarInfoPerfil_FormClosing;
            Load += frm_EditarInfoPerfil_Load;
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
        private System.Windows.Forms.Button btnCancelarValidacion; // NUEVO
        private bool _huboCambios = false;
    }
}