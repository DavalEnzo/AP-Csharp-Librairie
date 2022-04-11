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
    public partial class ModifLivre : Form
    {
        AdminPanel AdminPanel = new AdminPanel();
        public ModifLivre(string Id, string Titre, string Prix, DateTime DateSortie, string TypeGenre, string Genre, string Editeur)
        {
            InitializeComponent();

            dateSortie.Value = DateSortie;


            titre.Text = Titre;

            titre.SelectionStart = 0;

            prix.Text = Prix;

            titrePage.Text = Id;

            genre.Text = Genre;

            typeGenre.Text = TypeGenre;

            typeGenre.SelectedIndex = typeGenre.Items.IndexOf(typeGenre);

            List<Modeles.Livres> listeTypeGenre = new dtoLivre().selectTypeGenre(genre.Text);

            foreach(Modeles.Livres typeGenreList in listeTypeGenre)
            {
                typeGenre.Items.Add(typeGenreList.TypeGenre);
                typeGenre.SelectedIndex = 0;
            }
        }

        private void ModifLivre_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtoLivre livre = new dtoLivre();

            livre.updateLivre(titrePage.Text, titre.Text, float.Parse(prix.Text), dateSortie.Text, typeGenre.Text, genre.Text);

            if (livre.updateLivre(titrePage.Text, titre.Text, float.Parse(prix.Text), dateSortie.Text, typeGenre.Text, genre.Text) == true) // Si requête réussie
            {
                MessageBox.Show("Modification effectuée !");
                this.Close();
                AdminPanel.Show();
            }
            else
            {
                MessageBox.Show("Le livre n'a pas pu être modifié. Veuillez contacter un administrateur système");
            }
        }

        private void genre_DropDown(object sender, EventArgs e)
        {            
            genre.Items.Clear();

            List<Modeles.Livres> listeGenre = new dtoLivre().selectAllGenres();

            foreach (Modeles.Livres list in listeGenre)
            {
                genre.Items.Add(list.Genre);
            }

        }

        private void genre_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeGenre.Items.Clear();

            List<Modeles.Livres> listeTypeGenre = new dtoLivre().getNewTypeGenreFromGenre(genre.Text);

            foreach (Modeles.Livres list in listeTypeGenre)
            {
                typeGenre.Items.Add(list.TypeGenre);
                typeGenre.SelectedIndex = 0;
            }
        }
    }
}
