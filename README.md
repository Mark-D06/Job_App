# Job Application Tracker

## Projektbeskrivning
Ett konsolprogram i C# som håller koll på mina jobbansökningar.
Man kan lägga till, visa, filtrera, sortera, uppdatera och ta bort ansökningar samt se statistik.

## Hur man kör programmet
1. Klona repot
2. Öppna mappen i terminalen
3. Kör `dotnet run`

## Skapad av
Mark Daniel Nwankwo, 2026-10-19

## Reflektion
**Hur hjälpte LINQ dig att skriva renare kod?**
Att Where och OrderBy gjorde att du slapp skriva egna loopar. 
Med LINQ kunde jag filtrera, sortera och räkna med en enda rad, till exempel
`Where` för att filtrera på status och `OrderBy` för att sortera på datum.
Utan LINQ hade jag behövt skriva egna foreach-loopar med if-satser och
extra listor, vilket hade gjort koden längre och svårare att läsa.

**Vilken del var mest utmanande?**
Git-branches och pull requests, eller hantering av DateTime?.
Den mest utmanande delen var att hantera status. Jag fick ett fel där enumen och
egenskapen hette samma sak, och löste det genom att döpa om enumen till
ApplicationStatus och låta användaren välja status med siffror i stället för text.
Jag fick också ett fel där Windows blockerade programmet, vilket jag löste genom att
köra det via dotnet i stället för .exe-filen. Git med branches och pull requests
var också nytt för mig.
