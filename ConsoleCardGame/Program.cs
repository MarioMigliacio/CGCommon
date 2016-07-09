using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCommon;

namespace ConsoleCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck52Standard();
            deck.PrintDeckContents();

            deck.ShuffleDeck();

            deck.PrintDeckContents();
        }
    }
}
