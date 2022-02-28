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
    public partial class pageAccueil : UserControl
    {
        MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd=");

        private AdminPanel fenetrePrincipale;
        public pageAccueil(AdminPanel fenetre)
        {
            InitializeComponent();

            fenetrePrincipale = fenetre;

            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT count(*) FROM utilisateurs";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                nbUtilisateurs.Text = reader.GetString(0);

            }


            conn.Close();

            conn.Open();

            MySqlCommand commentaires = conn.CreateCommand();

            commentaires.CommandText = "CALL verif_commentaire()";

            MySqlDataReader comms = commentaires.ExecuteReader();

            while (comms.Read())
            {

                nbCommentaires.Text = comms.GetString(0);

            }


            conn.Close();

            conn.Open();

            MySqlCommand livres = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            livres.CommandText = "SELECT idLivre, Titre FROM livres ORDER BY date_heure DESC LIMIT 5"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader recupLivre = livres.ExecuteReader();

            while (recupLivre.Read())
            {

                // Si la colonne est un string :  (si vous récupérez plusieurs résultats dans votre requête, incrémenter le 0 à 1, puis 2...)
                string idLivre = recupLivre.GetString(0);
                string titre = recupLivre.GetString(1);

                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "id du livre";
                dataGridView1.Columns[1].Name = "Titre";

                dataGridView1.Rows.Add(idLivre, titre);

                // Si nullable, faire un GetValue au lieu de GetString sinon cause bug
            };

            conn.Close(); // Fermeture de la connexion
        }
    }
}
