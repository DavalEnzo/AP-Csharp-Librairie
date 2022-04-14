using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Boutique_de_livres.Modeles
{
    public class Commandes : Modele
    {
        private int _idCommande;

        public int IdCommande { get { return _idCommande; } set { _idCommande = value; } }

        private int _idPanier;

        public int IdPanier { get { return _idPanier; } set { _idPanier = value; } }

        private int _idUtilisateur;

        public int IdUtilisateur { get { return _idUtilisateur; } set { _idUtilisateur = value; } }       
        
        private string _utilisateur;

        public string Utilisateur { get { return _utilisateur; } set { _utilisateur = value; } }

        private float _prixTotal;

        public float PrixTotal { get { return _prixTotal; } set { _prixTotal = value; } }

        private int _idAdresse;

        public int IdAdresse { get { return _idAdresse; } set { _idAdresse = value; } }

        private string _adresse;

        public string Adresse { get { return _adresse; } set { _adresse = value; } }

        private string _dateCommande;

        public string DateCommande { get { return _dateCommande; } set { _dateCommande = value; } }

        private string _dateLivraison;

        public string DateLivraison { get { return _dateLivraison; } set { _dateLivraison = value; } }

        private int _statut;

        public int Statut { get { return _statut; } set { _statut = value; } }

        public Commandes(int idCommande = 0)
        {
            if (idCommande != 0)
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "SELECT * FROM commandes WHERE idCommande = @idCommande";
                query.Parameters.AddWithValue("@idCommande", idCommande);
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    _idCommande = reader.GetInt32(0);
                    _idPanier = reader.GetInt32(1);
                    _idUtilisateur = reader.GetInt32(2);
                    _prixTotal = reader.GetFloat(3);
                    _idAdresse = reader.GetInt32(4);
                    _dateCommande = reader.GetString(5);
                    _dateLivraison = reader.GetString(6);
                    _statut = reader.GetInt32(7);
                };

                conn.Close();
            }
        }

        public Commandes(int idCommande, int idUtilisateur, int idPanier, float prixTotal, int idAdresse, string dateCommande, string dateLivraison, int statut, string utilisateur, string adresse)
        {
            this.IdCommande = idCommande;
            this.IdPanier = idPanier;
            this.IdUtilisateur = idUtilisateur;
            this.PrixTotal = prixTotal;
            this.IdAdresse = idAdresse;
            this.DateCommande = dateCommande;
            this.DateLivraison = dateLivraison;
            this.Statut = statut;
            this.Utilisateur = utilisateur;
            this.Adresse = adresse;

        }

        public bool updateCommande(int idCommande, int cancel)
        {
            conn.Open();

            if(cancel == 0)
            {

                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "UPDATE commandes SET statut = 1 WHERE idCommande = @idCommande";
                query.Parameters.AddWithValue("@idCommande", idCommande);

                if (query.ExecuteNonQuery() > 0) // Si requête réussie
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
            else
            {
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "UPDATE commandes SET statut = 3 WHERE idCommande = @idCommande";
                query.Parameters.AddWithValue("@idCommande", idCommande);

                if (query.ExecuteNonQuery() > 0) // Si requête réussie
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

}
