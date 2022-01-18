using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique_de_livres.Services
{
    class Session
    {
        public static string name;
        public static string email;
        static Session()
        {
            Session.name = "Roger";
            Session.email = "roger.dupont@aol.fr";
        }
    }
}
