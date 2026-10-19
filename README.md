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
Att Where och OrderBy gjorde att du kan skriva egna loopar. 
Med LINQ kunde jag filtrera, sortera och räkna med en enda rad, till exempel
`Where` för att filtrera på status och `OrderBy` för att sortera på datum.
Utan LINQ hade jag behövt skriva egna foreach-loopar med if-satser och
extra listor, vilket hade gjort koden längre och svårare att läsa.

**Vilken del var mest utmanande?**
Den mest utmanande grejen var att fatta LINQ och att kunde använda den på
smart sätt så att koden kunde bli enklare och lättare att fatta.
