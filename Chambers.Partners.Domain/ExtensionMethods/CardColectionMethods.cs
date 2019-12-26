using Chambers.Partners.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chambers.Partners.Domain.ExtensionMethods
{
    public static class CardColectionMethods
    {
        private static Random rng = new Random();

        public static int CardsScore(this IList<Card> hand)
        {
            if (hand.Any(c => c.Value == CardValue.Ace) 
                && hand.Sum(c => Math.Min((int)c.Value, 10)) <= 11)
            {
                return hand.Sum(c => Math.Min((int)c.Value,10)) + 10;
            } 
            return hand.Sum(c => Math.Min((int)c.Value,10));
        }
        

        public static void ShuffleCards<Card>(this IList<Card> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
