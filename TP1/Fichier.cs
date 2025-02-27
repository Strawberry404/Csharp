using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    namespace TP1
    {
        //classe fichier 
        public class Fichier
        {
            private string _nom;
            private string _extension;
            private float _taille;

            public Fichier(string nom, string extension, float taille)
            {
                _nom = nom;
                _extension = extension;
                _taille = taille;
            }

            public string Nom
            {
                get { return _nom; }
                set { _nom = value; }
            }

            public string Extension
            {
                get { return _extension; }
                set { _extension = value; }
            }
            public float Taille
            {
                get { return _taille; }
                set { _taille = value; }
            }

        }
        //classe repertoire 

    }
}
