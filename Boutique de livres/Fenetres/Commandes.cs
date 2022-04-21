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

namespace Boutique_de_livres.Fenetres
{
    public partial class Commandes : UserControl
    {
        Modeles.Commandes commandes = new Modeles.Commandes();
        private AdminPanel fenetrePrincipale;
        public Commandes(AdminPanel fenetre)
        {
            InitializeComponent();

            fenetrePrincipale = fenetre;

            dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "id Commande";
            dataGridView1.Columns[1].Name = "Utilisateur";
            dataGridView1.Columns[2].Name = "Adresse";
            dataGridView1.Columns[3].Name = "Date de commande";
            dataGridView1.Columns[4].Name = "Date de livraison";
            dataGridView1.Columns[5].Name = "Statut";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Valider la commande";
            btn.Text = "Valider";
            btn.Name = "validerCommande";
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnAnnuler = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btnAnnuler);
            btnAnnuler.HeaderText = "Annuler la commande";
            btnAnnuler.Text = "Annuler";
            btnAnnuler.Name = "annulerCommande";
            btnAnnuler.UseColumnTextForButtonValue = true;

            List<Modeles.Commandes> listeCommandes = new dtoCommande().getAllCommandes();

            foreach (Modeles.Commandes commandes in listeCommandes)
            {

                string statut = " ";

                if (commandes.Statut == 0 && DateTime.Parse(commandes.DateLivraison) <= DateTime.Parse(commandes.DateCommande).AddDays(10))
                {
                    statut = "En attente";
                }
                else if (commandes.Statut == 1)
                {

                    statut = "En cours d'envoi";
                }
                else if (commandes.Statut == 2)
                {
                    statut = "Arrivé à destination";
                }
                else if (commandes.Statut == 0 && DateTime.Parse(commandes.DateLivraison) > DateTime.Parse(commandes.DateCommande).AddDays(10))
                {
                    statut = "Retard sur la commande";

                }
                else if (commandes.Statut == 3)
                {
                    statut = "Commande annulée";
                }

                dataGridView1.Rows.Add(commandes.IdCommande, commandes.Utilisateur, commandes.Adresse, commandes.DateCommande, commandes.DateLivraison, statut);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BoutonsPanel myForm = new BoutonsPanel(fenetrePrincipale);
            myForm.AutoScroll = true;
            fenetrePrincipale.panel1.Controls.Clear();
            fenetrePrincipale.panel2.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                if (Convert.ToString(selectedRow.Cells["Statut"].Value) != "En attente")
                {
                    MessageBox.Show("Vous ne pouvez pas valider cette commande", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    commandes.updateCommande(Convert.ToInt32(selectedRow.Cells["id Commande"].Value), 0);

                    if (commandes.updateCommande(Convert.ToInt32(selectedRow.Cells["id Commande"].Value), 0) == true)
                    {

                        MessageBox.Show("La commande a été validée");

                        List<Modeles.Commandes> listeCommande = new dtoCommande().getAllCommandes();

                        dataGridView1.Rows.Clear();
                        dataGridView1.Refresh();

                        foreach (Modeles.Commandes commandes in listeCommande)
                        {

                            string statut = " ";

                            if (commandes.Statut == 0 && DateTime.Parse(commandes.DateLivraison) <= DateTime.Parse(commandes.DateCommande).AddDays(10))
                            {
                                statut = "En attente";
                            }
                            else if (commandes.Statut == 1)
                            {

                                statut = "En cours d'envoi";
                            }
                            else if (commandes.Statut == 2)
                            {
                                statut = "Arrivé à destination";
                            }
                            else if (commandes.Statut == 0 && DateTime.Parse(commandes.DateLivraison) > DateTime.Parse(commandes.DateCommande).AddDays(10))
                            {
                                statut = "Retard sur la commande";

                            }
                            else if (commandes.Statut == 3)
                            {
                                statut = "Commande annulée";
                            }

                            dataGridView1.Rows.Add(commandes.IdCommande, commandes.Utilisateur, commandes.Adresse, commandes.DateCommande, commandes.DateLivraison, statut);
                        }

                    }

                }
            }
            else if (e.ColumnIndex == 7)
            {

                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                if (Convert.ToString(selectedRow.Cells["Statut"].Value) == "Arrivé à destination" || Convert.ToString(selectedRow.Cells["Statut"].Value) == "Commande annulée")
                {
                    MessageBox.Show("Vous ne pouvez pas annuler cette commande", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {



                    commandes.updateCommande(Convert.ToInt32(selectedRow.Cells["id Commande"].Value), 1);

                    if (commandes.updateCommande(Convert.ToInt32(selectedRow.Cells["id Commande"].Value), 1) == true)
                    {

                        MessageBox.Show("La commande a été annulée");

                        List<Modeles.Commandes> listeCommande = new dtoCommande().getAllCommandes();

                        dataGridView1.Rows.Clear();
                        dataGridView1.Refresh();

                        foreach (Modeles.Commandes commandes in listeCommande)
                        {

                            string statut = " ";

                            if (commandes.Statut == 0 && DateTime.Parse(commandes.DateLivraison) <= DateTime.Parse(commandes.DateCommande).AddDays(10))
                            {
                                statut = "En attente";
                            }
                            else if (commandes.Statut == 1)
                            {

                                statut = "En cours d'envoi";
                            }
                            else if (commandes.Statut == 2)
                            {
                                statut = "Arrivé à destination";
                            }
                            else if (commandes.Statut == 0 && DateTime.Parse(commandes.DateLivraison) > DateTime.Parse(commandes.DateCommande).AddDays(10))
                            {
                                statut = "Retard sur la commande";

                            }
                            else if (commandes.Statut == 3)
                            {
                                statut = "Commande annulée";
                            }

                            dataGridView1.Rows.Add(commandes.IdCommande, commandes.Utilisateur, commandes.Adresse, commandes.DateCommande, commandes.DateLivraison, statut);
                        }

                    }

                }
            }
        }
    }
}
