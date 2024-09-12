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


//testarray med 1-9 

//skapar en array med heltal från 1-100
int[] unsortedList = Enumerable.Range(1, 100).ToArray();

//kallar på metoden 
bubbleSort(unsortedList); 

//skriver ut sorterade arrayen 
Console.WriteLine(String.Join(", ", unsortedList)); //kan jag skriva detta på ett annat sätt? 

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

