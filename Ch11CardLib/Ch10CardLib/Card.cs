using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    public class Card : ICloneable
    {
        public readonly Suit suit;
        public readonly Rank rank;
        public object Clone() => MemberwiseClone();
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }
        private Card()
        {

        }
        public override string ToString()
        {
            return $"The {rank} of {suit}s";
        }
        /// <summary>
        /// Flag for trump usage. If true, trumps are value higher
        /// than cards of other suids
        /// </summary>
        public static bool useTrumps = false;
        /// <summary>
        /// Trump suit to use if useTrumps is true.
        /// </summary>
        public static Suit trump = Suit.Club;
        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces
        /// </summary>
        public static bool isAceHigh = true;

        //public static bool operator == (Card card1, Card card2)
        //{
        //    return (card1?.suit == card2?.suit) && (card1?.rank == card2?.rank);
        //}
        //public static bool operator != (Card card1, Card card2)
        //    => !(card1 == card2);
        //public override bool Equals(object card) => this == (Card)card;
        //public override int GetHashCode()
        //    => return 13 * (int)suit + (int)rank;

        
    }
}
