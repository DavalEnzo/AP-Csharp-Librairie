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
    public partial class ModifProfil : Form
    {
        AdminPanel AdminPanel = new AdminPanel();
        MySqlConnection conn = new MySqlConnection("database=livres; server=localhost; user id = root; pwd=");
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

                conn.Open();

                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@id", id.Text);

                command.Parameters.AddWithValue("@nom", prenom.Text);

                command.Parameters.AddWithValue("@prenom", nom.Text);

                command.Parameters.AddWithValue("@email", email.Text); // Ajout des VALUES de la requête

                if (permissions.Checked)
                {
                    command.Parameters.AddWithValue("@verif", 1);

                    command.CommandText = "UPDATE utilisateurs SET nom=@nom, prenom=@prenom, email=@email, idPermission = @verif WHERE idUtilisateur = @id"; // Ecriture requête
                }
                else
                {
                    command.Parameters.AddWithValue("@verif", 0);
                    command.CommandText = "UPDATE utilisateurs SET nom=@nom, prenom=@prenom, email=@email, idPermission = @verif WHERE idUtilisateur = @id"; // Ecriture requête
                }


                if (command.ExecuteNonQuery() > 0) // Si requête réussie
                {
                    MessageBox.Show("Modification effectuée !");
                    this.Close();
                    AdminPanel.Show();
                }

                conn.Close();
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
