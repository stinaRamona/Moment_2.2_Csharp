/*
Laboration 2.2 i kursen Programmering i C#.NET, HT24, Mittuniversitetet 
Kod skriven av Stina Persson (stpe1901)
Senast uppdaterad 13/9 - 24 
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

//initierar så att man kan använda stopwatch
using System.Diagnostics;

//Läser argument som skickas med i start av programmet 
bool argCheck(string[] args)
{   
    //Grund är fallande
    bool isDescending = false;
    if(args.Length > 0 && args[0] == "-p")
    {
        if(args.Length > 1 && args[1] == "1")
        {
            isDescending = true; //Ändrar till stigande om argumentet som skickas med är -- -p 1
        }
    }

    return isDescending;
};


//sätter ett minsta värde och ett högsta värde
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

//skriver ut den osorterade listan 
Console.WriteLine("Osorterad lista:");
Console.WriteLine(String.Join(", ", unsortedList));

//skapar timer som ska ta tid på metoden. 
var timer = new Stopwatch();
timer.Start();

//kontroll av argument
bool isDescending = argCheck(args);

//kallar på metoden
bubbleSort(unsortedList, isDescending); 

//stannar timern och skriver ut tiden
timer.Stop(); 

//skriver ut sorterade arrayen
Console.WriteLine("Sorterad med bubble sort:"); 
Console.WriteLine(String.Join(", ", unsortedList)); //kan jag skriva detta på ett annat sätt? 

TimeSpan timeTaken = timer.Elapsed;
string time = "Tid: " + timeTaken.ToString(@"m\:ss\.fff");
Console.WriteLine(time); 

//Bubble sort metod 
void bubbleSort(int[] unsortedList, bool isDescending) 
{   
    int temp; //en temporär variabel där man sätter in det större värdet 
 
    //första loopen kontrollerar om i är mindre än en mindre än längden på arrayen. Varje gång blir i 1 större. 
    for (int i = 0; i < unsortedList.Length - 1; i++) 
    {
        for (int j = 0; j < unsortedList.Length - (1 + i); j++) 
        {

            bool condition = isDescending 
                ? unsortedList[j] < unsortedList[j+ 1]  //fallande ordning
                : unsortedList[j] > unsortedList[j+ 1]; //stigande ordning 

                if(condition) 
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
if(isDescending) 
{
    Array.Sort(unsortedList);
    Array.Reverse(unsortedList); //för fallande  
} 
else 
{
    Array.Sort(unsortedList);// default som är stigande
}

//stannar timer nr 2
timer2.Stop(); 

// skriver ut alla siffror
Console.WriteLine("Sorterad med Array.Sort():");
Console.WriteLine(String.Join(", ", unsortedList)); //kan jag skriva detta på ett annat sätt?


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