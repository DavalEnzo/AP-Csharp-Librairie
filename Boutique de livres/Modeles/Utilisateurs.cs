﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Boutique_de_livres.Fenetres;

namespace Boutique_de_livres
{
    public partial class Utilisateurs : UserControl
    {
        private AdminPanel fenetrePrincipale;

        MySqlConnection conn = new MySqlConnection("database=livres; server=localhost; user id = root; pwd=");

        public Utilisateurs(AdminPanel fenetre)
        {
            InitializeComponent();

            this.fenetrePrincipale = fenetre;

            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.CommandText = "SELECT * FROM utilisateurs"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                // Si la colonne est un string :  (si vous récupérez plusieurs résultats dans votre requête, incrémenter le 0 à 1, puis 2...)
                string idUtilisateur = reader.GetString(0);
                string prénom = reader.GetString(1);
                string nom = reader.GetString(2);
                string email = reader.GetString(3);

                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "id Utilisateur";
                dataGridView1.Columns[1].Name = "Prénom";
                dataGridView1.Columns[2].Name = "Nom";
                dataGridView1.Columns[3].Name = "Email";

                dataGridView1.Rows.Add(idUtilisateur, prénom, nom, email);

                // Si nullable, faire un GetValue au lieu de GetString sinon cause bug
            };

            conn.Close(); // Fermeture de la connexion
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
            DialogResult res = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
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
                            string cellValue = Convert.ToString(selectedRow.Cells["id Utilisateur"].Value);

                            // Add the parameter to the command collection
                            command.Parameters.AddWithValue("@idUtilisateur", cellValue);

                            command.CommandText = "DELETE FROM utilisateurs WHERE idUtilisateur = @idUtilisateur"; // Ecriture requête

                            if (command.ExecuteNonQuery() > 0) // Si requête réussie
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
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

           string id = (Convert.ToString(selectedRow.Cells["id Utilisateur"].Value));
           string prenom = (Convert.ToString(selectedRow.Cells["Prénom"].Value));
           string nom = (Convert.ToString(selectedRow.Cells["Nom"].Value));
           string email = (Convert.ToString(selectedRow.Cells["Email"].Value));

            ModifProfil modifP = new ModifProfil(id,prenom,nom,email);
            modifP.Show();
        }
    }
}
