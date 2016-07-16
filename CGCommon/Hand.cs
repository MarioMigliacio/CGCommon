using System;
using System.IO;

namespace CGCommon
{
    /// <summary>
    /// Because we want to play some fun poker games, here is the most primative form:
    /// 5 hand stud. You draw 5, then you choose if you want to discard any/the whole hand -
    /// ONE attempt. Your hand is then evaluated and the round is over. This can be a point
    /// scoring system which could go under development at some point.
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// _hand is designed to be for a 5 hand draw game. You are only allowed 5 cards, 
        /// and there is only one Draw round - in which the user can discard any number of 
        /// cards in favor of drawing the same amount from the deck. 
        /// </summary>
        private Card[] _hand = new Card[5];

        /// <summary>
        /// GetHand() is a public method which exposes _hand to the outside world. Typically 
        /// used in the HandEvaluator class to get the 5 cards in hand and evaluate them.
        /// </summary>
        /// <returns>The array of Cards which form the players hand.</returns>
        public Card[] GetHand()
        {
            return _hand;
        }
       
        /// <summary>
        /// DiscardAndDraw is an important function which requires an already instantiated deck and hand.
        /// The function will prompt the user to decide which cards they want to discard (if any), then 
        /// that many cards will be drawn from the deck and placed into the hands.
        /// </summary>
        /// <param name="deck">By design choice, the deck must be passed in for this method.</param>
        public void DiscardAndDraw(Deck deck)
        {
            bool[] whichCards = new bool[5];

            DisplayHand();
            whichCards = GetCardsToDiscard();

            for (int i = 0; i < 5; i++)
            {
                if (whichCards[i])
                {
                    _hand[i] = deck.DrawCard();
                }
            }

            Console.WriteLine("After draw round, your hand consists of: ");
            SortHand();
            DisplayHand();
        }

        /// <summary>
        /// Displays the 5 cards that are in _hand. Useful for when the user is asked if they want to 
        /// discard cards or keep the current hand during the draw phase.
        /// </summary>
        public void DisplayHand()
        {
            for (int i = 0; i < 5; i++)
            {
                Card tempCard = _hand[i];
                Console.WriteLine($"{i + 1}: {tempCard}");
            }
        }

        /// <summary>
        /// Ctor for a typical 5 card hand for a player. After instantiation the _hand will contain the 
        /// first 0 - 4 indexed Cards from the Deck. Those cards drawn are implicately converted into null
        /// for the integrity of future draw calls.
        /// </summary>
        /// <param name="deck">By design choice, the deck must be passed in for a hand to be created.</param>
        public Hand(Deck deck)
        {
            for (int i = 0; i < 5; i++)
            {
                _hand[i] = deck.DrawCard();
            }

            SortHand();
        }

        /// <summary>
        /// Private function which is used internally during hand construction and again after draw 
        /// phase to sort the cards based on Rank. Very useful when it comes time to evaluate the 
        /// hand, we are guaranteed increasing order of card rank.
        /// </summary>
        private void SortHand()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = i; j < 5; j++)
                {
                    if (_hand[i].Rank > _hand[j].Rank)
                    {
                        Card temp = _hand[i];
                        _hand[i] = _hand[j];
                        _hand[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// GetCardsToDiscard is a helper method which will return a boolean array of truth values.
        /// After getting input from standard in using the Console.ReadKey() method, the array returned
        /// will be used in a simple for loop that replaces those Cards of _hand[index] with new draws.
        /// </summary>
        /// <returns>The truth value boolean array corresponding to indexes of desired discard cards.</returns>
        private bool[] GetCardsToDiscard()
        {
            bool[] whichCards = new bool[5];

            Console.WriteLine("Which cards in hand do you want to discard? enter q when done.");
            StreamReader sr = StreamReader.Null;
            sr.Read();
            ConsoleKeyInfo info = Console.ReadKey();

            while (info.Key != ConsoleKey.Q || info.Key != ConsoleKey.Enter)
            {
                if ((info.Key == ConsoleKey.D1 || info.Key == ConsoleKey.NumPad1) && !whichCards[0])
                {
                    whichCards[0] = true;
                    Console.WriteLine($"Going to discard the {_hand[0]}");
                }
                else if ((info.Key == ConsoleKey.D1 || info.Key == ConsoleKey.NumPad1) && whichCards[0])
                {
                    whichCards[0] = false;
                    Console.WriteLine($"Nevermind then, going to hold onto the {_hand[0]}");
                }

                if ((info.Key == ConsoleKey.D2 || info.Key == ConsoleKey.NumPad2) && !whichCards[1])
                {
                    whichCards[1] = true;
                    Console.WriteLine($"Going to discard the {_hand[1]}");
                }
                else if ((info.Key == ConsoleKey.D2 || info.Key == ConsoleKey.NumPad2) && whichCards[1])
                {
                    whichCards[1] = false;
                    Console.WriteLine($"Nevermind then, going to hold onto the {_hand[1]}");
                }

                if ((info.Key == ConsoleKey.D3 || info.Key == ConsoleKey.NumPad3) && !whichCards[2])
                {
                    whichCards[2] = true;
                    Console.WriteLine($"Going to discard the {_hand[2]}");
                }
                else if ((info.Key == ConsoleKey.D3 || info.Key == ConsoleKey.NumPad3) && whichCards[2])
                {
                    whichCards[2] = false;
                    Console.WriteLine($"Nevermind then, going to hold onto the {_hand[2]}");
                }

                if ((info.Key == ConsoleKey.D4 || info.Key == ConsoleKey.NumPad4) && !whichCards[3])
                {
                    whichCards[3] = true;
                    Console.WriteLine($"Going to discard the {_hand[3]}");
                }
                else if ((info.Key == ConsoleKey.D4 || info.Key == ConsoleKey.NumPad4) && whichCards[3])
                {
                    whichCards[3] = false;
                    Console.WriteLine($"Nevermind then, going to hold onto the {_hand[3]}");
                }

                if ((info.Key == ConsoleKey.D5 || info.Key == ConsoleKey.NumPad5) && !whichCards[4])
                {
                    whichCards[4] = true;
                    Console.WriteLine($"Going to discard the {_hand[4]}");
                }
                else if ((info.Key == ConsoleKey.D5 || info.Key == ConsoleKey.NumPad5) && whichCards[4])
                {
                    whichCards[4] = false;
                    Console.WriteLine($"Nevermind then, going to hold onto the {_hand[4]}");
                }

                info = Console.ReadKey();
            }

            return whichCards;
        }
    }
}
