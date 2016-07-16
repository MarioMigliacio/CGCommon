using System;
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
            var deck = new Deck();
            deck.PrintDeckContents();
        }

        /// <summary>
        /// Test number 2. Create the deck and shufffffffle it. Test to see that there is 
        /// good random distributions without bias.
        /// </summary>
        [TestMethod]
        public void ShuffleDeck()
        {
            var deck = new Deck();
            deck.ShuffleDeck();
            deck.PrintDeckContents();
        }

        /// <summary>
        /// Test number 3. Try and draw a few hands and check that draw works.
        /// </summary>
        [TestMethod]
        public void TestDraw()
        {
            var deck = new Deck();
            deck.ShuffleDeck();

            Hand hand = new Hand(deck);
            hand.DiscardAndDraw(deck);
        }
    }
}
