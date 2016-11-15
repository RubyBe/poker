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
			if (IsFlush(hand) && IsStraight(hand))
			{
				Console.WriteLine("You have a straight flush!");
			}
			else if (IsFlush(hand))
			{
					Console.WriteLine("You have a flush!");
			}
			else if (IsStraight(hand))
			{
					Console.WriteLine("You have a straight!");
			}
			else if (IsFullHouse(hand))
			{
					Console.WriteLine("You have a full house!");
			}
			else if (IsThreeOfAKind(hand))
			{
					Console.WriteLine("You have three of a kind!");
			}
			else if (IsFourOfAKind(hand))
			{
					Console.WriteLine("You have four of a kind!");
			}
			else if (IsTwoPairs(hand))
			{
					Console.WriteLine("You have two pairs!");
			}
			else if (IsPair(hand))
			{
					Console.WriteLine("You have a pair!");
			}

			Console.ReadLine();
    }

		// get a hand of 5 cards; assign values to suit and rank
    static Card[] GetHand(string[] args)
    {
      Card[] hand = new Card[5];
      int index = 0;

      foreach (string a in args)
      {
        while (index < 5)
        {
					Card c = new Card(a);
					index++;
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
    static bool IsFlush(Card[] hand)
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
    static bool IsStraight(Card[] hand)
    {
      for (int i = 1; i < hand.Length -1; i++)
      {
        if (hand[i + 1].rank - hand[i].rank > 1)
        {
          return false;
        }
      }
      return true;
    }

    // Check to see whether 2 (and only 2) duplications of a card number exists
    static bool IsPair(Card[] hand)
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
    static bool IsFourOfAKind(Card[] hand)
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

		// Check to see whether 2 duplications of 2 different card numbers exist
		static bool IsTwoPairs(Card[] hand)
		{
			int counterPair1 = 0;
			int counterPair2 = 0;
			int tracker = 0;
			bool result = false;
			for (int i = 1; i < hand.Length; i++)
			{
				if (hand[i].rank == hand[i + 1].rank && hand[i].rank != tracker)
				{
					counterPair1 += counterPair1;
					tracker = hand[i].rank;
				}
				if (counterPair1 == 2)
				{
						result = true;
				}
				if (hand[i].rank == hand[i + 1].rank && hand[i].rank != tracker)
				{
					counterPair2 += counterPair2;
					tracker = hand[i].rank;
				}
				if (counterPair2 == 2 && result == true)
				{
					return true;
				}

			}
			return false;
		}

		// Check to see whether three (and only) cards with the same number exists
		static bool IsThreeOfAKind(Card[] hand)
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
    static bool IsFullHouse(Card[] hand)
    {
      if (IsThreeOfAKind(hand) && IsPair(hand))
      {
        return true;
      }
      return false;
    }
  }
}

