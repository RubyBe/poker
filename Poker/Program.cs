using System;

namespace Poker
{
	/* a Program to create a deck of cards, deal a hand of five cards, and then check the hand to determine whether it is a straight flush, flush, straight, etc., and return that information to the console. For anything less than a pair, the high card value is returned */

  class Program
  {
    static void Main(string[] args)
    {
			Card[] deck = new Card[52];
			deck = GetDeck();
			foreach(var card in deck)
			{
				Console.WriteLine("Card: " + card.suit + card.rank);
			}

			Card[] dealedHand = DealHand(deck);
			foreach(var card in dealedHand)
			{
				Console.WriteLine("Hand: " + card.suit + card.rank);
			}

			// Methods to Create decks and hands (will move to game class later)

			//-------------------------------------------------------------------------
			// Declare an array of cards and then call a function to fill the array with instances of cards - this section is for testing
			Card[] hand = GetHand(args);
			// Sort the array of cards to make hand-checking easier for each of the checking helper functions.
			Array.Sort(hand);


			//-------------------------------------------------------------------------
			// Check for each type of hand by calling appropriate methods and then writing result to the console
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
			else
			{
				// Determine the high card, write to the console
				int highCard = GetHighCard(hand);
				Console.WriteLine("Your high card is: " + highCard);
				Console.ReadLine();
			}
    }

		//-------------------------------------------------------------------------
		// Methods to generate decks and hands of cards
		// generate a random deck of cards
		static Card[] GetDeck()
		{
			Card[] deck = new Card[52];
			char[] suitList = new char[] { 'C', 'D', 'H', 'S' };
			int k = 0;
			for(int i = 0; i < 4; i++)
			{
				for (int j = 2; j < 15; j++)
				{
					Card c = new Card();
					c.rank = j;
					c.suit = suitList[i];
					deck[k] = c;
					k++;
				}
			}
			return deck;
		}
			
		// get a hand of 5 cards from system args for testing
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

		// have the game create a hand of 5 cards for playing
		static int dealIndex = 0;

		static Card[] DealHand(Card[] deck)
		{
			Card[] hand = new Card[5];
			if (deck == null || dealIndex >= 52) // ran out of cards
			{
				deck = GetDeck();
			}
			for(int i = 0; i < 5; i++)
			{
				hand[i] = deck[dealIndex];
				dealIndex++;
			}
			// Card nextCard = new Card(); -- use this later for replenishing?
			return hand;
		}

		//-------------------------------------------------------------------------
		// Helper functions to determine the composition of each hand (will move to a classification class later)
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
      for (int i = 1; i < hand.Length - 1; i++)
      {
        if (hand[i].rank - hand[i - 1].rank != 1)
        {
          return false;
        }
      }
      return true;
    }

		// Check to see whether both a duplication of two card numbers plus three of a card number exists
		static bool IsFullHouse(Card[] hand)
		{
			// set up separate counters to track each set
			int counterPair = 0;
			int counterTrio = 0;
			// set up a tracker to differentiate between pairs, and two bools to flag when each set count has been reached
			int tracker = 0;
			bool resultPair = false;
			bool resultTrio = false;
			// look for a pair, and if found, fill the tracker with the rank
			for (int i = 1; i < hand.Length - 1; i++)
			{
				if (hand[i].rank == hand[i - 1].rank)
				{
					counterPair += 1;
					tracker = hand[i].rank;
				}
			}
			// if a pair was found, set the pair result to true
			if (counterPair == 1)
			{
				resultPair = true;
			}
			// look for a trio
			for (int i = 1; i < hand.Length - 1; i++)
			{
				// check for three duplications of a type other than in the pair
				if (hand[i].rank == hand[i - 1].rank && hand[i].rank != tracker)
				{
					counterTrio += 1;
					tracker = hand[i].rank;
				}
			}
			// if a trio was found, set the trio result to true
			if (counterTrio == 2)
			{
				resultTrio = true;
			}
			// if both pair and trio results are true, we have full house, so return true
			if (resultPair && resultTrio)
			{
				return true;
			}
			return false;
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
				}
			}
			// check the number of duplications that exist and return true if it's a single duplication
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
			int dupTracker = 0;
			// cycle through and count the number of duplications
			for (int i = 1; i < hand.Length; i++)
			{
				if (hand[i].rank - hand[dupTracker].rank == 0)
				{
					dupTracker = i;
					counter += 1;
				}
			}
			// check the number of duplications that exist
			if (counter == 2)
			{
				return true;
			}
			return false;
		}

		// Check to see whether 4 (and only 4) duplications of a single card number exists
		static bool IsFourOfAKind(Card[] hand)
    {
			int counter = 0;
			int dupTracker = 0;
			// cycle through and count the number of duplications
			for (int i = 1; i < hand.Length; i++)
			{
				if (hand[i].rank - hand[dupTracker].rank == 0)
				{
					counter += 1;
					dupTracker = i;
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
			// set up separate counters to track each pair
			int counterPair1 = 0;
			int counterPair2 = 0;
			// set up a tracker to differentiate between pairs, and two bools to flag when each pair count has been reached
			int tracker = 0;
			bool result1 = false;
			bool result2 = false;
			for (int i = 1; i < hand.Length - 1; i++)
			{
				if (hand[i].rank == hand[i - 1].rank)
				{
					counterPair1 += 1;
					tracker = hand[i].rank;
				}
				if (counterPair1 == 1)
				{
					result1 = true;
				}
			}
			for (int i = 1; i < hand.Length -1; i++)
			{
				if (hand[i].rank == hand[i - 1].rank && hand[i].rank != tracker)
				{
					counterPair2 += 1;
					tracker = hand[i].rank;
				}
				if (counterPair2 == 1)
				{
					result2 = true;
				}
			}
			if (result1 && result2)
			{
				return true;
			}
			return false;
		}
		// if no better hand, then get the high card in the hand
		static int GetHighCard(Card[] hand)
		{
			// TODO
			int highCard = 9;
			return highCard;
		}
  }
}

