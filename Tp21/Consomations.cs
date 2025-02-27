using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Consomations
    {
        private List<Consomation> _consomations =  new List<Consomation>();


        public Consomations( )
        {
        }

        public List<Consomation> Consomationss
        {
            get { return _consomations; }
            set { _consomations = value; }
        }

        public void AddConsomation(int id , int semaine, int nbrTasse=0)
        {


            Consomation existingConsomation = this.Consomationss.FirstOrDefault(c => c.DevelopeurID == id && c.Semaine == semaine);

            if (existingConsomation != null)
            {
                // Increment the number of cups for existing record
                existingConsomation.NbrConsomation += nbrTasse;
            }
            else
            {
                // Create a new consumption record
                this.Consomationss.Add(new Consomation(semaine, id, nbrTasse));
            }
        }

        public int ConsomationPerWeek(int semaine)
        {
            int sum = 0;
            foreach (Consomation consomation in Consomationss)
            {
                if (consomation.Semaine == semaine)
                {
                    sum += consomation.NbrConsomation;
                }

            }
            return sum;
        }
    }
}
