using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Boutique_de_livres.Fenetres
{
    public partial class detailsCommentaire : Form
    {
        AdminPanel AdminPanel = new AdminPanel();
        MySqlConnection conn = new MySqlConnection("database=livres; server=localhost; user id = root; pwd=");
        public detailsCommentaire(string idComm, string contenu, string Utilisateur, string titre, string date_heure, string approuve)
        {
            InitializeComponent();
            utilisateur.Text = Utilisateur;
            dateComm.Text = date_heure;
            commentaire.Text = contenu;
            id.Text = idComm;
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
                string idCommentaire = id.Text;

                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                conn.Open();

                // Add the parameter to the command collection
                command.Parameters.AddWithValue("@idCommentaire", idCommentaire);

                command.CommandText = "DELETE FROM commentaires WHERE idCommentaire = @idCommentaire"; // Ecriture requête

                if (command.ExecuteNonQuery() > 0) // Si requête réussie
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
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idCommentaire = id.Text;

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            conn.Open();

            // Add the parameter to the command collection
            command.Parameters.AddWithValue("@idCommentaire", idCommentaire);

            command.CommandText = "UPDATE commentaires SET verif = 1 WHERE idCommentaire = @idCommentaire"; // Ecriture requête

            if (command.ExecuteNonQuery() > 0) // Si requête réussie
            {
                MessageBox.Show("Commentaire approuvé !");
                Close();
                AdminPanel.Show();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'approbation du commentaire");
            }
            conn.Close();
        }
    }
}
