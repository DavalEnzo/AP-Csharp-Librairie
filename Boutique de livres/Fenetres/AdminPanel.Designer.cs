
namespace Boutique_de_livres
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.votreNom = new System.Windows.Forms.Label();
            this.MenuAdmin = new System.Windows.Forms.Panel();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.NomUtilisateur = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ClosePic = new System.Windows.Forms.PictureBox();
            this.MenuAdmin.SuspendLayout();
            this.UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosePic)).BeginInit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(539, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(941, 108);
            this.label1.TabIndex = 1;
            this.label1.Text = "Panel administrateur";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(363, 298);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 303);
            this.panel1.TabIndex = 3;
            // 
            // votreNom
            // 
            this.votreNom.AutoSize = true;
            this.votreNom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.votreNom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.votreNom.Location = new System.Drawing.Point(2, 1);
            this.votreNom.Name = "votreNom";
            this.votreNom.Size = new System.Drawing.Size(0, 13);
            this.votreNom.TabIndex = 4;
            // 
            // MenuAdmin
            // 
            this.MenuAdmin.BackColor = System.Drawing.Color.Navy;
            this.MenuAdmin.Controls.Add(this.UserPanel);
            this.MenuAdmin.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MenuAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuAdmin.Location = new System.Drawing.Point(0, 0);
            this.MenuAdmin.Name = "MenuAdmin";
            this.MenuAdmin.Size = new System.Drawing.Size(238, 739);
            this.MenuAdmin.TabIndex = 5;
            this.MenuAdmin.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuAdmin_Paint);
            // 
            // UserPanel
            // 
            this.UserPanel.BackColor = System.Drawing.Color.Transparent;
            this.UserPanel.Controls.Add(this.NomUtilisateur);
            this.UserPanel.Controls.Add(this.pictureBox1);
            this.UserPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserPanel.Location = new System.Drawing.Point(0, 0);
            this.UserPanel.MaximumSize = new System.Drawing.Size(239, 200);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(238, 154);
            this.UserPanel.TabIndex = 6;
            // 
            // NomUtilisateur
            // 
            this.NomUtilisateur.AutoSize = true;
            this.NomUtilisateur.ForeColor = System.Drawing.Color.White;
            this.NomUtilisateur.Location = new System.Drawing.Point(69, 113);
            this.NomUtilisateur.Name = "NomUtilisateur";
            this.NomUtilisateur.Size = new System.Drawing.Size(0, 13);
            this.NomUtilisateur.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Boutique_de_livres.Properties.Resources.profil;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(84, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ClosePic
            // 
            this.ClosePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClosePic.BackColor = System.Drawing.Color.Transparent;
            this.ClosePic.BackgroundImage = global::Boutique_de_livres.Properties.Resources.close;
            this.ClosePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClosePic.InitialImage = ((System.Drawing.Image)(resources.GetObject("ClosePic.InitialImage")));
            this.ClosePic.Location = new System.Drawing.Point(1392, 0);
            this.ClosePic.Name = "ClosePic";
            this.ClosePic.Size = new System.Drawing.Size(41, 39);
            this.ClosePic.TabIndex = 6;
            this.ClosePic.TabStop = false;
            this.ClosePic.Click += new System.EventHandler(this.ClosePic_Click_1);
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(281, 197);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(501, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 549);
            this.panel2.TabIndex = 4;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Boutique_de_livres.Properties.Resources.Settings_Metal;
            this.ClientSize = new System.Drawing.Size(1431, 739);
            this.Controls.Add(this.ClosePic);
            this.Controls.Add(this.MenuAdmin);
            this.Controls.Add(this.votreNom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Boutique_de_livres.Properties.Resources.Settings_Metal;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanel_FormClosed);
            this.MenuAdmin.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label votreNom;
        private System.Windows.Forms.Panel MenuAdmin;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label NomUtilisateur;
        private System.Windows.Forms.PictureBox ClosePic;
        public System.Windows.Forms.Panel panel2;
    }
}