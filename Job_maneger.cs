using System;
using System.Collections.Generic;
using System.Text;
using static Inlämninguppgist_2.Job_Application;

namespace Inlämninguppgist_2
{
    internal class Job_maneger
    {
        // Hanterar alla ansökningar
        public class JobManager
        {
            // Listan med alla ansökningar
            public List<JobApplication> Applications { get; set; } = new List<JobApplication>();

            // Låter användaren välja status med siffra. Returnerar null om valet är ogiltigt.
            private ApplicationStatus? AskForStatus()
            {
                Console.WriteLine("Välj status:");
                Console.WriteLine("1. Applied");
                Console.WriteLine("2. Interview");
                Console.WriteLine("3. Offer");
                Console.WriteLine("4. Rejected");
                Console.Write("Ditt val: ");

                switch (Console.ReadLine())
                {
                    case "1": return ApplicationStatus.Applied;
                    case "2": return ApplicationStatus.Interview;
                    case "3": return ApplicationStatus.Offer;
                    case "4": return ApplicationStatus.Rejected;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        return null;
                }
            }

            // Lägger till en ny ansökan
            public void AddJob()
            {
                var job = new JobApplication();

                Console.Write("Företag: ");
                job.CompanyName = Console.ReadLine() ?? "";

                Console.Write("Tjänst: ");
                job.PositionTitle = Console.ReadLine() ?? "";

                Console.Write("Önskad lön (kr): ");
                if (!int.TryParse(Console.ReadLine(), out int salary))
                {
                    Console.WriteLine("Ogiltig lön. Ansökan sparades inte.");
                    return;
                }
                job.SalaryExpectation = salary;

                Console.Write("Datum du ansökte (åååå-mm-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    Console.WriteLine("Ogiltigt datum. Ansökan sparades inte.");
                    return;
                }
                job.ApplicationDate = date;
                job.Status = ApplicationStatus.Applied;

                Applications.Add(job);
                Console.WriteLine("Ansökan tillagd!");
            }

            // Visar alla ansökningar
            public void ShowAll()
            {
                ShowList(Applications);
            }

            // Visar en lista med nummer och färg (används av flera metoder)
            private void ShowList(IEnumerable<JobApplication> list)
            {
                int number = 1;
                foreach (var job in list)
                {
                    // Färg beroende på status (VG)
                    if (job.Status == ApplicationStatus.Offer)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (job.Status == ApplicationStatus.Rejected)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"{number}. {job.GetSummary()}");
                    Console.ResetColor();
                    number++;
                }
                if (number == 1) Console.WriteLine("Inga ansökningar hittades.");
            }

            // LINQ 1: Filtrera på status (Where)
            public void ShowByStatus()
            {
                ApplicationStatus? chosen = AskForStatus();
                if (chosen == null) return;   // ogiltigt val, avbryt

                var filtered = Applications.Where(a => a.Status == chosen);
                ShowList(filtered);
            }

            // LINQ 2: Sortera på datum (OrderBy)
            public void ShowSortedByDate()
            {
                var sorted = Applications.OrderBy(a => a.ApplicationDate);
                ShowList(sorted);
            }

            // LINQ 3: Statistik (Count, Where, Average)
            public void ShowStatistics()
            {
                Console.WriteLine($"Totalt antal ansökningar: {Applications.Count()}");

                // Antal per status
                Console.WriteLine($"Applied: {Applications.Count(a => a.Status == ApplicationStatus.Applied)}");
                Console.WriteLine($"Interview: {Applications.Count(a => a.Status == ApplicationStatus.Interview)}");
                Console.WriteLine($"Offer: {Applications.Count(a => a.Status == ApplicationStatus.Offer)}");
                Console.WriteLine($"Rejected: {Applications.Count(a => a.Status == ApplicationStatus.Rejected)}");

                // Genomsnittlig svarstid (bara de som har fått svar)
                var withResponse = Applications.Where(a => a.ResponseDate != null);
                if (withResponse.Any())
                {
                    double avg = withResponse.Average(a => (a.ResponseDate!.Value - a.ApplicationDate).TotalDays);
                    Console.WriteLine($"Genomsnittlig svarstid: {avg:F1} dagar");
                }
                else
                {
                    Console.WriteLine("Genomsnittlig svarstid: inga svar ännu");
                }
            }

            // Extra filter (VG): inget svar och äldre än 14 dagar
            public void ShowNoResponseOld()
            {
                var old = Applications.Where(a => a.ResponseDate == null && a.GetDaysSinceApplied() > 14);
                ShowList(old);
            }

            // Ändrar status på en ansökan
            public void UpdateStatus()
            {
                ShowAll();
                Console.Write("Vilket nummer vill du ändra? ");
                if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > Applications.Count)
                {
                    Console.WriteLine("Ogiltigt nummer.");
                    return;
                }

                ApplicationStatus? newStatus = AskForStatus();
                if (newStatus == null) return;   // ogiltigt val, avbryt

                var job = Applications[number - 1];
                job.Status = newStatus.Value;
                job.ResponseDate = DateTime.Now;   // vi sparar att vi fick svar nu
                Console.WriteLine("Status uppdaterad!");
            }

            // Tar bort en ansökan
            public void DeleteJob()
            {
                ShowAll();
                Console.Write("Vilket nummer vill du ta bort? ");
                if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > Applications.Count)
                {
                    Console.WriteLine("Ogiltigt nummer.");
                    return;
                }
                Applications.RemoveAt(number - 1);
                Console.WriteLine("Ansökan borttagen!");
            }
        }
    }
}
