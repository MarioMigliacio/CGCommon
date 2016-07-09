using CGCommon.CardEnums;

namespace CGCommon
{
    /// <summary>
    /// The Card class represents what can appear in a deck of 52 card playing cards.
    /// Also includes public functionality for essential methods and properties.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Private member fields which define a classical card. The Rank corresponds to Ace - King,
        /// and the Suit correspond to the Clubs, Diamonds, Hearts, Spades.
        /// </summary>
        private string _suit;
        private string _rank;
        
        /// <summary>
        /// Rank is exposed to outside world which returns a string representing the Private field _rank.
        /// </summary>
        public string Rank { get { return _rank; } set { _rank = value; } }

        /// <summary>
        /// Suit is exposed to outside world which returns a string representing the Private filed _suit.
        /// </summary>
        public string Suit { get { return _suit; } set { _suit = value; } }
        
        /// <summary>
        /// A specialized ctor which takes in two well defined enums which range from:
        /// </summary>
        /// <param name="suit">Clubs, Diamonds, Hearts, Spades.</param>
        /// <param name="rank">Ace - King.</param>
        public Card(CardSuit suit, CardRank rank)
        {
            _suit = suit.ToString();
            _rank = rank.ToString();
        }
        
        /// <summary>
        /// Uses handy string interpolation to quickly return the string name of the card in the
        /// format: ____ of ____. (Ace of Spades, King of Clubs)..
        /// </summary>
        /// <returns>The string format of the Card in question.</returns>
        public override string ToString()
        {
            return $"{_rank} of {_suit}";
        }
    }
}
