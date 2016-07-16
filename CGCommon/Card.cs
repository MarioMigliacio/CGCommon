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
        /// and the Suit correspond to the Clubs, Diamonds, Hearts, Spades. Dank is used to convert
        /// the enum rank into an integer for the Rank property.
        /// </summary>
        private string _suit;
        private string _rank;
        private readonly CardRank _dank;
        
        /// <summary>
        /// Suit will be used to fetch the string value of the Card's Suit.
        /// Exposes the card suit to the outside world.
        /// </summary>
        public string Suit { get { return _suit; } set { _suit = value; } }

        /// <summary>
        /// Rank will be used to fetch the integer equivalent of the CardRank enum.
        /// Exposes the card rank to the outside world.
        /// </summary>
        public int Rank => (int)_dank;
        
        /// <summary>
        /// Uses handy string interpolation to quickly return the string name of the card in the
        /// format: ____ of ____. (Ace of Spades, King of Clubs)..
        /// </summary>
        /// <returns>The string format of the Card in question.</returns>
        public override string ToString()
        {
            return $"{_rank} of {_suit}";
        }
        
        /// <summary>
        /// A specialized ctor which takes in two well defined enums which range from:
        /// </summary>
        /// <param name="suit">Clubs, Diamonds, Hearts, Spades.</param>
        /// <param name="rank">Ace - King.</param>
        public Card(CardSuit suit, CardRank rank)
        {
            _suit = suit.ToString();
            _rank = rank.ToString();
            _dank = rank;
        }
    }
}
