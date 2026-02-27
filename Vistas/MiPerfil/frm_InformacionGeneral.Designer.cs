using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataBase_First.Views.Perfil
{
    partial class frm_InformacionGeneral
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new Panel();
            btnCerrarPerfil = new Button();
            btnEditarInfo = new Button();
            btnCambiarClave = new Button();
            btnCambiarCorreo = new Button();
            lblCorreo = new Label();
            label1 = new Label();
            lblRol = new Label();
            lblNombreCompleto = new Label();
            picAvatar = new PictureBox();
            lblTitulo = new Label();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(btnCerrarPerfil);
            pnlCard.Controls.Add(btnEditarInfo);
            pnlCard.Controls.Add(btnCambiarClave);
            pnlCard.Controls.Add(btnCambiarCorreo);
            pnlCard.Controls.Add(lblCorreo);
            pnlCard.Controls.Add(label1);
            pnlCard.Controls.Add(lblRol);
            pnlCard.Controls.Add(lblNombreCompleto);
            pnlCard.Controls.Add(picAvatar);
            pnlCard.Location = new Point(160, 100);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(700, 350);
            pnlCard.TabIndex = 0;
            // 
            // btnCerrarPerfil
            // 
            btnCerrarPerfil.Location = new Point(620, 3);
            btnCerrarPerfil.Name = "btnCerrarPerfil";
            btnCerrarPerfil.Size = new Size(75, 23);
            btnCerrarPerfil.TabIndex = 8;
            btnCerrarPerfil.Text = "button1";
            btnCerrarPerfil.UseVisualStyleBackColor = true;
            btnCerrarPerfil.Click += btnCerrarPerfil_Click;
            // 
            // btnEditarInfo
            // 
            btnEditarInfo.BackColor = Color.FromArgb(52, 152, 219);
            btnEditarInfo.FlatAppearance.BorderSize = 0;
            btnEditarInfo.FlatStyle = FlatStyle.Flat;
            btnEditarInfo.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditarInfo.ForeColor = Color.White;
            btnEditarInfo.Location = new Point(50, 260);
            btnEditarInfo.Name = "btnEditarInfo";
            btnEditarInfo.Size = new Size(180, 45);
            btnEditarInfo.TabIndex = 0;
            btnEditarInfo.Text = "Editar Información";
            btnEditarInfo.UseVisualStyleBackColor = false;
            btnEditarInfo.Click += btnEditarInfo_Click;
            // 
            // btnCambiarClave
            // 
            btnCambiarClave.BackColor = Color.FromArgb(236, 240, 241);
            btnCambiarClave.FlatAppearance.BorderSize = 0;
            btnCambiarClave.FlatStyle = FlatStyle.Flat;
            btnCambiarClave.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            btnCambiarClave.Location = new Point(430, 205);
            btnCambiarClave.Name = "btnCambiarClave";
            btnCambiarClave.Size = new Size(180, 35);
            btnCambiarClave.TabIndex = 1;
            btnCambiarClave.Text = "Cambiar Contraseña";
            btnCambiarClave.UseVisualStyleBackColor = false;
            btnCambiarClave.Click += btnCambiarClave_Click;
            // 
            // btnCambiarCorreo
            // 
            btnCambiarCorreo.BackColor = Color.FromArgb(236, 240, 241);
            btnCambiarCorreo.FlatAppearance.BorderSize = 0;
            btnCambiarCorreo.FlatStyle = FlatStyle.Flat;
            btnCambiarCorreo.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            btnCambiarCorreo.Location = new Point(265, 205);
            btnCambiarCorreo.Name = "btnCambiarCorreo";
            btnCambiarCorreo.Size = new Size(150, 35);
            btnCambiarCorreo.TabIndex = 2;
            btnCambiarCorreo.Text = "Cambiar Correo";
            btnCambiarCorreo.UseVisualStyleBackColor = false;
            btnCambiarCorreo.Click += btnCambiarCorreo_Click;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new System.Drawing.Font("Segoe UI", 14F);
            lblCorreo.Location = new Point(265, 165);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(179, 25);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "usuario@email.com";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(265, 140);
            label1.Name = "label1";
            label1.Size = new Size(155, 21);
            label1.TabIndex = 4;
            label1.Text = "Correo Electrónico:";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblRol.ForeColor = Color.FromArgb(52, 152, 219);
            lblRol.Location = new Point(265, 90);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(116, 21);
            lblRol.TabIndex = 5;
            lblRol.Text = "Rol del Usuario";
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 20F, FontStyle.Bold);
            lblNombreCompleto.Location = new Point(260, 50);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(261, 37);
            lblNombreCompleto.TabIndex = 6;
            lblNombreCompleto.Text = "Nombre y Apellido";
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(236, 240, 241);
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(50, 50);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(180, 180);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 7;
            picAvatar.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(253, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "MI PERFIL DE USUARIO";
            // 
            // frm_InformacionGeneral
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1024, 620);
            Controls.Add(pnlCard);
            Controls.Add(lblTitulo);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_InformacionGeneral";
            Text = "Mi Perfil";
            Load += frm_InformacionGeneral_Load;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Button btnCambiarCorreo;
        private System.Windows.Forms.Button btnCambiarClave;
        private System.Windows.Forms.Button btnEditarInfo;
        private Button btnCerrarPerfil;
    }
}