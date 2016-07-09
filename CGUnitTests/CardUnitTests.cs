using CGCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CGUnitTests
{
    /// <summary>
    /// Because we are smart, we build as we go and test features as we develop them.
    /// This is the Object Oriented Agile approach! Follow conventions and learn to
    /// program professionally!
    /// </summary>
    [TestClass]
    public class CardUnitTests
    {
        /// <summary>
        /// Test number 1. Create a deck of 52 playing cards using the standard constructor.
        /// </summary>
        [TestMethod]
        public void CreateDeck()
        {
            var deck = new Deck52Standard();
            deck.PrintDeckContents();
        }

        /// <summary>
        /// Test number 2. Create the deck and shufffffffle it. Test to see that there is 
        /// good random distributions without bias.
        /// </summary>
        [TestMethod]
        public void ShuffleDeck()
        {
            var deck = new Deck52Standard();
            deck.ShuffleDeck();
            deck.PrintDeckContents();
        }
    }
}
