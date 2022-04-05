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
    public partial class Utilisateurs : UserControl
    {
        private AdminPanel fenetrePrincipale;
        MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd=");

        public Utilisateurs(AdminPanel fenetre)
        {
            InitializeComponent();

            fenetrePrincipale = fenetre;

            selectSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            selectSearch.SelectedIndex = 0;

            List<Utilisateur> listeUtilisateurs = new dtoUtilisateur().getAllUsers();

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "id Utilisateur";
            dataGridView1.Columns[2].Name = "Nom";
            dataGridView1.Columns[1].Name = "Prénom";
            dataGridView1.Columns[3].Name = "Email";
            dataGridView1.Columns[4].Name = "Admin";

            foreach (Utilisateur utilisateur in listeUtilisateurs)
            {

                dataGridView1.Rows.Add(utilisateur.IdUtilisateur, utilisateur.Nom, utilisateur.Prenom, utilisateur.Email, utilisateur.IdPermission);
            }



        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BoutonsPanel myForm = new BoutonsPanel(fenetrePrincipale);
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Clear();
            fenetrePrincipale.panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void dataGridView1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                if (dataGridView1.CurrentCell.Value == null)
                {

                    MessageBox.Show("Vous n'avez pas sélectionné d'utilisateur à supprimer !");
                }
                else
                {
                    MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                        conn.Open();

                        if (dataGridView1.CurrentCell.RowIndex > 0)
                        {

                            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                            int cellValue = Convert.ToInt32(selectedRow.Cells["id Utilisateur"].Value);

                        dtoUtilisateur user = new dtoUtilisateur();

                        user.deleteUser(cellValue);

                            if (user.deleteUser(cellValue) == true) // Si requête réussie
                            {

                            dataGridView1.Rows.RemoveAt(selectedrowindex);

                            MessageBox.Show("Suppression effectuée");
                            }
                            else
                            {
                                MessageBox.Show("Erreur lors de le suppression !");
                            }
                        }
                        conn.Close();
                }
            }

            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("Suppression annulée");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string id = (Convert.ToString(selectedRow.Cells["id Utilisateur"].Value));
                string prenom = (Convert.ToString(selectedRow.Cells["Prénom"].Value));
                string nom = (Convert.ToString(selectedRow.Cells["Nom"].Value));
                string email = (Convert.ToString(selectedRow.Cells["Email"].Value));
                string verif = (Convert.ToString(selectedRow.Cells["Admin"].Value));

                ModifProfil modifP = new ModifProfil(id, prenom, nom, email, verif);
                fenetrePrincipale.Hide();
                modifP.Show();
            }
            else
            {
                MessageBox.Show("Aucune colonne sélectionnée");
            }
        }

        private void searchName_TextChanged(object sender, EventArgs e)
        {
            conn.Open();

            if(selectSearch.Text == "Prénom")
            {

                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@prenom", searchName.Text+"%");

                command.CommandText = "SELECT * FROM utilisateurs WHERE prenom LIKE @prenom"; // Ecriture requête


                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()){
                    string idUtilisateur = reader.GetString(0);
                    string nom = reader.GetString(1);
                    string prénom = reader.GetString(2);
                    string email = reader.GetString(3);
                    string verif = reader.GetString(6);

                    dataGridView1.Rows.Add(idUtilisateur, prénom, nom, email, verif);
                }
                
            }
            else if(selectSearch.Text == "Identifiant")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@id", searchName.Text + "%");

                command.CommandText = "SELECT * FROM utilisateurs WHERE idUtilisateur LIKE @id"; // Ecriture requête


                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string idUtilisateur = reader.GetString(0);
                    string nom = reader.GetString(1);
                    string prénom = reader.GetString(2);
                    string email = reader.GetString(3);
                    string verif = reader.GetString(6);

                    dataGridView1.Rows.Add(idUtilisateur, prénom, nom, email, verif);
                }
            }
            else if(selectSearch.Text == "Nom")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@nom", searchName.Text + "%");

                command.CommandText = "SELECT * FROM utilisateurs WHERE nom LIKE @nom"; // Ecriture requête


                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string idUtilisateur = reader.GetString(0);
                    string nom = reader.GetString(1);
                    string prénom = reader.GetString(2);
                    string email = reader.GetString(3);
                    string verif = reader.GetString(6);

                    dataGridView1.Rows.Add(idUtilisateur, prénom, nom, email, verif);
                }
            }
            else if(selectSearch.Text == "Email")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@email","%" + searchName.Text + "%");

                command.CommandText = "SELECT * FROM utilisateurs WHERE email LIKE @email"; // Ecriture requête


                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string idUtilisateur = reader.GetString(0);
                    string nom = reader.GetString(1);
                    string prénom = reader.GetString(2);
                    string email = reader.GetString(3);
                    string verif = reader.GetString(6);

                    dataGridView1.Rows.Add(idUtilisateur, prénom, nom, email, verif);
                }
            }
            conn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BoutonsPanel myForm = new BoutonsPanel(fenetrePrincipale);
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Clear();
            fenetrePrincipale.panel2.Visible = true;
        }

    }
}