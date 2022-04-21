
namespace Boutique_de_livres
{
    partial class BoutonsPanel
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoutonsPanel));
            this.DashBoardButton = new System.Windows.Forms.Button();
            this.CommentairesMenu = new System.Windows.Forms.Button();
            this.CommandesMenu = new System.Windows.Forms.Button();
            this.LivresMenu = new System.Windows.Forms.Button();
            this.UtilisateurMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DashBoardButton
            // 
            this.DashBoardButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DashBoardButton.FlatAppearance.BorderSize = 0;
            this.DashBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DashBoardButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashBoardButton.ForeColor = System.Drawing.Color.White;
            this.DashBoardButton.Image = global::Boutique_de_livres.Properties.Resources.abri;
            this.DashBoardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DashBoardButton.Location = new System.Drawing.Point(0, 396);
            this.DashBoardButton.Name = "DashBoardButton";
            this.DashBoardButton.Size = new System.Drawing.Size(190, 42);
            this.DashBoardButton.TabIndex = 15;
            this.DashBoardButton.Text = "DashBoard";
            this.DashBoardButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashBoardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.DashBoardButton.UseVisualStyleBackColor = true;
            this.DashBoardButton.Click += new System.EventHandler(this.DashBoardButton_Click);
            // 
            // CommentairesMenu
            // 
            this.CommentairesMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommentairesMenu.FlatAppearance.BorderSize = 0;
            this.CommentairesMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommentairesMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentairesMenu.ForeColor = System.Drawing.Color.White;
            this.CommentairesMenu.Image = ((System.Drawing.Image)(resources.GetObject("CommentairesMenu.Image")));
            this.CommentairesMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CommentairesMenu.Location = new System.Drawing.Point(0, 326);
            this.CommentairesMenu.Name = "CommentairesMenu";
            this.CommentairesMenu.Size = new System.Drawing.Size(190, 42);
            this.CommentairesMenu.TabIndex = 11;
            this.CommentairesMenu.Text = "Commentaires";
            this.CommentairesMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommentairesMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CommentairesMenu.UseVisualStyleBackColor = true;
            this.CommentairesMenu.Click += new System.EventHandler(this.CommentairesMenu_Click);
            // 
            // CommandesMenu
            // 
            this.CommandesMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandesMenu.FlatAppearance.BorderSize = 0;
            this.CommandesMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandesMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandesMenu.ForeColor = System.Drawing.Color.White;
            this.CommandesMenu.Image = global::Boutique_de_livres.Properties.Resources.clipboard;
            this.CommandesMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CommandesMenu.Location = new System.Drawing.Point(0, 284);
            this.CommandesMenu.Name = "CommandesMenu";
            this.CommandesMenu.Size = new System.Drawing.Size(190, 42);
            this.CommandesMenu.TabIndex = 10;
            this.CommandesMenu.Text = "Commandes";
            this.CommandesMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandesMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CommandesMenu.UseVisualStyleBackColor = true;
            this.CommandesMenu.Click += new System.EventHandler(this.CommandesMenu_Click);
            // 
            // LivresMenu
            // 
            this.LivresMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.LivresMenu.FlatAppearance.BorderSize = 0;
            this.LivresMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LivresMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LivresMenu.ForeColor = System.Drawing.Color.White;
            this.LivresMenu.Image = global::Boutique_de_livres.Properties.Resources.book;
            this.LivresMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LivresMenu.Location = new System.Drawing.Point(0, 242);
            this.LivresMenu.Name = "LivresMenu";
            this.LivresMenu.Size = new System.Drawing.Size(190, 42);
            this.LivresMenu.TabIndex = 9;
            this.LivresMenu.Text = "Livres";
            this.LivresMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LivresMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LivresMenu.UseVisualStyleBackColor = true;
            this.LivresMenu.Click += new System.EventHandler(this.LivresMenu_Click);
            // 
            // UtilisateurMenu
            // 
            this.UtilisateurMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.UtilisateurMenu.FlatAppearance.BorderSize = 0;
            this.UtilisateurMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UtilisateurMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UtilisateurMenu.ForeColor = System.Drawing.Color.White;
            this.UtilisateurMenu.Image = global::Boutique_de_livres.Properties.Resources.user;
            this.UtilisateurMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UtilisateurMenu.Location = new System.Drawing.Point(0, 200);
            this.UtilisateurMenu.Name = "UtilisateurMenu";
            this.UtilisateurMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UtilisateurMenu.Size = new System.Drawing.Size(190, 42);
            this.UtilisateurMenu.TabIndex = 8;
            this.UtilisateurMenu.Text = "Utilisateur";
            this.UtilisateurMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UtilisateurMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UtilisateurMenu.UseVisualStyleBackColor = true;
            this.UtilisateurMenu.Click += new System.EventHandler(this.UtilisateurMenu_Click);
            // 
            // BoutonsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DashBoardButton);
            this.Controls.Add(this.CommentairesMenu);
            this.Controls.Add(this.CommandesMenu);
            this.Controls.Add(this.LivresMenu);
            this.Controls.Add(this.UtilisateurMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BoutonsPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 200, 0, 0);
            this.Size = new System.Drawing.Size(190, 438);
            this.Load += new System.EventHandler(this.BoutonsPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UtilisateurMenu;
        private System.Windows.Forms.Button LivresMenu;
        private System.Windows.Forms.Button CommandesMenu;
        private System.Windows.Forms.Button CommentairesMenu;
        private System.Windows.Forms.Button DashBoardButton;

    }
}
