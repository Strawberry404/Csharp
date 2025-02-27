using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TP1.TP1;

namespace TP1
{
    public class Repertoire
    {
        private string _nom;
        private int _nbrFichiers;
        private Fichier[] _references = new Fichier[30];
        private const int MAX_FILES = 30;

        public Repertoire(string nom="", int nbrFichiers=0)
        {
            _nom = nom;
            _nbrFichiers = nbrFichiers;
            _references = new Fichier[MAX_FILES];
        }


        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int NbrFichiers
        {
            get { return _nbrFichiers; }
            set { _nbrFichiers = value; }
        }

        public Fichier[] References
        {
            get { return _references; }
            set { _references = value; }
        }


        public void Afficher()
        {
            Console.WriteLine($"Nom: {_nom}");
            Console.WriteLine($"Nombre de fichiers: {_nbrFichiers}");

            for (int i = 0; i < _nbrFichiers; i++)
            {
                if (_references[i] != null)
                {
                    Console.WriteLine($"Nom: {_references[i].Nom}");
                    Console.WriteLine($"Extension: {_references[i].Extension}");
                    Console.WriteLine($"Taille: {_references[i].Taille}");
                }
            }
        }


        public int Rechercher(String nom)
        {
            for (int i = 0; i < this._nbrFichiers; i++)
            {
                if (this._references[i]?.Nom == nom)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Ajouter(Fichier f)
        {
            if (this._nbrFichiers < MAX_FILES)
            {
                _references[_nbrFichiers++] = f;
            }
            else
            {
                throw new InvalidOperationException("Nombre de fichiers maximum atteint");
            }
        }

        public void Ajouter(String Nom, String Extension, float Taille)
        {
            if (_nbrFichiers >= MAX_FILES)
            {
                throw new InvalidOperationException("Le répertoire est plein");
            }
            if (Rechercher(Nom) != -1)
            {
                Console.WriteLine("Fichier existe deja");
                return;
            }
            _references[_nbrFichiers++] = new Fichier(Nom, Extension, Taille);
        }

        public void Supprimer(String Nom)
        {
            int index = Rechercher(Nom);
            if (index != -1)
            {
                for (int i = index; i < _nbrFichiers; i++)
                {
                    this._references[i] = this._references[i + 1];
                }
                this._nbrFichiers--;
            }
        }

        public void Renommer(Fichier f, String nom)
        {
            int index = Rechercher(f.Nom = nom);
                if (index != -1)
            {
                _references[index].Nom = nom;
            }
            else
            {
                Console.WriteLine("Fichier n'existe pas");
            }
        }

        public void Modifier(Fichier f, float taille)
        {
            int index = Rechercher(f.Nom);
                if (index != -1)
            {
                _references[index].Taille = taille;
            }
            else
            {
                Console.WriteLine("Fichier n'existe pas");
            }
        }

        public float GetTaille()
        {
            float sum = 0;
            for (int i = 0; i < this._nbrFichiers - 1; i++)
            {
                sum += _references[i].Taille;
            }
            return sum;
            //autre prposition 
            //return _references.Take(_nbrFichiers).Sum(f => f?.Taille ?? 0 );
        }

    }

}


