using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique_de_livres.dtos
{
    public class dtoGenre
    {
        private int _idGenre;

        public int IdGenre { get { return _idGenre; } set { _idGenre = value; } }

        private string _genre;

        public string Genre { get { return _genre; } set { _genre = value; } }

        public dtoGenre(string genre, int idGenre = 0)
        {
            if(idGenre > 0)
            {
                this._idGenre = idGenre;
                this._genre = genre;
            }
        }


    }
}
