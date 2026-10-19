using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämninguppgist_2
{
    internal class Job_Application
    {
        // De fyra statusarna en ansökan kan ha
        public enum ApplicationStatus { Applied, Interview, Offer, Rejected }

        // Representerar EN jobbansökan
        public class JobApplication
        {
            public string CompanyName { get; set; } = "";
            public string PositionTitle { get; set; } = "";
            public ApplicationStatus Status { get; set; }
            public DateTime ApplicationDate { get; set; }
            public DateTime? ResponseDate { get; set; }   // ? betyder att det kan vara tomt
            public int SalaryExpectation { get; set; }

            // Antal dagar sedan ansökan skickades
            public int GetDaysSinceApplied()
            {
                return (DateTime.Now - ApplicationDate).Days;
            }

            // Kort sammanfattning
            public string GetSummary()
            {
                return $"{CompanyName} - {PositionTitle} | {Status} | {SalaryExpectation} kr | {ApplicationDate:yyyy-MM-dd}";
            }
        }
    }
}
