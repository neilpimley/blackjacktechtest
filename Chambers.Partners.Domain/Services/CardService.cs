using Chambers.Partners.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chambers.Partners.Domain.Services
{
    public class CardService : ICardService
    {
        public IList<Card> GetDeck()
        {
            var deck = new List<Card>();
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            var faceValues = Enum.GetValues(typeof(CardValue)).Cast<CardValue>();
            foreach (var suit in suits)
            {
                foreach (var faceValue in faceValues)
                {
                    deck.Add(new Card(suit, faceValue));
                }
            }
            return deck;
        }

    }
}
