using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Consomation
    {
        private int _semaine;
        private int _developeurID;
        private int _nbrConsomation;

        public Consomation(int semaine=0, int developeurID = 0, int nbrConsomation = 0)
        {
            _semaine = semaine;
            _developeurID = developeurID;
            _nbrConsomation = nbrConsomation;
        }
        public int Semaine
        {
            get { return _semaine; }
            set { _semaine = value; }
        }
        public int DevelopeurID
        {
            get { return _developeurID; }
            set { _developeurID = value; }
        }
        public int NbrConsomation
        {
            get { return _nbrConsomation; }
            set { _nbrConsomation = value; }
        }

        public void IncrementConsomation()
        {
            _nbrConsomation++;
        }

        public void IncrementConsomation(int nbr)
        {
            _nbrConsomation += nbr;
        }
    }
}
