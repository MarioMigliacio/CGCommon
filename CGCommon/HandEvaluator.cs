using CGCommon;

namespace RandomCSStuff
{
    /// <summary>
    /// HandEvaluator is a static class, which gives access to the functions which return the 
    /// value of the player's hand. In the event of a Tie, the player's high card will be looked 
    /// at after getting the _value of the hand.
    /// </summary>
    public static class HandEvaluator
    {
        /// <summary>
        /// Value is tracked through each of the CheckFor____ functions. It is used to check
        /// which player has the higher valued poker hand. In the event of a tie, it will come
        /// down to the High card.
        /// </summary>
        private static int _value = 0;

        /// <summary>
        /// Value property exposes _value to the outside world to evaluate the player hand.
        /// </summary>
        public static int Value { get { return _value; } }

        /// <summary>
        /// EvaluateHand uses all the private helper functions CheckFor___ to determine what the 
        /// player has. We want a stringly formatted version of the hand for later. We need to 
        /// check the highest possible hands in descending order, otherwise the function might 
        /// return that the player has a pair, when actually they could have had a 3 of a kind. etc.
        /// </summary>
        /// <param name="hand">The players Hand being evaluated.</param>
        /// <returns>A stringly formatted version of the players hand after evaluation.</returns>
        public static string EvaluateHand(Hand hand)
        {
            Card[] handToEval = hand.GetHand();

            if (CheckForRoyalFlush(hand))
            {
                return "Royal Flush";
            }

            else if (CheckForStraightFlush(hand))
            {
                return "Straight Flush";
            }

            else if (CheckForFourKind(hand))
            {
                return "Four Of A Kind";
            }

            else if (CheckForFlush(hand))
            {
                return "Flush";
            }

            else if (CheckForStraight(hand))
            {
                return "Straight";
            }

            else if (CheckForThreeKind(hand))
            {
                return "Three Of A Kind";
            }

            else if (CheckForTwoPair(hand))
            {
                return "Two Pair";
            }

            else if (CheckForPair(hand))
            {
                return "Pair";
            }

            else return $"High Card: {handToEval[4]}";
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has a pair in their hand.
        /// Since the hand is sorted, we just check neighboring indexes to see if Rank is the same on any cards.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has a pair in their hand. _value = 1 if true.</returns>
        private static bool CheckForPair(Hand hand)
        {
            Card[] handToEval = hand.GetHand();
            bool check = false;

            for (int i = 0; i < 4; i++)
            {
                if (handToEval[i].Rank == handToEval[i + 1].Rank)
                {
                    _value = 1;
                    check = true;
                    break;
                }
            }

            return check;
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has two pairs in their hand.
        /// Since the hand is sorted, we know that 2 pairs of cards must exist in a very particular way which minimizes 
        /// the number of checks required.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has 2 pairs in their hand. _value = 2 if true.</returns>
        private static bool CheckForTwoPair(Hand hand)
        {
            Card[] handToEval = hand.GetHand();
            bool check = false;

            if (handToEval[0].Rank == handToEval[1].Rank
                && handToEval[2].Rank == handToEval[3].Rank)
            {
                _value = 2;
                check = true;
            }

            else if (handToEval[0].Rank == handToEval[1].Rank
                     && handToEval[3].Rank == handToEval[4].Rank)
            {
                _value = 2;
                check = true;
            }

            else if (handToEval[1].Rank == handToEval[2].Rank
                     && handToEval[3].Rank == handToEval[4].Rank)
            {
                _value = 2;
                check = true;
            }

            return check;
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has three of a kind in their hand.
        /// Since the hand is sorted, we only need look at neighboring indexes and the following after that, if the rank is 
        /// the same on each the player has three of a kind.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has 3 of a kind in their hand. _value = 3 if true.</returns>
        private static bool CheckForThreeKind(Hand hand)
        {
            Card[] handToEval = hand.GetHand();
            bool check = false;

            for (int i = 0; i < 3; i++)
            {
                if (handToEval[i].Rank == handToEval[i + 1].Rank
                    && handToEval[i + 1].Rank == handToEval[i + 2].Rank)
                {
                    _value = 3;
                    check = true;
                    break;
                }
            }

            return check;
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has a straight in their hand.
        /// Since the hand is sorted, we simply have to check if each index of cards is one greater then the previous.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has a straight in their hand. _value = 4 if true.</returns>
        private static bool CheckForStraight(Hand hand)
        {
            Card[] handToEval = hand.GetHand();
            bool check = false;

            if (handToEval[4].Rank == handToEval[3].Rank + 1
                && handToEval[3].Rank == handToEval[2].Rank + 1
                && handToEval[2].Rank == handToEval[1].Rank + 1
                && handToEval[1].Rank == handToEval[0].Rank + 1)
            {
                _value = 4;
                check = true;
            }

            return check;
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has a flush in their hand.
        /// To have a flush, the player must have 5 of the same Suit present in their hand.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has a flush in their hand. _value = 5 if true.</returns>
        private static bool CheckForFlush(Hand hand)
        {
            Card[] handToEval = hand.GetHand();
            bool check = false;

            if (handToEval[4].Suit == handToEval[3].Suit
                && handToEval[3].Suit == handToEval[2].Suit
                && handToEval[2].Suit == handToEval[1].Suit
                && handToEval[1].Suit == handToEval[0].Suit)
            {
                _value = 5;
                check = true;
            }

            return check;
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has 4 of a kind in their hand.
        /// Since the hand is sorted, we can just check that if the 1st index equals the 4th index, or if the 2nd index 
        /// equals the 5th index. There is no other way the hand could be arranged after sorting.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has 4 of a kind in their hand. _value = 6 if true.</returns>
        private static bool CheckForFourKind(Hand hand)
        {
            Card[] handToEval = hand.GetHand();
            bool check = false;

            if (handToEval[0].Rank == handToEval[3].Rank
                || handToEval[1].Rank == handToEval[4].Rank)
            {
                _value = 6;
                check = true;
            }

            return check;
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has a straight flush in their hand.
        /// The logic to check for a straight flush is to simply use what is in place for the Straight, and Flush logic at the 
        /// same time.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has a straight flush in their hand. _value = 7 if true.</returns>
        private static bool CheckForStraightFlush(Hand hand)
        {
            if (CheckForStraight(hand) && CheckForFlush(hand))
            {
                _value = 7;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Internal helper method to return the boolean status of whether or not the player has a royal flush in their hand.
        /// First we need to ensure the player has a flush, after that we must check if the have a straight AND the straight
        /// starts at a 10 card. This is easy since the hand is sorted, just look to see hand[0] is 10, and both a straight 
        /// and flush are present.
        /// </summary>
        /// <param name="hand">The players hand being evaluated.</param>
        /// <returns>True or false if the player has a royal flush in their hand. _value = 8 if true.</returns>
        private static bool CheckForRoyalFlush(Hand hand)
        {
            Card[] handToEval = hand.GetHand();
            bool check = false;

            if (CheckForFlush(hand))
            {
                if (handToEval[0].Rank == 10 && CheckForStraight(hand))
                {
                    _value = 8;
                    check = true;
                }
            }

            return check;
        }
    }
}
