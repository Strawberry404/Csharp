using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5
{
    // Create a class to store transaction information
    public class Transaction
    {
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public float BalanceAfter { get; set; }
        public bool IsCredit { get; set; }

        public Transaction(float amount, float balanceAfter, bool isCredit)
        {
            Date = DateTime.Now;
            Amount = amount;
            BalanceAfter = balanceAfter;
            IsCredit = isCredit;
        }
    }

    class Compte
    {
        private int _numCmpt;
        private String _nomClient;
        private String _prenomClient;
        private float _solde;
        private List<Transaction> _history; // Changed from List<float> to List<Transaction>

        public Compte(int numCmpt, string nomClient, string prenomClient, float solde=0 )
        {
            _numCmpt = numCmpt;
            _nomClient = nomClient;
            _prenomClient = prenomClient;
            _solde = solde;
            _history = new List<Transaction>(); // Initialize list of transactions

        }

        public string Nom
        {
            get { return _nomClient; }
            set { _nomClient = value; }
        }
        public string Prenom
        {
            get { return _prenomClient; }
            set { _prenomClient = value; }
        }
        public int NumCmpt
        {
            get { return _numCmpt; }
            set { _numCmpt = value; }
        }
        public float Solde
        {
            get { return _solde; }
            set { _solde = value; }
        }
        public List<Transaction> History
        {
            get { return _history; }
        }

        public  void AddMoney(float money)
        {
            Console.WriteLine("money state before : "+ this.Solde);

            this.Solde += money;
            this._history.Add(new Transaction(money, this.Solde, true));

            Console.WriteLine("money state  after : " + this.Solde);

        }

        public void TakeMoney(float money)
        {
            Console.WriteLine("money state before : " + this.Solde);
            if(this.Solde>= money)
            {
                this.Solde -= money;
                this.History.Add(new Transaction(money, this.Solde, false));

            }
            else
            {
                Console.WriteLine("you don't have enough money");

            }
            Console.WriteLine("money state  after : " + this.Solde);

        }
        public void ShowHistory()
        {
            Console.WriteLine("Donnez votre choix: " + this.NumCmpt);

            foreach (Transaction transaction in _history)
            {
                string operationType = transaction.IsCredit ? "Operation credite" : "Operation debit";
                Console.WriteLine($"*** {operationType}: {transaction.Date.ToString("dd/MM/yyyy HH:mm:ss")} ***");
                Console.WriteLine($"    Montant: {transaction.Amount:F2} dhs");
                Console.WriteLine($"    Solde: {transaction.BalanceAfter:F2} dhs");
            }
        }
        public override string ToString()
        {
            return $"Compte N°{NumCmpt}\nClient: {Prenom} {Nom}\nSolde: {Solde}";
        }

        public void TransferMoney(Compte cmpt , float money)
        {
            if (cmpt != null)
            {
                if (this.Solde >= money)
                {
                    this.TakeMoney(money);
                    cmpt.AddMoney(money);
                    Console.WriteLine($"Transferred {money} from account {this.NumCmpt} to account {cmpt.NumCmpt}");

                }

            }
            else
            {
                Console.WriteLine("Insufficient funds or unexistant account for transfer");
            }
        }
    }
}
