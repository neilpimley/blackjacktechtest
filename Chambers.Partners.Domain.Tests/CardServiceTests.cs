using Chambers.Partners.Domain.Enums;
using Chambers.Partners.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Chambers.Partners.Domain.Tests
{
    [TestClass]
    public class CardServiceTest
    {
        private ICardService _service;
        private List<Card> _deck;
        private static readonly int _expectedNumberOfTotalCards = 52;
        private static readonly int _expectedNumberOfCardsPerSuit = 13;
        private static readonly int _expectedNumberOfCardsPerValue = 4;

        [TestInitialize]
        public void Setup()
        {
            _service = new CardService();
            _deck = _service.GetDeck().ToList();
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfCards()
        {
            Assert.AreEqual(_expectedNumberOfTotalCards, _deck.Count());
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfHearts()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerSuit, _deck.Count(c => c.Suit == CardSuit.Heart));
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfDiamonds()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerSuit, _deck.Count(c => c.Suit == CardSuit.Diamond));
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfSpades()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerSuit, _deck.Count(c => c.Suit == CardSuit.Spade));
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfClubs()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerSuit, _deck.Count(c => c.Suit == CardSuit.Club));
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfAces()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerValue, _deck.Count(c => c.Value.ToString() == CardValue.Ace.ToString()));
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfJacks()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerValue, _deck.Count(c => c.Value.ToString() == CardValue.Jack.ToString()));
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfQueen()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerValue, _deck.Count(c => c.Value.ToString() == CardValue.Queen.ToString()));
        }

        [TestMethod]
        public void GivenIRequestADeckOfCards_ThenIReciveAFullDeckOfCardsWithTheCorrectNumberOfKingss()
        {
            Assert.AreEqual(_expectedNumberOfCardsPerValue, _deck.Count(c => c.Value.ToString() == CardValue.King.ToString()));
        }
    }
}
