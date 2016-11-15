using System;
using System.Collections.Generic;

namespace Poker
{

  class Program
  {
    static void Main(string[] args)
    {
      Card[] hand = GetHand(args);
      Array.Sort(hand);
      Console.WriteLine("In Main");
      Console.ReadLine();
    }

    static Card[] GetHand(string[] args)
    {
      Card[] hand = new Card[5];
      int index = 0;

      foreach (string a in args)
      {
        if (index > 4)
        {
          break;
          Card c = new Poker.Card(a);
          hand[index++] = c;
        }

        while (index < 5)
        {
          hand[index++] = Deal();
        }
      }
      return hand;
    }

    static List<Card> deck = null;
    static int dealIndex = 0;

    static Card Deal()
    {
      if (deck == null || dealIndex >= 52) // ran out of cards
      {
        // fill and randomize the list of cards here
      }

      Card nextCard = new Poker.Card();
      return nextCard;
      // return deck[dealIndex++];

    }

    // Check to see whether all cards are of the same suit
    public bool IsFlush(Card[] hand)
    {
      for (int i = 1; i < hand.Length; i++)
      {
        if (hand[i].suit != hand[0].suit)
        {
          return false;
        }
      }
      return true;
    }

    // Check to see whether all cards are consecutively numbered
    public bool IsStraight(Card[] hand)
    {
      for (int i = 1; i < hand.Length; i++)
      {
        if (hand[i + 1].rank - hand[i].rank > 1)
        {
          return false;
        }
      }
      return true;
    }

    // Check to see whether 2 (and only 2) duplications of a card number exists
    public bool IsPair(Card[] hand)
    {
      for (int i = 1; i < hand.Length; i++)
      {
        if (hand[i + 1].rank - hand[i].rank == 0)
        {
          return true;
        }
      }
      return false;
    }

    // Check to see whether 4 (and only 4) duplications of a card number exists
    public bool IsTwoPair(Card[] hand)
    {
      int counter = 0;
      for (int i = 1; i < hand.Length; i++)
      {
        if (hand[i + 1].rank - hand[i].rank == 0)
        {
          counter += counter;
        }
        if (counter == 2)
        {
          return true;
        }
      }
      return false;
    }

    // Check to see whether three (and only) cards with the same number exists
    public bool IsThreeOfAKind(Card[] hand)
    {
      int counter = 0;
      for (int i = 1; i < hand.Length; i++)
      {
        if (hand[i + 1].rank - hand[i].rank == 0)
        {
          counter += counter;
        }

        if (counter == 3)
        {
          return true;
        }
      }
      return false;
    }

    // Check to see whether both a duplication of two card numbers plus three of a card number exists
    public bool IsFullHouse(Card[] hand)
    {
      if (IsThreeOfAKind(hand) && IsPair(hand))
      {
        return true;
      }
      return false;
    }
  }
}

