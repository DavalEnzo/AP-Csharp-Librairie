using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Boutique_de_livres.Modeles;

namespace Boutique_de_livres.dtos
{
    public class dtoCommande : Modele
    {
        protected List<Commandes> listeCommande = new List<Commandes>();
        protected List<Livres> listeLivre = new List<Livres>();

        public List<Commandes> getAllCommandes()
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand(); // On prépare la commande SQL (requête SQL)

            command.CommandText = "SELECT idCommande, idPanier, commandes.idUtilisateur, prixTotal, idAdresse, dateCommande, dateLivraison, statut, CONCAT(CONCAT(utilisateurs.prenom, ' '), utilisateurs.nom) AS utilisateurs, CONCAT(CONCAT(CONCAT(CONCAT(adresses.libelle, ' ,'), adresses.codePostal), ' ,'), adresses.ville) AS adresse  FROM `commandes` LEFT JOIN utilisateurs USING(idUtilisateur) LEFT JOIN adresses USING(idAdresse)"; // Ecriture requête

            // Récupération des données:

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

               string dateCommandeFormatee = reader.GetString(5).Substring(0,11);

               string dateLivraisonFormatee = reader.GetString(6).Substring(0,11);
                
                Commandes commandes = new Commandes(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetInt32(4), dateCommandeFormatee, dateLivraisonFormatee, reader.GetInt32(7), reader.GetString(8), reader.GetString(9));

                listeCommande.Add(commandes);

            };

            conn.Close(); // Fermeture de la connexion

            return listeCommande;
        }
    }
}
