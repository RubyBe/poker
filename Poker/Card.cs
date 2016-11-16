using System;


namespace Poker
{
  class Card : IComparable
  {
    public char suit; // C, H, D, S
    public int rank; // 2 - 14

    public Card()
    {
        
    }

    public Card(string str)
    {
      str = str.ToUpper();
      foreach (char c in str)
      {
        switch (c)
        {
          case 'C':
          case 'D':
          case 'H':
          case 'S':
            suit = c;
            break;
          case 'A':
            rank = 14;
            break;
          case 'K':
            rank = 13;
            break;
          case 'Q':
            rank = 12;
            break;
          case 'J':
            rank = 11;
            break;
          case '9':
          case '8':
          case '7':
          case '6':
          case '5':
          case '4':
          case '3':
          case '2':
            rank = c - '0';
            break;
        }
      }

			//Console.WriteLine("rank: " + rank + " suit: " + suit);
      if (rank == 0)
      {
        Console.WriteLine("Enter a rank: " + str);
      }

      if (suit == 0)
      {
          Console.WriteLine("Enter a suit: " + str);
      }
    }

    bool IsValid()
    {
      return suit != '\0' && rank >= 2 && rank <= 14;
    }

    public int CompareTo(object obj)
    {
      Card c = obj as Card;
      return rank - c.rank;
    }
  }
}
