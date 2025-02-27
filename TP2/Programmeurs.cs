using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Programmeurs
    {
        List<Programmeur> _programmeurs = new List<Programmeur>();


        public List<Programmeur> Programmor
        {
            get { return _programmeurs; }
            set { _programmeurs = value; }
        }
        public void AjouterProgrammeur(Programmeur programmeur)
        {
            _programmeurs.Add(programmeur);
        }
        public void SupprimerProgrammeur(Programmeur programmeur)
        {
            _programmeurs.Remove(programmeur);
        }
        public void AfficherProgrammeurs()
        {
            foreach (Programmeur programmeur in _programmeurs)
            {
                Console.WriteLine("Nom: " + programmeur.Nom + " Prenom: " + programmeur.Prenom + " Bureau: " + programmeur.Nbr_bureau);
            }
        }

        public Programmeur GetProgrammeur(int index)
        {
            return _programmeurs[index];
        }

        public Programmeur GetProgrammeur(string nom = "", string prenom = "", int bureau = 0)
        {
            foreach (Programmeur programmeur in _programmeurs)
            {
                if (programmeur.Nom == nom || nom == "")
                {
                    if (programmeur.Prenom == prenom || prenom == "")
                    {
                        if (programmeur.Nbr_bureau == bureau || bureau == 0)
                        {
                            return programmeur;
                        }
                    }
                }

            }
            return null;

        }
    }
}
.cs