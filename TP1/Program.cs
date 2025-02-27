using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.TP1;
using System;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new directory
            Repertoire monRepertoire = new Repertoire("Documents", 0);

            try
            {
                // Add some files using different methods
                monRepertoire.Ajouter("Document1", ".txt", 1.5f);
                monRepertoire.Ajouter("Image1", ".jpg", 2.3f);
                monRepertoire.Ajouter(new Fichier("Document2", ".pdf", 3.1f));

                // Display the directory content
                Console.WriteLine("Initial directory content:");
                monRepertoire.Afficher();

                // Test file modification
                Fichier fileToModify = monRepertoire.References[0];
                monRepertoire.Modifier(fileToModify, 2.0f);

                // Test file renaming
                Fichier fileToRename = monRepertoire.References[1];
                monRepertoire.Renommer(fileToRename, "NewImage1");

                // Display after modifications
                Console.WriteLine("\nDirectory content after modifications:");
                monRepertoire.Afficher();

                // Display total size
                Console.WriteLine($"\nTotal directory size: {monRepertoire.GetTaille()} MB");

                // Test file deletion
                Console.WriteLine("\nDeleting Document2...");
                monRepertoire.Supprimer("Document2");

                // Final display
                Console.WriteLine("\nFinal directory content:");
                monRepertoire.Afficher();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}