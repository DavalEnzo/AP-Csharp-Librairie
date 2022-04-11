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
using Boutique_de_livres.dtos;
using Boutique_de_livres.Modeles;

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

            List<Modeles.Livres> listeLivres = new dtoLivre().getAllLivres();

            foreach(Modeles.Livres livres in listeLivres)
            {

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

                dataGridView1.Rows.Add(livres.IdLivre, livres.Titre, livres.Auteur, livres.Prix, livres.Date_sortie, livres.TypeGenre, livres.Genre, livres.Editeur);
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

                    List<Modeles.Livres> list = new dtoLivre().rechercherLivre(selectSearch.Text, searchName.Text);

                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    foreach (Modeles.Livres livres in list)
                {
                    dataGridView1.Rows.Add(livres.IdLivre, livres.Titre, livres.Auteur, livres.Prix, livres.Date_sortie, livres.TypeGenre, livres.Genre, livres.Editeur);
                }

                }
                else if (selectSearch.Text == "Identifiant")
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    // Récupération des données:

                    List<Modeles.Livres> list = new dtoLivre().rechercherLivre(selectSearch.Text, searchName.Text);

                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    foreach (Modeles.Livres livres in list)
                    {
                        dataGridView1.Rows.Add(livres.IdLivre, livres.Titre, livres.Auteur, livres.Prix, livres.Date_sortie, livres.TypeGenre, livres.Genre, livres.Editeur);
                    }
                }
                else if (selectSearch.Text == "Auteur")
                {

                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    // Récupération des données:

                    List<Modeles.Livres> list = new dtoLivre().rechercherLivre(selectSearch.Text, searchName.Text);

                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    foreach (Modeles.Livres livres in list)
                    {
                        dataGridView1.Rows.Add(livres.IdLivre, livres.Titre, livres.Auteur, livres.Prix, livres.Date_sortie, livres.TypeGenre, livres.Genre, livres.Editeur);
                    }
                }
                else if (selectSearch.Text == "Editeur")
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    // Récupération des données:
                    List<Modeles.Livres> list = new dtoLivre().rechercherLivre(selectSearch.Text, searchName.Text);

                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    foreach (Modeles.Livres livres in list)
                    {
                        dataGridView1.Rows.Add(livres.IdLivre, livres.Titre, livres.Auteur, livres.Prix, livres.Date_sortie, livres.TypeGenre, livres.Genre, livres.Editeur);
                    }
                }
                conn.Close();
        }
    }
}
