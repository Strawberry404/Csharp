using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tp5
{
    class Comptes
    {
        private List<Compte> _comptes = new List<Compte>();

        public Comptes(List<Compte> comptes)
        {
            _comptes = comptes;
        }

        public Comptes()
        {
            // Empty constructor
        }

        public List<Compte> Comptess
        {
            get { return _comptes; }
            set { _comptes = value; }
        }

        // Add account
        public void AddAcc(Compte cmpt)
        {
            if (FindAcc(cmpt.NumCmpt) == null)
            {
                Comptess.Add(cmpt);
                Console.WriteLine("Account added successfully.");
            }
            else
            {
                Console.WriteLine("\nAn account with this ID already exists.");
            }
        }

        public void AddAcc(int id, string name, string family)
        {
            if (FindAcc(id) == null)
            {
                Comptess.Add(new Compte(id, name, family));
                Console.WriteLine("Account added successfully.");
            }
            else
            {
                Console.WriteLine("\nAn account with this ID already exists.");
            }
        }

        // Add money to an account
        public void AddMoneyToAnAcc(int id, float money)
        {
            Compte CMP = FindAcc(id);
            if (CMP != null)
            {
                CMP.AddMoney(money);
            }
            else
            {
                Console.WriteLine("\nCannot add money to a non-existent account.");
            }
        }

        // Delete account
        public void DeleteAccount(int id)
        {
            Compte accToDelete = FindAcc(id);
            if (accToDelete != null)
            {
                _comptes.Remove(accToDelete);
                Console.WriteLine($"Account with ID {id} has been deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nCannot delete a non-existent account.");
            }
        }

        // Show all accounts
        public void ShowAllAccounts()
        {
            if (_comptes.Count == 0)
            {
                Console.WriteLine("No accounts to display.");
                return;
            }

            foreach (Compte acc in _comptes)
            {
                Console.WriteLine(acc.ToString());
                Console.WriteLine("-----------------------------------");
            }
        }

        // Find an account
        public Compte FindAcc(int id)
        {
            Compte existingCompte = this.Comptess.FirstOrDefault(c => c.NumCmpt == id);

            if (existingCompte != null)
            {
                return existingCompte;
            }
            else
            {
                Console.WriteLine($"\nLe compte {id} n'existe pas !!!");
            }
            return null;
        }

        // Take money from an account
        public void TakeMoneyFromAnAcc(int id, float money)
        {
            Compte CMP = FindAcc(id);
            if (CMP != null)
            {
                CMP.TakeMoney(money);
            }
            else
            {
                Console.WriteLine("\nCannot take money from a non-existent account.");
            }
        }

        // Transfer money between accounts
        public void TransferMoney(int sourceId, int destId, float amount)
        {
            Compte sourceAcc = FindAcc(sourceId);
            Compte destAcc = FindAcc(destId);

            if (sourceAcc == null)
            {
                Console.WriteLine("\nSource account does not exist.");
                return;
            }

            if (destAcc == null)
            {
                Console.WriteLine("\nDestination account does not exist.");
                return;
            }

            sourceAcc.TransferMoney(destAcc, amount);
        }
    }
}