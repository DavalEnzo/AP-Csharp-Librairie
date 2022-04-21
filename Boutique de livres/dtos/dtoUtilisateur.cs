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
    }
}
