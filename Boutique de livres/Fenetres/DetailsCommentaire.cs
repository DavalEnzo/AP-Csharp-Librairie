using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boutique_de_livres.dtos;
using Boutique_de_livres.Modeles;

namespace Boutique_de_livres.Fenetres
{
    public partial class detailsCommentaire : Form
    {
        AdminPanel AdminPanel = new AdminPanel();
        public detailsCommentaire(string idComm)
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            AdminPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce commentaire ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {

                int idCommentaire = Convert.ToInt32(id.Text);

                Modeles.Commentaires commentaires = new Modeles.Commentaires();

                commentaires.deleteCommentaire(idCommentaire);

                if (commentaires.deleteCommentaire(idCommentaire) == true) // Si requête réussie
                {
                    MessageBox.Show("Suppression effectuée");
                    Close();
                    AdminPanel.Show();
                }
                else
                {
                    MessageBox.Show("Erreur lors de le suppression !");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idCommentaire = Convert.ToInt32(id.Text);

            Modeles.Commentaires commentaire = new Modeles.Commentaires();

            commentaire.approveCommentaire(idCommentaire);

            if (commentaire.approveCommentaire(idCommentaire) == true) // Si requête réussie
            {
                MessageBox.Show("Commentaire approuvé !");
                Close();
                AdminPanel.Show();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'approbation du commentaire");
            }
        }

        private void detailsCommentaire_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.Show();
        }
    }
}
