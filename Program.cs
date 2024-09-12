/*
Laboration 2.2 i kursen Programmering i C#.NET, HT24, Mittuniversitetet 
Kod skriven av Stina Persson (stpe1901)
Senast uppdaterad 10/9 - 24 
*/

/*
I denna uppgift ska algorytmen bubble sort jämföras med C# inbygda sortering. 
Detta ska testas på en array med 100 värden i 
*/

/*
Bubble sort innebär att värdena i ex en array jämförs med varandra genom att 
det värde som är bredvid. 
Om tex 9 är bredvid 3 i en array med stigande ordning så byter 9 och 3 plats. 
Man behöver alltså jämföra värdena med varandra i den ordningen som de står för att
till sist få en ordnad lista efter x antal loopar. 
*/


//skapar en array med slumpade heltal från 1-100

//sätter ett minsta värde och ett högsta värde
using System.Diagnostics;

int min = 0; 
int max = 100; 

//initierar en array med 100 siffror
int[] unsortedList = new int[100]; 

//använder Random för att skapa 100 slumpade rummer mellan min och max i längd med arrayen
Random randomNumber = new Random(); 
for (int i=0; i < unsortedList.Length; i++)
{
    unsortedList[i] = randomNumber.Next(min, max); 
} 

//skapar timer som ska ta tid på metoden. 
var timer = new Stopwatch();
timer.Start();

//kallar på metoden
bubbleSort(unsortedList); 

//stannar timern och skriver ut tiden
timer.Stop(); 

//skriver ut sorterade arrayen 
Console.WriteLine(String.Join(", ", unsortedList)); //kan jag skriva detta på ett annat sätt? 

TimeSpan timeTaken = timer.Elapsed;
string time = "Tid: " + timeTaken.ToString(@"m\:ss\.fff");
Console.WriteLine(time); 

//Bubble sort metod 
void bubbleSort(int[] unsortedList) 
{   
    int temp; //en temporär variabel där man sätter in det större värdet 
 
    //första loopen kontrollerar om i är mindre än en mindre än längden på arrayen. Varje gång blir i 1 större. 
    for (int i = 0; i < unsortedList.Length - 1; i++) 
    {
        for (int j = 0; j < unsortedList.Length - (1 + i); j++) 
        {
            if (unsortedList[j] > unsortedList[j +1])
            {   
                //här sker förflyttningen av det större värdet mellan temp och rätt plats i listan efter kontroll
                temp = unsortedList[j + 1]; 
                unsortedList[j + 1] = unsortedList[j]; 
                unsortedList[j] = temp; 
            }
        }
    }
}

//startar ny timer 
var timer2 = new Stopwatch(); 
timer2.Start(); 

//sortering med inbyggda sort
Array.Sort(unsortedList); 
// skriver ut alla siffror
Console.WriteLine(String.Join(", ", unsortedList)); //kan jag skriva detta på ett annat sätt?

//stannar timer nr 2
timer2.Stop(); 

//skriver ut tiden som har gått under andra genomgången 
TimeSpan timeTaken2 = timer2.Elapsed;
string time2 = "Tid: " + timeTaken2.ToString(@"m\:ss\.fff");
Console.WriteLine(time2); 

//jämförelse av tid 
if(timeTaken < timeTaken2)
{
    Console.WriteLine("Bubble sort var snabbare!"); 
} 
else 
{
    Console.WriteLine("Den inbyggda sorteringen var snabbare!"); 
}; 