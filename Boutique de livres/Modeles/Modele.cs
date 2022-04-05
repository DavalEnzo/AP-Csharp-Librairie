using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Boutique_de_livres.Modeles
{
    public class Modele
    {
        protected MySqlConnection conn = new MySqlConnection("database=bibliotheque; server=localhost; user id = root; pwd=");
    }
}
