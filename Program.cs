using static Inlämninguppgist_2.Job_maneger;

namespace Inlämninguppgist_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapar managern som hanterar allt
            var manager = new JobManager();
            bool running = true;

            // Menyn körs tills användaren väljer 0
            while (running)
            {
                Console.WriteLine("\n===== JOB APPLICATION TRACKER =====");
                Console.WriteLine("1. Lägg till ny ansökan");
                Console.WriteLine("2. Visa alla ansökningar");
                Console.WriteLine("3. Filtrera efter status");
                Console.WriteLine("4. Sortera efter datum");
                Console.WriteLine("5. Visa statistik");
                Console.WriteLine("6. Uppdatera status");
                Console.WriteLine("7. Ta bort en ansökan");
                Console.WriteLine("8. Visa utan svar (äldre än 14 dagar)");
                Console.WriteLine("0. Avsluta");
                Console.Write("Ditt val: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": manager.AddJob(); break;
                    case "2": manager.ShowAll(); break;
                    case "3": manager.ShowByStatus(); break;
                    case "4": manager.ShowSortedByDate(); break;
                    case "5": manager.ShowStatistics(); break;
                    case "6": manager.UpdateStatus(); break;
                    case "7": manager.DeleteJob(); break;
                    case "8": manager.ShowNoResponseOld(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Ogiltigt val, försök igen."); break;
                }
            }

            Console.WriteLine("Hej då!");
        }
    } 
}
