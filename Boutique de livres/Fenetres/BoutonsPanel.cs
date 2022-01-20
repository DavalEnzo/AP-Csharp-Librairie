using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boutique_de_livres.Fenetres;

namespace Boutique_de_livres
{
    public partial class BoutonsPanel : UserControl
    {
        private AdminPanel fenetrePrincipale;
        public BoutonsPanel(AdminPanel fenetrePrincipale)
        {
            InitializeComponent();
            this.fenetrePrincipale = fenetrePrincipale;
        }

        private void UtilisateurMenu_Click(object sender, EventArgs e)
        {
            fenetrePrincipale.panel1.Controls.Clear();
            Utilisateurs myForm = new Utilisateurs(fenetrePrincipale);
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void BoutonsPanel_Load(object sender, EventArgs e)
        {

        }

        private void EditeursMenu_Click(object sender, EventArgs e)
        {

        }

        private void StatMenu_Click(object sender, EventArgs e)
        {

        }

        private void CommentairesMenu_Click(object sender, EventArgs e)
        {
            fenetrePrincipale.panel1.Controls.Clear();
            Commentaires myForm = new Commentaires(fenetrePrincipale);
            fenetrePrincipale.panel2.Visible = false;
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void CommandesMenu_Click(object sender, EventArgs e)
        {

        }

        private void LivresMenu_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
