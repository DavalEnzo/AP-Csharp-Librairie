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
using Boutique_de_livres.Fenetres;

namespace Boutique_de_livres
{
    public partial class AdminPanel : Form
    {
        MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd=");
        public AdminPanel()
        {
            InitializeComponent();
            BoutonsPanel myForm = new BoutonsPanel(this);
            myForm.AutoScroll = true;
            panel1.Controls.Clear();
            MenuAdmin.Controls.Add(myForm);
            myForm.Show();
            
            this.panel2.Controls.Clear();
            pageAccueil accueil = new pageAccueil(this);
            accueil.AutoScroll = true;
            this.panel2.Controls.Add(accueil);
            accueil.Show();
        }


        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void ClosePic_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MenuAdmin_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
