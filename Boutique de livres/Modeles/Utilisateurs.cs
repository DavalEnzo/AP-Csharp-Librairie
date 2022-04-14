using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Boutique_de_livres.dtos;

namespace Boutique_de_livres.Modeles
{
    public class Utilisateurs : Modele
    {
        private int _idUtilisateur;
        public int IdUtilisateur { get { return _idUtilisateur; } set { _idUtilisateur = value; } }

        private string _nom;
        public string Nom { get { return _nom; } set { _nom = value; } }

        private string _prenom;
        public string Prenom { get { return _prenom; } set { _prenom = value; } }

        private string _email;
        public string Email { get { return _email; } set { _email = value; } }

        private string _mdp;
        public string Mdp { get { return _mdp; } set { _mdp = value; } }

        private int _idPermission;
        public int IdPermission { get { return _idPermission; } set { _idPermission = value; } }

        private int _active;
        public int active { get { return _active; } set { _active = value; } }

        public Utilisateurs(int idUtilisateur = 0)
        {
            if(idUtilisateur > 0)
            {
            conn.Open();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT idUtilisateur, prenom, nom, email, mdp, idPermission, active FROM utilisateurs WHERE idUtilisateur = @idUtilisateur";
            query.Parameters.AddWithValue("@idUtilisateur", IdUtilisateur);
            MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    _idUtilisateur = reader.GetInt32(0);
                    _prenom = reader.GetString(1);
                    _nom = reader.GetString(2);
                    _email = reader.GetString(3);
                    _mdp = reader.GetString(4);
                    _idPermission = reader.GetInt32(5);
                    _active = reader.GetInt32(6);
                };

                conn.Close();
            }
        }

        public Utilisateurs(int idUtilisateur, string prenom, string nom, string email, string mdp, int idPermisssion, int active)
        {
            this.IdUtilisateur = idUtilisateur;
            this.Email = email;
            this.Mdp = mdp;
            this.Nom = nom;
            this.Prenom = prenom;
            this.active = active;
            this.IdPermission = idPermisssion;
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

        public bool inscription(string nom, string prenom, string mail, string mdp)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.Parameters.AddWithValue("@Prenom", prenom); // Ajout des VALUES de la requête

            command.Parameters.AddWithValue("@Nom", nom);

            command.Parameters.AddWithValue("@Mail", mail);

            command.Parameters.AddWithValue("@Mdp", mdp);

            command.CommandText = "INSERT INTO utilisateurs (nom, prenom, email, mdp) VALUES (@Nom, @Prenom, @Mail, @Mdp)"; // Ecriture requête

            conn.Close();

            return true;
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

    }
}
