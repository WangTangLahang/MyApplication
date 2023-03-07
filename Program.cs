using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Card
{
    //Base for the Card class.
    //Value: numbers 1 - 13
    //Suit: numbers 1 - 4
    //The 'set' methods for these properties could have some validation
    public int Value { get; set; }
    public int Suit { get; set; }

    public Card(int value, int suit)
    {
        Value = value;
        Suit = suit;
    }
    
}
        
class Pack
{
    public List<Card> _cards;//creates a list for the cards to be initialised

    public Pack()
    {
        _cards = new List<Card>();
        //Initialise the card pack here
        foreach (var Suit in new[] { 1,2,3,4 })
        {
            for (int rank = 1; rank <= 13; rank++)
            {
                _cards.Add(new Card(Suit, rank));
                //creates 13 new cards for each suit, for a total of 52 cards
            }
        }
    }

    public void ShuffleCardPack()
    {
        //Fisher-Yates shuffle algorithm
        Random rng = new Random();
        int n = _cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            //swaps two random cards in the pack until all cards have been shuffled
            Card temp = _cards[k];
            _cards[k] = _cards[n];
            _cards[n] = temp;
            //Shuffles the pack based on the type of shuffle
        }
    }

    public Card Deal()
    //removes one card from the pack and returns it
    {
        if (_cards.Count == 0)
        //checks if all cards from the pack have been dealt
        {
            throw new InvalidOperationException("The pack is empty.");
        }
        Card card = _cards[_cards.Count - 1];
        _cards.RemoveAt(_cards.Count - 1);
        return card;
        //Deals one card
    }
}

class Testing
{
    static void Main(string[] args)
    {
        Pack pack = new Pack();
        //initialises the card pack
        Console.WriteLine("A pack of cards has been created,");

        Console.WriteLine("Now shuffling the pack of cards.");
        pack.ShuffleCardPack();
        //calls for the cards to be shuffled
        Console.WriteLine("The cards have now been shuffled,");
    
        Console.WriteLine("Now one card will be dealt:");
        Card dealtCard = pack.Deal();
        //calls for one card from the pack to be dealt
        Console.WriteLine($"Dealt card: {dealtCard.Value} of {dealtCard.Suit}");
        //outputs the randomly selected card

        Console.ReadLine();
    }
}
