using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Programmeur
    {
        private string _nom;
        private string _prenom;
        private int _nbr_bureau;

        public Programmeur(string nom="", string prenom = "", int nbr_bureau=0)
        {
            _nom = nom;
            _prenom = prenom;
            _nbr_bureau = nbr_bureau;
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public int Nbr_bureau
        {
            get { return _nbr_bureau; }
            set { _nbr_bureau = value; }
        }
    }
}
