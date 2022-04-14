using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique_de_livres.Modeles;
using MySql.Data.MySqlClient;

namespace Boutique_de_livres.dtos
{
    public class dtoLivre : Modele
    {
        protected List<Livres> listeLivre = new List<Livres>();
        protected List<dtoGenre> listeGerne = new List<dtoGenre>();

        public List<Livres> getAllLivres()
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur ORDER BY titre ASC"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Livres livres = new Livres(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.IsDBNull(15) ? " " : reader.GetString(15), reader.IsDBNull(11) ? " " : reader.GetString(11), reader.IsDBNull(17) ? " " : reader.GetString(17), reader.GetString(21));

                listeLivre.Add(livres);
            };

            conn.Close(); // Fermeture de la connexion

            return listeLivre;

        }

        public List<Livres> rechercherLivre(string mode, string saisie)
        {

            conn.Open();

            if (mode == "Titre")
            {

                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@titre", saisie + "%");

                command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE titre LIKE @titre ORDER BY titre ASC"; // Ecriture requête


                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Livres livres = new Livres(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.IsDBNull(15) ? " " : reader.GetString(15), reader.IsDBNull(11) ? " " : reader.GetString(11), reader.IsDBNull(17) ? " " : reader.GetString(17), reader.GetString(21));

                    listeLivre.Add(livres);
                }

            }
            else if (mode == "Identifiant")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@id", saisie + "%");

                command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE livres.idLivre LIKE @id ORDER BY idLivre ASC"; // Ecriture requête

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Livres livres = new Livres(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.IsDBNull(15) ? " " : reader.GetString(15), reader.IsDBNull(11) ? " " : reader.GetString(11), reader.IsDBNull(17) ? " " : reader.GetString(17), reader.GetString(21));
                    listeLivre.Add(livres);
                }
            }
            else if (mode == "Auteur")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@auteur", saisie + "%");

                command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE auteurs.nom LIKE @auteur ORDER BY idLivre ASC"; // Ecriture requête
                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Livres livres = new Livres(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.IsDBNull(15) ? " " : reader.GetString(15), reader.IsDBNull(11) ? " " : reader.GetString(11), reader.IsDBNull(17) ? " " : reader.GetString(17), reader.GetString(21));
                    listeLivre.Add(livres);
                }
            }
            else if (mode == "Editeur")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@editeur", saisie + "%");

                command.CommandText = "SELECT * from livres LEFT JOIN typeGenre USING(idTypeGenre) LEFT JOIN genres ON livres.idGenre = genres.idGenre LEFT JOIN editeurs USING(idEditeur) LEFT JOIN ecrit USING(idLivre) LEFT JOIN auteurs on ecrit.idAuteur = auteurs.idAuteur WHERE editeurs.nom LIKE @editeur ORDER BY idLivre ASC"; // Ecriture requête

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Livres livres = new Livres(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.IsDBNull(15) ? " " : reader.GetString(15), reader.IsDBNull(11) ? " " : reader.GetString(11), reader.IsDBNull(17) ? " " : reader.GetString(17), reader.GetString(21));
                    listeLivre.Add(livres);
                }
            }
            conn.Close();

            return listeLivre;
        }


        public List<Livres> selectTypeGenre(string libelle)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.Parameters.AddWithValue("@nomGenre", libelle); // Ajout des VALUES de la requête

            command.CommandText = "SELECT libelle from typegenre LEFT JOIN genres USING(idGenre) WHERE nomGenre = @nomGenre";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Livres livres = new Livres(0, " ", " ", 0, " ", reader.IsDBNull(0) ? " " : reader.GetString(0), " ", " ");

                listeLivre.Add(livres);
            }

            conn.Close();
            return listeLivre;
        }

        public List<dtoGenre> selectAllGenres()
        {

            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT idGenre, nomGenre from genres";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dtoGenre dtoGenre = new dtoGenre(reader.GetString(1), reader.GetInt32(0));

                listeGerne.Add(dtoGenre);
            }

            conn.Close();

            return listeGerne;
        }

        public List<Livres> getNewTypeGenreFromGenre(string genre)
        {

            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.Parameters.AddWithValue("@nomGenre", genre); // Ajout des VALUES de la requête

            command.CommandText = "SELECT libelle from typegenre LEFT JOIN genres USING(idGenre) WHERE nomGenre = @nomGenre";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Livres livres = new Livres(0, " ", " ", 0, " ", reader.IsDBNull(0) ? " " : reader.GetString(0), " ", " ");

                listeLivre.Add(livres);
            }

            conn.Close();

            return listeLivre;
        }
    }
}
