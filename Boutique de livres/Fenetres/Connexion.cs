using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boutique_de_livres.dtos;
using Boutique_de_livres.Modeles;
using MySql.Data.MySqlClient; // Ne pas oublier d'ajouter mysqldata.dll en ref et de mettre le using

namespace Boutique_de_livres
{
    public partial class Connexion : Form
    {
        MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd="); // Données de connexion à la BDD
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

            dtoUtilisateur connexion = new dtoUtilisateur();

            connexion.verifconnexion(email, mdp);

            if (connexion.verifconnexion(email, mdp) == 0)
            {

                List<Utilisateur> liste = connexion.connexion(email);

                foreach (Utilisateur utilisateur in liste)
                {

                    MessageBox.Show("Bienvenue" + " " + utilisateur.Prenom + " " + utilisateur.Nom + " !");

                }
                AdminPanel adminPanel = new AdminPanel();

                adminPanel.Show();
                this.Hide();
            }
            else if(connexion.verifconnexion(email, mdp) == 1)
            {
                MessageBox.Show("Le mot de passe est incorrect");
            }else if(connexion.verifconnexion(email, mdp) == 2)
            {
                
            }else if(connexion.verifconnexion(email, mdp) == -1)
            {
                MessageBox.Show("Aucun compte avec cette adresse mail n'a été trouvé ou rien n'a été entré dans le champ mail");
            }

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
