using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
	/* a Program to create a deck of cards, deal a hand of five cards, and then check the hand to determine whether it is a straight flush, flush, straight, etc., and return that information to the console. For anything less than a pair, the high card value is returned */

  class Program
  {
    static void Main(string[] args)
    {
			// Declare an array of cards and then call a function to fill the array with instances of cards
			Card[] hand = GetHand(args);
			// Sort the array of cards to make hand-checking easier for each of the checking helper functions.
			Array.Sort(hand);

			// Check whether the hand is a straight flush, write to the console
			if (IsFlush(hand) && IsStraight(hand))
			{
				Console.WriteLine("You have a straight flush!");
			}
			// Check whether the hand is a flush, write to the console
			else if (IsFlush(hand))
			{
					Console.WriteLine("You have a flush!");
			}
			// Check whether the hand is a straight, write to the console
			else if (IsStraight(hand))
			{
					Console.WriteLine("You have a straight!");
			}
			// Check whether the hand is a full house, write to the console
			else if (IsFullHouse(hand))
			{
					Console.WriteLine("You have a full house!");
			}
			// Check whether the hand has four of a kind, write to the console
			else if (IsFourOfAKind(hand))
			{
				Console.WriteLine("You have four of a kind!");
			}
			// Check whether the hand has three of a kind, write to the console
			else if (IsThreeOfAKind(hand))
			{
					Console.WriteLine("You have three of a kind!");
			}
			// Check whether the hand has two pairs, write to the console
			else if (IsTwoPairs(hand))
			{
					Console.WriteLine("You have two pairs!");
			}
			// Check whether the hand has a pair, write to the console
			else if (IsPair(hand))
			{
					Console.WriteLine("You have a pair!");
			}
			// Determine the high card, write to the console
			else
			{
				Console.WriteLine("Your high card is: ");
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
				Card c = new Card(a);
				hand[index] = c;
				index++;
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

    // Check to see two (and only two) cards with the same number exist
    static bool IsPair(Card[] hand)
    {
			int counter = 0;
			// cycle through and count the number of duplications
			for (int i = 1; i < hand.Length; i++)
			{
				if (hand[i].rank - hand[i - 1].rank == 0)
				{
					counter += 1;
					Console.WriteLine(counter);
				}
			}
			// check the number of duplications that exist
			if (counter == 1)
			{
				return true;
			}
			return false;
		}

		// Check to see whether three (and only three) cards with the same number exist
		static bool IsThreeOfAKind(Card[] hand)
		{
			int counter = 0;
			// cycle through and count the number of duplications
			for (int i = 1; i < hand.Length; i++)
			{
				if (hand[i].rank - hand[i - 1].rank == 0)
				{
					counter += 1;
					Console.WriteLine(counter);
				}
			}
			// check the number of duplications that exist
			if (counter == 2)
			{
				return true;
			}
			return false;
		}

		// Check to see whether 4 (and only 4) duplications of a card number exists
		static bool IsFourOfAKind(Card[] hand)
    {
			int counter = 0;
			// cycle through and count the number of duplications
			for (int i = 1; i < hand.Length; i++)
			{
				if (hand[i].rank - hand[i - 1].rank == 0)
				{
					counter += 1;
					Console.WriteLine(counter);
				}
			}
			// check the number of duplications that exist
			if (counter == 3)
			{
				return true;
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
			for (int i = 1; i < hand.Length - 1; i++)
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

