using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Boutique_de_livres.Modeles;

namespace Boutique_de_livres.dtos
{
    public class dtoUtilisateur : Modele
    {

        protected List<Utilisateur> listeUtilisateur = new List<Utilisateur>();

        public List<Utilisateur> getAllUsers()
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.CommandText = "SELECT idUtilisateur, prenom, nom, email, mdp, idPermission, active FROM utilisateurs"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Utilisateur utilisateur = new Utilisateur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));
                
                listeUtilisateur.Add(utilisateur);
            };

            conn.Close(); // Fermeture de la connexion

            return listeUtilisateur;

        }

        public bool deleteUser(int idUser)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();

            // Add the parameter to the command collection
            command.Parameters.AddWithValue("@idUtilisateur", idUser);

            command.CommandText = "DELETE FROM utilisateurs WHERE idUtilisateur = @idUtilisateur"; // Ecriture requête

            conn.Close(); // Fermeture de la connexion

            return true;

        }
    }
}
