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

namespace Boutique_de_livres.Fenetres
{
    public partial class ModifProfil : Form
    {
        AdminPanel AdminPanel = new AdminPanel();
        public ModifProfil(string identifiant, string Prenom, string Nom, string Email, string verif)
        {
            InitializeComponent();
            id.Text = identifiant;
            prenom.Text = Prenom;
            nom.Text = Nom;
            email.Text = Email;


            if(verif == "1")
            {
                permissions.Checked = true;
            }
        }

        private void ModifProfil_Load(object sender, EventArgs e)
        {

            titrePage.Text = prenom.Text + " " + nom.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id.Text !="" && prenom.Text !="" && nom.Text !="" && email.Text != "")
            {

                bool verif;

                if (permissions.Checked)
                {
                    verif = true;
                }else
                {
                    verif = false;
                }

                Modeles.Utilisateurs utilisateur = new Modeles.Utilisateurs();

                utilisateur.updateUser(id.Text, prenom.Text, nom.Text, email.Text, verif);


                if (utilisateur.updateUser(id.Text, prenom.Text, nom.Text, email.Text, verif) == true) // Si requête réussie
                {
                    MessageBox.Show("Modification effectuée !");
                    this.Close();
                    AdminPanel.Show();
                }
                else
                {
                    MessageBox.Show("Il y a eu un problème lors de la modification de l'utilisateur, veuillez contacter une administrateur");
                }

            }
            else
            {
                MessageBox.Show("Vous devez remplir tous les champs afin d'effectuer la modification d'un utilisateur");
            }
        }

        private void ModifProfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.Show();
        }
    }
}
