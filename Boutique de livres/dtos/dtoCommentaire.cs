using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Boutique_de_livres.Modeles;

namespace Boutique_de_livres.dtos
{
    public class dtoCommentaire : Modele
    {
        protected List<Commentaires> listeCommentaire = new List<Commentaires>();

        public List<Commentaires> getAllCommentaires()
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.CommandText = "SELECT idCommentaire, contenu, CONCAT(CONCAT(utilisateurs.prenom, ' '), utilisateurs.nom) AS utilisateur, livres.Titre, commentaires.date_heure, utilisateurs.idUtilisateur, verif FROM `commentaires` LEFT JOIN livres USING (idLivre) LEFT JOIN utilisateurs USING (idUtilisateur) WHERE verif = 0"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Commentaires commentaires = new Commentaires(reader.GetInt32(0), reader.GetString(1), null, reader.GetInt32(5), reader.GetString(4), ' ', reader.GetString(3), reader.GetString(4), reader.GetInt32(6));

                listeCommentaire.Add(commentaires);

            };

            conn.Close(); // Fermeture de la connexion

            return listeCommentaire;
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
