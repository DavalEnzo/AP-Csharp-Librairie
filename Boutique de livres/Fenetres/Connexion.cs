using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Ne pas oublier d'ajouter mysqldata.dll en ref et de mettre le using

namespace Boutique_de_livres
{
using BCrypt.Net;
    public partial class Connexion : Form
    {
        MySqlConnection conn = new MySqlConnection("database=livres; server=localhost; user id = root; pwd="); // Données de connexion à la BDD
        public Connexion()
        {
            InitializeComponent();
            Mdp.PasswordChar = '*';

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inscription Inscription = new Inscription();
            Inscription.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string email = Mail.Text;
            string mdp = Mdp.Text;

            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.Parameters.AddWithValue("@email", email); // Ajout des VALUES de la requête

            command.Parameters.AddWithValue("@mdp", mdp);

            command.CommandText = "SELECT nom,prenom,mdp,idPermission FROM utilisateurs WHERE email = @email"; // Ecriture requête

            MySqlDataReader reader = command.ExecuteReader();

            bool emailValide = false;

            while (reader.Read())
            {
                // Si la colonne est un string :  (si vous récupérez plusieurs résultats dans votre requête, incrémenter le 0 à 1, puis 2...)
                string nom = reader.GetString(0);

                string prénom = reader.GetString(1);

                string mdpCrypte = reader.GetString(2);

                int idPermission = reader.GetInt32(3);

                if (idPermission == 1)
                {

                    if (!BCrypt.Verify(Mdp.Text, mdpCrypte))
                    {
                        MessageBox.Show("Le mot de passe est incorrect");
                    }
                    else if (BCrypt.Verify(Mdp.Text, mdpCrypte))
                    {
                        MessageBox.Show("Bienvenue" + " " + prénom + " " + nom + " !");
                        AdminPanel adminPanel = new AdminPanel();

                        adminPanel.Show();
                        this.Hide();
                    }
                    emailValide = true;

                    if (emailValide == false)
                    {
                        MessageBox.Show("Aucun compte avec cette adresse mail n'a été trouvé ou rien n'a été entré dans le champ mail");
                    }
                }
                else
                {
                    MessageBox.Show("Vous n'êtes pas autorisé à utiliser cette application");
                }
            }
        conn.Close();
        }


        private void Connexion_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (Mail.Text != "" || Mdp.Text != "")
            {
                Application.Exit();
            }
        }

        private void sinscrireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inscription Inscription = new Inscription();
            Inscription.Show();
            this.Hide();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
