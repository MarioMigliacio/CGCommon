namespace CGCommon.CardEnums
{
    /// <summary>
    /// CardSuit represents the Classical colors red and black found in the games of poker.
    /// Supported are Clubs, Diamonds, Hearts, and Spades.
    /// </summary>
    public enum CardSuit
    {
        /// <summary>
        /// The black suit which represents a 3 leaf clover, the Clubs.
        /// </summary>
        Clubs = 1,

        /// <summary>
        /// The red suit which has four pointy edges, the Diamonds.
        /// </summary>
        Diamonds,

        /// <summary>
        /// The red suit which represents everyones favorite shape, the Hearts.
        /// </summary>
        Hearts,

        /// <summary>
        /// The black suit which is essentially an upside down heart with a stem, the Spades.
        /// </summary>
        Spades
    }

    /// <summary>
    /// CardRank represents the essential card numberings and face value cards which occupy 
    /// the standard deck of 52 playing cards. Supported are Ace through King.
    /// </summary>
    public enum CardRank
    {
        /// <summary>
        /// AKA the Deuce.
        /// </summary>
        Two = 2,

        /// <summary>
        /// Trey.
        /// </summary>
        Three,

        /// <summary>
        /// Quads.
        /// </summary>
        Four,

        /// <summary>
        /// Little Nickle.
        /// </summary>
        Five,

        /// <summary>
        /// The number of the beast when multiplied by 111.
        /// </summary>
        Six,

        /// <summary>
        /// LUCKY number 7.
        /// </summary>
        Seven,

        /// <summary>
        /// Crazy 8.
        /// </summary>
        Eight,

        /// <summary>
        /// Not too shabby numero 9.
        /// </summary>
        Nine, 

        /// <summary>
        /// Big Dime.
        /// </summary>
        Ten,

        /// <summary>
        /// The once laughed at jester, slightly less funny then the joker. Decent.
        /// </summary>
        Jack,

        /// <summary>
        /// Her majesty, royal and elegant. The Queen.
        /// </summary>
        Queen,

        /// <summary>
        /// Big ticket players, big papa dont mess.
        /// </summary>
        King,

        /// <summary>
        /// The big kahoona, cant easily beat the pocket aces.
        /// </summary>
        Ace
    }
}
