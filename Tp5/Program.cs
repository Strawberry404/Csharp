using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5
{
    class Program
    {
        static Comptes banque = new Comptes();
        static string dataFile = "comptes.txt";
        static bool isAdmin = false;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Login();

            if (File.Exists(dataFile))
            {
                LoadAccountsFromFile();
            }

            while (true)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (isAdmin) AddAccount();
                        else Console.WriteLine("Accès refusé. Seul l'administrateur peut ajouter des comptes.");
                        break;
                    case "2":
                        SearchAccount();
                        break;
                    case "3":
                        if (isAdmin) DeleteAccount();
                        else Console.WriteLine("Accès refusé. Seul l'administrateur peut supprimer des comptes.");
                        break;
                    case "4":
                        AccountOperation();
                        break;
                    case "5":
                        DisplayAllAccounts();
                        break;
                    case "6":
                        SaveAccountsToFile();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }

                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void Login()
        {
            // Create default admin user if file doesn't exist
            if (!File.Exists(dataFile))
            {
                using (StreamWriter sw = new StreamWriter(dataFile))
                {
                    // Format: username|password|isAdmin
                    sw.WriteLine("admin|admin123|true");
                    sw.WriteLine("client|client123|false");
                }
                Console.WriteLine("User credentials file created with default users.");
            }
            Console.WriteLine("TP 5: Mode console");
            Console.WriteLine("L'objectif de ce TP est de développer une application console en C# simulant la gestion des comptes bancaires");
            Console.WriteLine("selon les captures ci-dessous. L'application doit permettre à deux types d'utilisateurs, l'administrateur et le");
            Console.WriteLine("client, d'interagir avec le système de manière appropriée.");
            Console.WriteLine();

            Console.Write("Entrez votre identifiant: ");
            string username = Console.ReadLine();
            Console.Write("Entrez votre mot de passe: ");
            string password = Console.ReadLine();

            // Simple authentication - in a real app you'd use encryption and proper auth
            if (username == "admin" && password == "admin123")
            {
                isAdmin = true;
                Console.WriteLine("Connecté en tant qu'administrateur");
            }
            else
            {
                isAdmin = false;
                Console.WriteLine("Connecté en tant que client");
            }

            Console.Clear();
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\n1. Menu principal :");
            Console.WriteLine("===========================================");
            Console.WriteLine("1) Ajouter un nouveau compte");
            Console.WriteLine("2) Rechercher un compte");
            Console.WriteLine("3) Supprimer un compte");
            Console.WriteLine("4) Operation sur un compte");
            Console.WriteLine("5) Afficher tous les comptes");
            Console.WriteLine("6) Quitter le programme");
            Console.WriteLine("===========================================");
            Console.Write("Donnez votre choix: ");
        }

        static void AddAccount()
        {
            Console.WriteLine("\n2. Création d'un compte bancaire :");
            Console.Write("Donnez votre choix: 1\n");

            Console.Write("Entrez le num du compte bancaire: ");
            int numCompte = Convert.ToInt32(Console.ReadLine());

            Console.Write("Entrez le nom du client: ");
            string nom = Console.ReadLine().ToUpper();

            Console.Write("Entrez son prénom: ");
            string prenom = Console.ReadLine();

            banque.AddAcc(numCompte, nom, prenom);

            Console.WriteLine("Création du compte effectuée....");
        }

        static void SearchAccount()
        {
            Console.WriteLine("\n5. Rechercher un compte :");
            Console.Write("Donnez votre choix: 2\n");

            Console.Write("Entrez le numéro du compte: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compte compte = banque.FindAcc(id);

            if (compte != null)
            {
                int operationCount = compte.History.Count;
                Console.WriteLine($"{id} - {compte.Nom} {compte.Prenom} - {compte.Solde:F2} dhs /{operationCount} operation(s) effectuée(s)");
            }
        }

        static void DeleteAccount()
        {
            Console.WriteLine("\n6. Supprimer un compte :");
            Console.Write("Donnez votre choix: 3\n");

            Console.Write("Entrez le numéro du compte: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compte compte = banque.FindAcc(id);

            if (compte != null)
            {
                banque.DeleteAccount(id);
                Console.WriteLine("Compte supprimé.........");
            }
        }

        static void AccountOperation()
        {
            Console.WriteLine("\n3. Opération sur un compte :");
            Console.Write("Donnez votre choix: 4\n");

            Console.Write("Entrez le numéro du compte: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compte compte = banque.FindAcc(id);

            if (compte == null)
            {
                Console.WriteLine($"Le compte {id} n'existe pas !!!");
                return;
            }

            // Sous-menu des opérations
            Console.WriteLine($"\n========== OPERATION SUR LE COMPTE {id} ==========");
            Console.WriteLine("1) Créditer");
            Console.WriteLine("2) Débiter");
            Console.WriteLine("3) Historique");
            Console.WriteLine("4) Transfert d'argent");
            Console.WriteLine("5) Revenir au menu principal");
            Console.WriteLine("===========================================");
            Console.Write("Donnez votre choix: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Créditer
                    Console.WriteLine("\na. Opération Créditer");
                    Console.Write("Donnez votre choix: 1\n");
                    Console.Write("Entrez le montant à verser: ");
                    float creditAmount = Convert.ToSingle(Console.ReadLine());
                    compte.AddMoney(creditAmount);
                    break;

                case "2":
                    // Débiter
                    Console.WriteLine("\nb. Opération Débiter");
                    Console.Write("Donnez votre choix: 2\n");
                    Console.Write("Entrez le montant à retirer: ");
                    float debitAmount = Convert.ToSingle(Console.ReadLine());
                    compte.TakeMoney(debitAmount);
                    break;

                case "3":
                    // Historique
                    Console.WriteLine("\nc. Opération Historique");
                    compte.ShowHistory();
                    break;

                case "4":
                    // Transfert
                    Console.WriteLine("\nd. Opération Transfert d'argent");
                    Console.Write("Donnez votre choix: 4\n");
                    Console.Write("Entrez le numéro du destinataire: ");
                    int destId = Convert.ToInt32(Console.ReadLine());

                    Compte destCompte = banque.FindAcc(destId);

                    if (destCompte == null)
                    {
                        Console.WriteLine($"Le compte destinataire {destId} n'existe pas !!!");
                        return;
                    }

                    Console.Write("Entrez le montant à transférer: ");
                    float transferAmount = Convert.ToSingle(Console.ReadLine());

                    compte.TransferMoney(destCompte, transferAmount);
                    break;

                case "5":
                    // Retour menu principal
                    return;

                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }
        }

        static void DisplayAllAccounts()
        {
            Console.WriteLine("\n4. Afficher tous les comptes :");
            Console.Write("Donnez votre choix: 5\n");

            if (banque.Comptess.Count == 0)
            {
                Console.WriteLine("Aucun compte à afficher.");
                return;
            }

            foreach (var compte in banque.Comptess)
            {
                int operationCount = compte.History.Count;
                Console.WriteLine($"{compte.NumCmpt} - {compte.Nom} {compte.Prenom} - {compte.Solde:F2} dhs /{operationCount} operation(s) effectuée(s)");
            }
        }

        // Load accounts from file
        static void LoadAccountsFromFile()
        {
            try
            {
                string[] lines = File.ReadAllLines(dataFile);

                foreach (var line in lines)
                {
                    string[] data = line.Split('|');
                    if (data.Length >= 4)
                    {
                        int numCompte = Convert.ToInt32(data[0]);
                        string nom = data[1];
                        string prenom = data[2];
                        float solde = Convert.ToSingle(data[3]);

                        Compte compte = new Compte(numCompte, nom, prenom, solde);

                        // Add transactions if they exist
                        if (data.Length > 4)
                        {
                            for (int i = 4; i < data.Length; i += 3)
                            {
                                if (i + 2 < data.Length)
                                {
                                    DateTime date = DateTime.Parse(data[i]);
                                    float amount = Convert.ToSingle(data[i + 1]);
                                    bool isCredit = Convert.ToBoolean(data[i + 2]);

                                    // Add transaction directly to the history
                                    compte.History.Add(new Transaction(
                                        Math.Abs(amount),
                                        compte.Solde,
                                        isCredit)
                                    {
                                        Date = date
                                    });
                                }
                            }
                        }

                        banque.AddAcc(compte);
                    }
                }

                Console.WriteLine("Comptes chargés depuis le fichier.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des comptes: {ex.Message}");
            }
        }

        // Save accounts to file
        static void SaveAccountsToFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var compte in banque.Comptess)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{compte.NumCmpt}|{compte.Nom}|{compte.Prenom}|{compte.Solde}");

                    // Save transaction history
                    foreach (var transaction in compte.History)
                    {
                        sb.Append($"|{transaction.Date}|{transaction.Amount}|{transaction.IsCredit}");
                    }

                    lines.Add(sb.ToString());
                }

                File.WriteAllLines(dataFile, lines);
                Console.WriteLine("Comptes sauvegardés dans le fichier.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la sauvegarde des comptes: {ex.Message}");
            }
        }
    }
}