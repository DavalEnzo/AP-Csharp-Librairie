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


namespace Boutique_de_livres
{
    using BCrypt.Net;
    public partial class Inscription : Form
    {
        MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd=");

        Connexion connexion = new Connexion();
        public Inscription()
        {
            InitializeComponent();
            Mdp.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            connexion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            string prenom = Prenom.Text;

            string nom = Nom.Text;

            string mail = Mail.Text;

            string mdp = BCrypt.HashPassword(Mdp.Text);

            if (Prenom.Text != "" && Nom.Text != "" && Mail.Text != "" && Mdp.Text != "")
            {

                command.Parameters.AddWithValue("@Prenom", prenom); // Ajout des VALUES de la requête

                command.Parameters.AddWithValue("@Nom", nom);

                command.Parameters.AddWithValue("@Mail", mail);

                command.Parameters.AddWithValue("@Mdp", mdp);

                command.CommandText = "INSERT INTO utilisateurs (nom, prenom, email, mdp) VALUES (@Nom, @Prenom, @Mail, @Mdp)"; // Ecriture requête

                if (command.ExecuteNonQuery() > 0) // Si requête réussie
                {
                    MessageBox.Show("Inscription effectuée !");
                    this.Close();
                    connexion.Show();
                }

            }
            else
            {
                MessageBox.Show("Erreur lors de l'inscription ! Vérifiez si toutes les champs ont été remplis");
            }


            conn.Close();
        }

        private void Inscription_Validated(object sender, EventArgs e)
        {
            if (Prenom.Text == "" || Nom.Text == "" || Mail.Text == "" || Mdp.Text == "")
            {
                Application.Exit();
            }
        }

        private void Inscription_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Prenom.Text == "" || Nom.Text == "" || Mail.Text == "" || Mdp.Text == "")
            {
                Application.Exit();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
