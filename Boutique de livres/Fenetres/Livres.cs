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
    public partial class Livres : UserControl
    { 

        private AdminPanel fenetrePrincipale;
        MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd=");
        public Livres(AdminPanel fenetre)
        {
            InitializeComponent();

            selectSearch.SelectedIndex = 0;

            fenetrePrincipale = fenetre;

            dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;

            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur ORDER BY titre ASC";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string idLivre = reader.GetString(0);
                string titre = reader.GetString(3);
                string dateSortie = reader.GetString(4);
                string prix = reader.GetString(5);
                string genre = reader.IsDBNull(14) ? null : reader.GetString(14);
                string typeGenre = reader.IsDBNull(10) ? null : reader.GetString(10);
                string editeur = reader.IsDBNull(16) ? null : reader.GetString(16);
                string auteur = reader.GetString(20);

                dataGridView1.ColumnCount = 8;
                dataGridView1.Columns[0].Name = "id Livre";
                dataGridView1.Columns[1].Name = "Titre";
                dataGridView1.Columns[2].Name = "Auteur";
                dataGridView1.Columns[3].Name = "Prix (en euros)";
                dataGridView1.Columns[4].Name = "Date de publication";
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Name = "Type de genre";
                dataGridView1.Columns[6].Name = "Genre";
                dataGridView1.Columns[7].Name = "Editeur";

                dataGridView1.Rows.Add(idLivre, titre, auteur, prix, dateSortie, typeGenre, genre, editeur);
            };

            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BoutonsPanel myForm = new BoutonsPanel(fenetrePrincipale);
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Clear();
            fenetrePrincipale.panel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string id = (Convert.ToString(selectedRow.Cells["id Livre"].Value));
                string titre = (Convert.ToString(selectedRow.Cells["Titre"].Value));
                string prix = (Convert.ToString(selectedRow.Cells["Prix (en euros)"].Value));
                string auteur = (Convert.ToString(selectedRow.Cells["Auteur"].Value));
                DateTime dateSortie = (Convert.ToDateTime(selectedRow.Cells["Date de publication"].Value));
                string typeGenre = (Convert.ToString(selectedRow.Cells["Type de genre"].Value));
                string genre = (Convert.ToString(selectedRow.Cells["Genre"].Value));
                string editeur = (Convert.ToString(selectedRow.Cells["Editeur"].Value));

                ModifLivre modifL = new ModifLivre(id, titre, prix, dateSortie, typeGenre, genre, editeur);
                fenetrePrincipale.Hide();
                modifL.Show();
            }
            else
            {
                MessageBox.Show("Aucune colonne sélectionnée");
            }
        }

        private void searchName_TextChanged_1(object sender, EventArgs e)
        {
                conn.Open();

                if (selectSearch.Text == "Titre")
                {

                    MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                    command.Parameters.AddWithValue("@titre", searchName.Text + "%");

                    command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE titre LIKE @titre ORDER BY titre ASC"; // Ecriture requête


                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    // Récupération des données:

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                    string idLivre = reader.GetString(0);
                    string titre = reader.GetString(3);
                    string dateSortie = reader.GetString(4);
                    string prix = reader.GetString(5);
                    string genre = reader.IsDBNull(14) ? null : reader.GetString(14);
                    string typeGenre = reader.IsDBNull(10) ? null : reader.GetString(10);
                    string editeur = reader.IsDBNull(16) ? null : reader.GetString(16);
                    string auteur = reader.GetString(20);

                    dataGridView1.Rows.Add(idLivre, titre, auteur, prix, dateSortie, typeGenre, genre, editeur);
                }

                }
                else if (selectSearch.Text == "Identifiant")
                {
                    MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                    command.Parameters.AddWithValue("@id", searchName.Text + "%");

                    command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE livres.idLivre LIKE @id ORDER BY idLivre ASC"; // Ecriture requête


                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    // Récupération des données:

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                    string idLivre = reader.GetString(0);
                    string titre = reader.GetString(3);
                    string dateSortie = reader.GetString(4);
                    string prix = reader.GetString(5);
                    string genre = reader.IsDBNull(14) ? null : reader.GetString(14);
                    string typeGenre = reader.IsDBNull(10) ? null : reader.GetString(10);
                    string editeur = reader.IsDBNull(16) ? null : reader.GetString(16);
                    string auteur = reader.GetString(20);

                    dataGridView1.Rows.Add(idLivre, titre, auteur, prix, dateSortie, typeGenre, genre, editeur);
                    }
                }
                else if (selectSearch.Text == "Auteur")
                {
                    MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                    command.Parameters.AddWithValue("@auteur", searchName.Text + "%");

                    command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE auteurs.nom LIKE @auteur ORDER BY idLivre ASC"; // Ecriture requête


                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    // Récupération des données:

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                    string idLivre = reader.GetString(0);
                    string titre = reader.GetString(3);
                    string dateSortie = reader.GetString(4);
                    string prix = reader.GetString(5);
                    string genre = reader.IsDBNull(14) ? null : reader.GetString(14);
                    string typeGenre = reader.IsDBNull(10) ? null : reader.GetString(10);
                    string editeur = reader.IsDBNull(16) ? null : reader.GetString(16);
                    string auteur = reader.GetString(20);

                    dataGridView1.Rows.Add(idLivre, titre, auteur, prix, dateSortie, typeGenre, genre, editeur);
                    }
                }
                else if (selectSearch.Text == "Editeur")
                {
                    MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                    command.Parameters.AddWithValue("@editeur", searchName.Text + "%");

                    command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE editeurs.nom LIKE @editeur ORDER BY idLivre ASC"; // Ecriture requête


                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    // Récupération des données:

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                    string idLivre = reader.GetString(0);
                    string titre = reader.GetString(3);
                    string dateSortie = reader.GetString(4);
                    string prix = reader.GetString(5);
                    string genre = reader.IsDBNull(14) ? null : reader.GetString(14);
                    string typeGenre = reader.IsDBNull(10) ? null : reader.GetString(10);
                    string editeur = reader.IsDBNull(16) ? null : reader.GetString(16);
                    string auteur = reader.GetString(20);

                    dataGridView1.Rows.Add(idLivre, titre, auteur, prix, dateSortie, typeGenre, genre, editeur);
                    }
                }
                conn.Close();
        }
    }
}
