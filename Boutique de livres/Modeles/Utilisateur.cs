using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Boutique_de_livres.dtos;

namespace Boutique_de_livres.Modeles
{
    public class Utilisateur : Modele
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

        public Utilisateur(int idUtilisateur = 0)
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

                    ;
                };
            }
        }

        public Utilisateur(int idUtilisateur, string prenom, string nom, string email, string mdp, int idPermisssion, int active)
        {
            this.IdUtilisateur = idUtilisateur;
            this.Email = email;
            this.Mdp = mdp;
            this.Nom = nom;
            this.Prenom = prenom;
            this.active = active;
            this.IdPermission = idPermisssion;
        }



    }
}
