using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Boutique_de_livres.Modeles;

namespace Boutique_de_livres.dtos
{
using BCrypt.Net;
    public class dtoUtilisateur : Modele
    {

        protected List<Utilisateurs> listeUtilisateur = new List<Utilisateurs>();

        public List<Utilisateurs> getAllUsers()
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.CommandText = "SELECT idUtilisateur, prenom, nom, email, mdp, idPermission, active FROM utilisateurs"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Utilisateurs utilisateur = new Utilisateurs(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));
                
                listeUtilisateur.Add(utilisateur);
            };

            conn.Close(); // Fermeture de la connexion

            return listeUtilisateur;

        }

        public int verifconnexion(string email, string mdp)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.Parameters.AddWithValue("@email", email); // Ajout des VALUES de la requête

            command.Parameters.AddWithValue("@mdp", mdp);

            command.CommandText = "SELECT idUtilisateur,nom,prenom,mdp,idPermission,active FROM utilisateurs WHERE email = @email"; // Ecriture requête

            MySqlDataReader reader = command.ExecuteReader();

            int erreur = -1;

            while (reader.Read())
            {
                // Si la colonne est un string :  (si vous récupérez plusieurs résultats dans votre requête, incrémenter le 0 à 1, puis 2...)
                int idUser = reader.GetInt32(0);

                string nom = reader.GetString(1);

                string prénom = reader.GetString(2);

                string mdpCrypte = reader.GetString(3);

                int idPermission = reader.GetInt32(4);

                int active = reader.GetInt32(5);

                if (idPermission == 1)
                {

                    if (!BCrypt.Verify(mdp, mdpCrypte))
                    {
                        erreur = 1;
                    }
                    else if (BCrypt.Verify(mdp, mdpCrypte))
                    {
                        erreur = 0;
                    }
                }
                else
                {
                    erreur = 2;
                }
            }

            conn.Close();

            return erreur;

        }

        public List<Utilisateurs> connexion(string email)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.Parameters.AddWithValue("@email", email); // Ajout des VALUES de la requête

            command.CommandText = "SELECT idUtilisateur,nom,prenom,idPermission,active FROM utilisateurs WHERE email = @email"; // Ecriture requête

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Si la colonne est un string :  (si vous récupérez plusieurs résultats dans votre requête, incrémenter le 0 à 1, puis 2...)

                Utilisateurs utilisateur = new Utilisateurs(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), email, null, reader.GetInt32(3), reader.GetInt32(4));

                listeUtilisateur.Add(utilisateur);
            }
                
            conn.Close();
            return listeUtilisateur;

        }

        public bool inscription(string nom, string prenom, string mail, string mdp)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.Parameters.AddWithValue("@Prenom", prenom); // Ajout des VALUES de la requête

            command.Parameters.AddWithValue("@Nom", nom);

            command.Parameters.AddWithValue("@Mail", mail);

            command.Parameters.AddWithValue("@Mdp", mdp);

            command.CommandText = "INSERT INTO utilisateurs (nom, prenom, email, mdp) VALUES (@Nom, @Prenom, @Mail, @Mdp)"; // Ecriture requête

            conn.Close() ;

            return true;
        }

        public List<Utilisateurs> rechercheUtilisateur(string mode, string saisie)
        {
            conn.Open();

            if (mode == "Prénom")
            {

                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@prenom", saisie + "%");

                command.CommandText = "SELECT idUtilisateur, prenom, nom, email, mdp, idPermission, active FROM utilisateurs WHERE prenom LIKE @prenom"; // Ecriture requête

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Utilisateurs utilisateur = new Utilisateurs(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), " ", reader.GetInt32(5), reader.GetInt32(6));

                    listeUtilisateur.Add(utilisateur);
                }

            }
            else if (mode == "Identifiant")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@id", saisie + "%");

                command.CommandText = "SELECT idUtilisateur, prenom, nom, email, mdp, idPermission, active FROM utilisateurs WHERE idUtilisateur LIKE @id"; // Ecriture requête

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Utilisateurs utilisateur = new Utilisateurs(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(5), reader.GetInt32(5), reader.GetInt32(6));

                    listeUtilisateur.Add(utilisateur);
                }
            }
            else if (mode == "Nom")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@nom", saisie + "%");

                command.CommandText = "SELECT idUtilisateur, prenom, nom, email, mdp, idPermission, active FROM utilisateurs WHERE nom LIKE @nom"; // Ecriture requête

                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Utilisateurs utilisateur = new Utilisateurs(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), " ", reader.GetInt32(5), reader.GetInt32(6));

                    listeUtilisateur.Add(utilisateur);
                }
            }
            else if (mode == "Email")
            {
                MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

                command.Parameters.AddWithValue("@email", "%" + saisie + "%");

                command.CommandText = "SELECT idUtilisateur, prenom, nom, email, mdp, idPermission, active FROM utilisateurs WHERE email LIKE @email"; // Ecriture requête
                // Récupération des données:

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Utilisateurs utilisateur = new Utilisateurs(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), " ", reader.GetInt32(5), reader.GetInt32(6));

                    listeUtilisateur.Add(utilisateur);
                }
            }
            conn.Close();

            return listeUtilisateur ;
        }

        public bool updateUser(string idUser, string prenom, string nom, string email, bool permission)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.Parameters.AddWithValue("@id", idUser);

            command.Parameters.AddWithValue("@nom", prenom);

            command.Parameters.AddWithValue("@prenom", nom);

            command.Parameters.AddWithValue("@email", email); // Ajout des VALUES de la requête

            if (permission == true)
            {
                command.Parameters.AddWithValue("@verif", 1);

                command.CommandText = "UPDATE utilisateurs SET nom=@nom, prenom=@prenom, email=@email, idPermission = @verif WHERE idUtilisateur = @id"; // Ecriture requête
            }
            else
            {
                command.Parameters.AddWithValue("@verif", 0);
                command.CommandText = "UPDATE utilisateurs SET nom=@nom, prenom=@prenom, email=@email, idPermission = @verif WHERE idUtilisateur = @id"; // Ecriture requête
            }

            if (command.ExecuteNonQuery() > 0) // Si requête réussie
            {
                return true;
            }
            else
            {
                return false;
            }
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
