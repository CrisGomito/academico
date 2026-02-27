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
            pnlCard = new System.Windows.Forms.Panel();
            picAvatar = new System.Windows.Forms.PictureBox();
            lblNombreCompleto = new System.Windows.Forms.Label();
            lblRol = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblCorreo = new System.Windows.Forms.Label();
            btnCambiarCorreo = new System.Windows.Forms.Button();
            btnCambiarClave = new System.Windows.Forms.Button();
            btnEditarInfo = new System.Windows.Forms.Button();
            lblTitulo = new System.Windows.Forms.Label();

            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblTitulo.Location = new System.Drawing.Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(265, 30);
            lblTitulo.Text = "MI PERFIL DE USUARIO";

            // pnlCard
            pnlCard.BackColor = System.Drawing.Color.White;
            pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCard.Controls.Add(btnEditarInfo);
            pnlCard.Controls.Add(btnCambiarClave);
            pnlCard.Controls.Add(btnCambiarCorreo);
            pnlCard.Controls.Add(lblCorreo);
            pnlCard.Controls.Add(label1);
            pnlCard.Controls.Add(lblRol);
            pnlCard.Controls.Add(lblNombreCompleto);
            pnlCard.Controls.Add(picAvatar);
            // Centrado dinámico (se ajustará con anclajes o código, pero lo ponemos centrado a ojo para 1024x620)
            pnlCard.Location = new System.Drawing.Point(160, 100);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new System.Drawing.Size(700, 350);

            // picAvatar (Espacio futuro para icono)
            picAvatar.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picAvatar.Location = new System.Drawing.Point(50, 50);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new System.Drawing.Size(180, 180);
            picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // Aquí puedes agregar una imagen por defecto desde tus recursos si lo deseas

            // lblNombreCompleto
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblNombreCompleto.Location = new System.Drawing.Point(260, 50);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new System.Drawing.Size(262, 37);
            lblNombreCompleto.Text = "Nombre y Apellido";

            // lblRol
            lblRol.AutoSize = true;
            lblRol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            lblRol.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            lblRol.Location = new System.Drawing.Point(265, 90);
            lblRol.Name = "lblRol";
            lblRol.Size = new System.Drawing.Size(112, 21);
            lblRol.Text = "Rol del Usuario";

            // label1
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Gray;
            label1.Location = new System.Drawing.Point(265, 140);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(156, 21);
            label1.Text = "Correo Electrónico:";

            // lblCorreo
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            lblCorreo.Location = new System.Drawing.Point(265, 165);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new System.Drawing.Size(176, 25);
            lblCorreo.Text = "usuario@email.com";

            // btnCambiarCorreo
            btnCambiarCorreo.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            btnCambiarCorreo.FlatAppearance.BorderSize = 0;
            btnCambiarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCambiarCorreo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCambiarCorreo.Location = new System.Drawing.Point(265, 205);
            btnCambiarCorreo.Name = "btnCambiarCorreo";
            btnCambiarCorreo.Size = new System.Drawing.Size(150, 35);
            btnCambiarCorreo.Text = "Cambiar Correo";
            btnCambiarCorreo.UseVisualStyleBackColor = false;
            btnCambiarCorreo.Click += btnCambiarCorreo_Click;

            // btnCambiarClave
            btnCambiarClave.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            btnCambiarClave.FlatAppearance.BorderSize = 0;
            btnCambiarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCambiarClave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCambiarClave.Location = new System.Drawing.Point(430, 205);
            btnCambiarClave.Name = "btnCambiarClave";
            btnCambiarClave.Size = new System.Drawing.Size(180, 35);
            btnCambiarClave.Text = "Cambiar Contraseña";
            btnCambiarClave.UseVisualStyleBackColor = false;
            btnCambiarClave.Click += btnCambiarClave_Click;

            // btnEditarInfo
            btnEditarInfo.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnEditarInfo.FlatAppearance.BorderSize = 0;
            btnEditarInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEditarInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnEditarInfo.ForeColor = System.Drawing.Color.White;
            btnEditarInfo.Location = new System.Drawing.Point(50, 260);
            btnEditarInfo.Name = "btnEditarInfo";
            btnEditarInfo.Size = new System.Drawing.Size(180, 45);
            btnEditarInfo.Text = "Editar Información";
            btnEditarInfo.UseVisualStyleBackColor = false;
            // Para el futuro (lo dejamos inhabilitado o funcional si quieres agregar código rápido)
            btnEditarInfo.Enabled = false;

            // frm_InformacionGeneral
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(1024, 620);
            Controls.Add(pnlCard);
            Controls.Add(lblTitulo);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}