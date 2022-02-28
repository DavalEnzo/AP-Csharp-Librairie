
namespace Boutique_de_livres.Fenetres
{
    partial class detailsCommentaire
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
            this.TitreFenetre = new System.Windows.Forms.Label();
            this.nomUtilisateur = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.utilisateur = new System.Windows.Forms.Label();
            this.dateComm = new System.Windows.Forms.Label();
            this.commentaire = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitreFenetre
            // 
            this.TitreFenetre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitreFenetre.AutoSize = true;
            this.TitreFenetre.BackColor = System.Drawing.Color.Orange;
            this.TitreFenetre.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreFenetre.Location = new System.Drawing.Point(138, 19);
            this.TitreFenetre.Name = "TitreFenetre";
            this.TitreFenetre.Size = new System.Drawing.Size(479, 42);
            this.TitreFenetre.TabIndex = 1;
            this.TitreFenetre.Text = "Détails du commentaire n°";
            // 
            // nomUtilisateur
            // 
            this.nomUtilisateur.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nomUtilisateur.AutoSize = true;
            this.nomUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomUtilisateur.Location = new System.Drawing.Point(192, 104);
            this.nomUtilisateur.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nomUtilisateur.Name = "nomUtilisateur";
            this.nomUtilisateur.Size = new System.Drawing.Size(123, 29);
            this.nomUtilisateur.TabIndex = 16;
            this.nomUtilisateur.Text = "Publié par";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(301, 229);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Commentaire";
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(192, 157);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(232, 29);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Text = "Date de publication :";
            // 
            // utilisateur
            // 
            this.utilisateur.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.utilisateur.AutoSize = true;
            this.utilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilisateur.Location = new System.Drawing.Point(315, 104);
            this.utilisateur.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.utilisateur.Name = "utilisateur";
            this.utilisateur.Size = new System.Drawing.Size(0, 29);
            this.utilisateur.TabIndex = 17;
            // 
            // dateComm
            // 
            this.dateComm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateComm.AutoSize = true;
            this.dateComm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateComm.Location = new System.Drawing.Point(424, 157);
            this.dateComm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateComm.Name = "dateComm";
            this.dateComm.Size = new System.Drawing.Size(0, 29);
            this.dateComm.TabIndex = 18;
            // 
            // commentaire
            // 
            this.commentaire.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.commentaire.AutoSize = true;
            this.commentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.commentaire.Location = new System.Drawing.Point(145, 278);
            this.commentaire.MaximumSize = new System.Drawing.Size(500, 0);
            this.commentaire.Name = "commentaire";
            this.commentaire.Size = new System.Drawing.Size(2, 15);
            this.commentaire.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(90, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 32);
            this.button1.TabIndex = 20;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(306, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 32);
            this.button2.TabIndex = 21;
            this.button2.Text = "Approuver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(525, 374);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 32);
            this.button3.TabIndex = 22;
            this.button3.Text = "Supprimer Commentaire";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // id
            // 
            this.id.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.id.AutoSize = true;
            this.id.BackColor = System.Drawing.Color.Orange;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(610, 19);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(0, 42);
            this.id.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Orange;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 76);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // detailsCommentaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.id);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commentaire);
            this.Controls.Add(this.dateComm);
            this.Controls.Add(this.utilisateur);
            this.Controls.Add(this.nomUtilisateur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.TitreFenetre);
            this.Controls.Add(this.pictureBox1);
            this.Name = "detailsCommentaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Détail commentaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.detailsCommentaire_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitreFenetre;
        private System.Windows.Forms.Label nomUtilisateur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label utilisateur;
        private System.Windows.Forms.Label dateComm;
        private System.Windows.Forms.Label commentaire;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}