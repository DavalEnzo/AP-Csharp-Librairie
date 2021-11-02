using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boutique_de_livres.Fenetres
{
    public partial class ModifProfil : Form
    {
        public ModifProfil(string identifiant, string Prenom, string Nom, string Email)
        {
            InitializeComponent();
            id.Text = identifiant;
            prenom.Text = Prenom;
            nom.Text = Nom;
            email.Text = Email;
        }

        private void ModifProfil_Load(object sender, EventArgs e)
        {

            label6.Text = prenom.Text + " " + nom.Text;
        }
    }
}
