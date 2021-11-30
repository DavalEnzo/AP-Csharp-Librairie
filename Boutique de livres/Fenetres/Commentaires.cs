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
    public partial class Commentaires : UserControl
    {
        private AdminPanel fenetrePrincipale;

        MySqlConnection conn = new MySqlConnection("database=livres; server=localhost; user id = root; pwd=");
        public Commentaires(AdminPanel fenetre)
        {
            InitializeComponent();

            fenetrePrincipale = fenetre;

            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.CommandText = "SELECT idCommentaire, contenu, CONCAT(CONCAT(utilisateurs.prenom, ' '), utilisateurs.nom) AS utilisateur, bibliotheque.Titre, commentaires.date_heure, verif FROM `commentaires` LEFT JOIN bibliotheque USING (idLivre) LEFT JOIN utilisateurs USING (idUtilisateur) WHERE verif = 0"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                // Si la colonne est un string :  (si vous récupérez plusieurs résultats dans votre requête, incrémenter le 0 à 1, puis 2...)
                string idCommentaire = reader.GetString(0);
                string contenu  = reader.GetString(1);
                string utilisateur = reader.GetString(2);
                string titre = reader.GetString(3);
                string date_publication = reader.GetString(4);
                string approuve = reader.GetString(5);

                dataGridView1.ColumnCount = 6;
                dataGridView1.Columns[0].Name = "id Commentaire";
                dataGridView1.Columns[1].Name = "Contenu";
                dataGridView1.Columns[2].Name = "Utilisateur";
                dataGridView1.Columns[3].Name = "Titre du livre";
                dataGridView1.Columns[4].Name = "Date et heure de publication";
                dataGridView1.Columns[5].Name = "Approuvé ?";

                dataGridView1.Rows.Add(idCommentaire, contenu, utilisateur, titre, date_publication, approuve);

                // Si nullable, faire un GetValue au lieu de GetString sinon cause bug
            };

            conn.Close(); // Fermeture de la connexion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string idComm = (Convert.ToString(selectedRow.Cells["id Commentaire"].Value));
                string contenu = (Convert.ToString(selectedRow.Cells["Contenu"].Value));
                string Utilisateur = (Convert.ToString(selectedRow.Cells["Utilisateur"].Value));
                string titre = (Convert.ToString(selectedRow.Cells["Titre du livre"].Value));
                string date_heure = (Convert.ToString(selectedRow.Cells["Date et heure de publication"].Value));
                string approuve = (Convert.ToString(selectedRow.Cells["Approuvé ?"].Value));

                detailsCommentaire DetailsC = new detailsCommentaire(idComm, contenu, Utilisateur, titre, date_heure, approuve);
                DetailsC.Show();
                fenetrePrincipale.Hide();
            }
            else
            {
                MessageBox.Show("Aucune colonne sélectionnée");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BoutonsPanel myForm = new BoutonsPanel(fenetrePrincipale);
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Clear();
            fenetrePrincipale.panel2.Visible = true;
            fenetrePrincipale.panel1.Controls.Add(myForm);
            myForm.Show();
        }
    }
}
