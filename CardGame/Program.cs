using System;

namespace ProjectPartBAnswers_B2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Notice on how I use IDeckOfCards and IPlayingCard
            IDeckOfCards myDeck = new DeckOfCards();
            Console.WriteLine($"Freshly created deck:");
            Console.WriteLine(myDeck);
            
            Console.WriteLine($"\nSorted deck:");
            myDeck.Sort();
            Console.WriteLine(myDeck);
            
            Console.WriteLine($"\nShuffled deck:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nHandOfCards:");
            var myHand = new HandOfCards();

            myHand.Add(myDeck.DealOne());
            myHand.Add(myDeck.DealOne());
            myHand.Add(myDeck.DealOne());
            Console.WriteLine(myHand);
            Console.WriteLine(myHand.Highest);

        }
    }
 }
