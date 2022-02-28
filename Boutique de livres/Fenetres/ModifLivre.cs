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
    public partial class ModifLivre : Form
    {
        AdminPanel AdminPanel = new AdminPanel();
        MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd=");
        public ModifLivre(string Id, string Titre, string Prix, DateTime DateSortie, string TypeGenre, string Genre, string Editeur)
        {
            InitializeComponent();

            dateSortie.Value = DateSortie;


            titre.Text = Titre;

            titre.SelectionStart = 0;

            prix.Text = Prix;

            titrePage.Text = Id;

            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * from typeGenre LEFT JOIN genres USING(idGenre)";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string nomTypeGenre = reader.GetString(1);
                typeGenre.Items.Add(nomTypeGenre);              
                
                string nomGenre = reader.GetString(2);
                genre.Items.Add(nomTypeGenre);
            }

            conn.Close();

            typeGenre.SelectedIndex = typeGenre.Items.IndexOf(typeGenre);
        }

        private void ModifLivre_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.Parameters.AddWithValue("@libelle", typeGenre.Text);

            command.CommandText = "SELECT * from typeGenre WHERE libelle = @libelle";

            MySqlDataReader reader = command.ExecuteReader();

            int idTypeGenre = 0;

            while (reader.Read())
            {
                idTypeGenre = reader.GetInt32(0);
            }

            conn.Close();

            conn.Open();

            MySqlCommand insert = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            insert.Parameters.AddWithValue("@id", titrePage.Text);

            insert.Parameters.AddWithValue("@titre", titre.Text);

            insert.Parameters.AddWithValue("@prix", prix.Text);

            insert.Parameters.AddWithValue("@dateSortie", dateSortie.Text); // Ajout des VALUES de la requête

            insert.Parameters.AddWithValue("@idtypeGenre", idTypeGenre); // Ajout des VALUES de la requête

            insert.CommandText = "UPDATE livres SET Titre=@titre, Prix=@prix, date_sortie=@dateSortie, idtypeGenre = @idtypeGenre WHERE idLivre = @id";

            if (insert.ExecuteNonQuery() > 0) // Si requête réussie
            {
                MessageBox.Show("Modification effectuée !");
                this.Close();
                AdminPanel.Show();
            }
        }

        private void genre_Click(object sender, EventArgs e)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * from genres WHERE ";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string nomGenre = reader.GetString(1);
                genre.Items.Add(nomGenre);
            }

            conn.Close();

            //typeGenre.SelectedIndex = typeGenre.Items.IndexOf(Genre);
        }
    }
}
