namespace Boutique_de_livres.Fenetres
{
    partial class Utilisateurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utilisateurs));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.searchName = new System.Windows.Forms.TextBox();
            this.selectSearch = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.titreFenetre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(126, 193);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(757, 227);
            this.dataGridView1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rechercher par :";
            // 
            // searchName
            // 
            this.searchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchName.Location = new System.Drawing.Point(607, 98);
            this.searchName.Margin = new System.Windows.Forms.Padding(2);
            this.searchName.Name = "searchName";
            this.searchName.Size = new System.Drawing.Size(254, 21);
            this.searchName.TabIndex = 9;
            this.searchName.TextChanged += new System.EventHandler(this.searchName_TextChanged);
            // 
            // selectSearch
            // 
            this.selectSearch.BackColor = System.Drawing.Color.White;
            this.selectSearch.FormattingEnabled = true;
            this.selectSearch.Items.AddRange(new object[] {
            "Identifiant",
            "Prénom",
            "Nom",
            "Email"});
            this.selectSearch.Location = new System.Drawing.Point(422, 98);
            this.selectSearch.Margin = new System.Windows.Forms.Padding(2);
            this.selectSearch.Name = "selectSearch";
            this.selectSearch.Size = new System.Drawing.Size(147, 21);
            this.selectSearch.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(53, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 54);
            this.button1.TabIndex = 13;
            this.button1.Text = "Retour";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(161, 80);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(529, 442);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 43);
            this.button3.TabIndex = 7;
            this.button3.Text = "Modifier Utilisateur";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(332, 442);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(155, 43);
            this.button2.TabIndex = 6;
            this.button2.Text = "Supprimer Utilisateur";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // titreFenetre
            // 
            this.titreFenetre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titreFenetre.AutoSize = true;
            this.titreFenetre.BackColor = System.Drawing.Color.White;
            this.titreFenetre.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreFenetre.Location = new System.Drawing.Point(323, 11);
            this.titreFenetre.Name = "titreFenetre";
            this.titreFenetre.Size = new System.Drawing.Size(430, 42);
            this.titreFenetre.TabIndex = 14;
            this.titreFenetre.Text = "Gestion des utilisateurs";
            // 
            // Utilisateurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.titreFenetre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Location = new System.Drawing.Point(396, 49);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Utilisateurs";
            this.Size = new System.Drawing.Size(1018, 557);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchName;
        private System.Windows.Forms.ComboBox selectSearch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label titreFenetre;
    }
}