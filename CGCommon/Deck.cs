using CGCommon.CardEnums;
using System;

namespace CGCommon
{
    /// <summary>
    /// Deck is your typical 52 card deck of cards.
    /// 13 Glorious Ranks A-K, and 4 Classical Suits Clubs, Diamonds, Hearts, Spades.
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// Private field _deck represents the 52 card poker playing deck.
        /// _r is a static random which we will use during shuffle.
        /// </summary>
        private Card[] _deck = new Card[52];
        private static readonly Random _r = new Random();
        
        /// <summary>
        /// This ShuffleDeck algorithm is The Fisher-Yates Shuffle. Credit where its due.
        /// From the last index, swap with a random index ranging from 0 to i-1, iterating
        /// down to the 0 index. Each card is equally likely to partake in a swap, 52 times.
        /// This produces a moderately *RANDOM* deck of cards which doesn't contain BIAS.
        /// Not putting effort into procuring a better random algorithm then .NET's Random() class.
        /// </summary>
        public void ShuffleDeck()
        {
            for (int n = _deck.Length - 1; n > 0; n--)
            {
                int k = _r.Next(n + 1);
                Card swap1 = _deck[n];
                Card swap2 = _deck[k];
                _deck[n] = swap2;
                _deck[k] = swap1;
            }
        }

        /// <summary>
        /// DrawCard replaces the first non null index of _deck with null, and returns the Card back.
        /// </summary>
        /// <returns>The first non null Card in _deck, replaces _deck at the index with null.</returns>
        public Card DrawCard()
        {
            Card drawCard = null;
            int index = 0;

            for (int i = 0; i < 52; i++)
            {
                drawCard = GetCard(i);

                if (drawCard != null)
                {
                    _deck[i] = null;
                    return drawCard;
                }
            }

            if (drawCard == null)
            {
                Console.WriteLine("No more cards in deck!");
            }

            return null;
        }

        /// <summary>
        /// PrintDeckContents is for display purposes. It writes 
        /// to standard out through the Console each and every card
        /// that is in the Deck.
        /// </summary>
        public void PrintDeckContents()
        {
            Console.WriteLine("Deck contents: ");

            foreach (var card in _deck)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Ctor for a standard - in order - deck of cards. After instantiating 
        /// the deck of cards contains 52 Cards with ToString capability. These 
        /// cards order from Clubs 2-A, Diamonds 2-A, Hearts 2-A, Spades 2-A.
        /// </summary>
        public Deck()
        {
            int i = 0;

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    _deck[i] = new Card(suit, rank);
                    i++;
                }
            }
        }

        /// <summary>
        /// GetCard is a private method which is used by the Deck class to provide Draw() method a 
        /// means to effectively cycle through the deck.
        /// </summary>
        /// <param name="index">The index to peek at, and get the card that lies in the deck at that position.</param>
        /// <returns>The Card found in the deck at the index.</returns>
        private Card GetCard(int index)
        {
            return _deck[index];
        }
    }
}
