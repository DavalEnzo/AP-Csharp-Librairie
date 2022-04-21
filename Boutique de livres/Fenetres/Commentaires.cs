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
    public partial class Commentaires : UserControl
    {
        private AdminPanel fenetrePrincipale;

        public Commentaires(AdminPanel fenetre)
        {
            InitializeComponent();

            fenetrePrincipale = fenetre;

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "id Commentaire";
            dataGridView1.Columns[1].Name = "Contenu";
            dataGridView1.Columns[2].Name = "Utilisateur";
            dataGridView1.Columns[3].Name = "Titre du livre";
            dataGridView1.Columns[4].Name = "Date et heure de publication";
            dataGridView1.Columns[5].Name = "Approuvé ?";

            List<Modeles.Commentaires> listeCommentaires = new dtoCommentaire().getAllCommentaires();

            foreach (Modeles.Commentaires commentaires in listeCommentaires)
            {

                dataGridView1.Rows.Add(commentaires.IdCommentaire, commentaires.Contenu, commentaires.utilisateur,commentaires.titreLivre, commentaires.Date_heure, commentaires.verif);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string idComm = (Convert.ToString(selectedRow.Cells["id Commentaire"].Value));

                detailsCommentaire DetailsC = new detailsCommentaire(idComm);
                DetailsC.Show();
                fenetrePrincipale.Hide();
            }
            else
            {
                MessageBox.Show("Aucune colonne sélectionnée");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BoutonsPanel myForm = new BoutonsPanel(fenetrePrincipale);
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Clear();
            fenetrePrincipale.panel2.Visible = true;

        }
    }
}
