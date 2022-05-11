using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique_de_livres.Modeles;
using MySql.Data.MySqlClient;

namespace Boutique_de_livres.Modeles
{
    public class Livres : Modele
    {
        private int _idLivre;
        public int IdLivre { get { return _idLivre; } set { _idLivre = value; } }

        private string _titre;
        public string Titre { get { return _titre; } set { _titre = value; } }

        private string _date_sortie;
        public string Date_sortie { get { return _date_sortie; } set { _date_sortie = value; } }

        private float _prix;
        public float Prix { get { return _prix; } set { _prix = value; } }

        private string _genre;

        public string Genre { get { return _genre; } set { _genre = value; } }

        private string _typeGenre;

        public string TypeGenre { get { return _typeGenre; } set { _typeGenre = value;} }

        private string _editeur;

        public string Editeur { get { return _editeur; } set { _editeur = value; } }

        private string _auteur;

        public string Auteur { get { return _auteur; } set { _auteur = value; } }


        public Livres(int idLivre = 0)
        {
            if (idLivre > 0)
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "SELECT idLivre, Titre, date_sortie, Prix, idGenre, idtypeGenre, idEditeur FROM livres WHERE idLivre = @idLivre";
                query.Parameters.AddWithValue("@idCommentaire", idLivre);
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    _idLivre = reader.GetInt32(0);
                    _titre = reader.GetString(1);
                    _date_sortie = reader.GetString(2);
                    _prix = reader.GetFloat(3);
                    _genre = reader.GetString(4);
                    _typeGenre = reader.GetString(5);
                    _editeur = reader.GetString(6);

                };

                conn.Close();
            }
        }

        public Livres(int idLivre, string titre, string date_sortie, float prix, string genre, string typeGenre, string editeur, string auteur)
        {
            this.IdLivre = idLivre;
            this.Titre = titre;
            this.Date_sortie = date_sortie;
            this.Prix = prix;
            this.Genre = genre;
            this.TypeGenre = typeGenre;
            this.Editeur = editeur;
            this.Auteur = auteur;
        }

        public bool updateLivre(string idLivre, string titre, float prix, string date_sortie, string typeGenre, string genre)
        {

            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            command.Parameters.AddWithValue("@libelle", typeGenre);

            command.Parameters.AddWithValue("@nomGenre", genre);

            command.CommandText = "SELECT * from typeGenre LEFT JOIN genres USING(idGenre) WHERE libelle = @libelle AND genres.nomGenre = @nomGenre";

            MySqlDataReader reader = command.ExecuteReader();

            int idTypeGenre = 0;

            int idGenre = 0;

            while (reader.Read())
            {
                idGenre = reader.GetInt32(0);
                idTypeGenre = reader.GetInt32(1);
            }

            conn.Close();

            conn.Open();


            MySqlCommand insert = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            insert.Parameters.AddWithValue("@id", idLivre);

            insert.Parameters.AddWithValue("@titre", titre);

            insert.Parameters.AddWithValue("@prix", prix);

            insert.Parameters.AddWithValue("@dateSortie", date_sortie); // Ajout des VALUES de la requête

            insert.Parameters.AddWithValue("@idtypeGenre", idTypeGenre); // Ajout des VALUES de la requête

            insert.Parameters.AddWithValue("@idGenre", idGenre); // Ajout des VALUES de la requête

            insert.CommandText = "UPDATE livres SET Titre=@titre, Prix=@prix, date_sortie=@dateSortie, idtypeGenre = @idtypeGenre, idGenre = @idGenre WHERE idLivre = @id";

            if (insert.ExecuteNonQuery() > 0) // Si requête réussie
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }


        }

    }

}
