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


namespace Boutique_de_livres
{
    using BCrypt.Net;
    public partial class Inscription : Form
    {

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

            string prenom = Prenom.Text;

            string nom = Nom.Text;

            string mail = Mail.Text;

            string mdp = BCrypt.HashPassword(Mdp.Text);

            if (Prenom.Text != "" && Nom.Text != "" && Mail.Text != "" && Mdp.Text != "")
            {

                dtoUtilisateur inscription = new dtoUtilisateur();

                inscription.inscription(nom, prenom, mail, mdp);

                if (inscription.inscription(nom, prenom, mail, mdp) == true) // Si requête réussie
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
