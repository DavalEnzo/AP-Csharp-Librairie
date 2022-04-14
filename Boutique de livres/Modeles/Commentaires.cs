using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique_de_livres.dtos;
using MySql.Data.MySqlClient;

namespace Boutique_de_livres.Modeles
{
    public class Commentaires : Modele
    {
        private int _idCommentaire;

        public int IdCommentaire { get { return _idCommentaire; } set { _idCommentaire = value; } }

        private string _contenu;

        public string Contenu { get { return _contenu; } set { _contenu = value;} }

        private string _entete;

        public string Entete { get { return _entete; } set { _entete = value;} }

        private string _idUtilisateur;

        public string IdUtilisateur { get { return _idUtilisateur; } set { _idUtilisateur = value; } }

        private int _idLivre;

        public int idLivre { get { return _idLivre; } set { _idLivre = value; } }

        private string _date_heure;

        public string Date_heure { get { return _date_heure; } set { _date_heure = value; } }

        private int _verif;

        public int verif { get { return _verif; } set { _verif = value; } }

        private string _utilisateur;

        public string utilisateur { get { return _utilisateur; } set { _utilisateur = value; } }
        
        private string _titreLivre;

        public string titreLivre { get { return _titreLivre; } set { _titreLivre = value; } }

        public Commentaires(int idCommentaire = 0)
        {
            if (idCommentaire > 0)
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "SELECT idCommentaire, contenu, entete, idUtilisateur, idLivre, date_heure, verif FROM commentaires WHERE idCommentaire = @idCommentaire";
                query.Parameters.AddWithValue("@idCommentaire", idCommentaire);
                MySqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                    _idCommentaire = reader.GetInt32(0);
                    _contenu = reader.GetString(1);
                    _entete = reader.GetString(2);
                    _idUtilisateur = reader.GetString(3);
                    _idLivre = reader.GetInt32(4);
                    _date_heure = reader.GetString(5);
                    _verif = reader.GetInt32(6);

                    };

                conn.Close();
            }
        }


        public Commentaires(int idCommentaire, string contenu, string entete, int idUtilisateur, string utilisateur, int idLivre, string titreLivre, string date_heure, int verif)
        {
            this.IdCommentaire = idCommentaire;
            this.Contenu = contenu;
            this.Entete = entete;
            this.IdUtilisateur = IdUtilisateur;
            this.utilisateur = utilisateur;
            this.idLivre= idLivre;
            this.titreLivre = titreLivre;
            this.Date_heure= date_heure;
            this.verif= verif;
        }

        public bool deleteCommentaire(int idCommentaire)
        {
            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            conn.Open();

            // Add the parameter to the command collection
            command.Parameters.AddWithValue("@idCommentaire", idCommentaire);

            command.CommandText = "DELETE FROM commentaires WHERE idCommentaire = @idCommentaire"; // Ecriture requête

            if (command.ExecuteNonQuery() > 0) // Si requête réussie
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

        public bool approveCommentaire(int idCommentaire)
        {
            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            conn.Open();

            // Add the parameter to the command collection
            command.Parameters.AddWithValue("@idCommentaire", idCommentaire);

            command.CommandText = "UPDATE commentaires SET verif = 1 WHERE idCommentaire = @idCommentaire"; // Ecriture requête

            if (command.ExecuteNonQuery() > 0) // Si requête réussie
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
