using Chambers.Partners.Domain.Enums;
using Chambers.Partners.Domain.Services;
using Chambers.Partners.Domain.TestFixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chambers.Partners.Domain.Tests
{
    [TestClass]
    public class BlackJackGameTests
    {
        private ICardService _cardService;
        private static Player _player2;

        [TestInitialize]
        public void Setup()
        {
            _cardService = new CardService();
            _player2 = PlayerFixture.InMemory.WithIdentity(2).Create();
        }

        [TestMethod]
        public void GivenIHaveABlackJackGame_WhenIStartAGameAsTheCorrectPLayer_ThePlayerHasTwoCardsAndTheDealerHasNone()
        {
            var game = BlackJackGameFixture.InMemory
                .WithDeck(_cardService.GetDeck().ToList()).Create();

            game.DealCardToPlayer(2);

            Assert.AreEqual(50, game.Deck.Count);
            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(0, game.DealerHand.Count);

        }


        [TestMethod]
        public void GivenIHaveABlackJackGame_WhenIDealACardToThePlayer_ThenThePlayerIsDealtACardFromTheDeck()
        {
            var game = BlackJackGameFixture.InMemory
                .WithDeck(_cardService.GetDeck().ToList()).Create();

            var noOfCardsInDeck = game.Deck.Count;
            var noOfCardsInHand = game.PlayerHand.Count;

            game.DealCardToPlayer(1);

            Assert.AreEqual(noOfCardsInDeck - 1, game.Deck.Count);
            Assert.AreEqual(noOfCardsInHand + 1, game.PlayerHand.Count);

        }

        [TestMethod]
        public void GivenIHaveABlackJackGame_WhenIStartAGameAndThePlayerIsDealtATwoAndAThree_ThePlayerHasTwoCardsWithAValueOfFive()
        {
            var deck = new List<Card>
            {
                new Card(CardSuit.Heart, CardValue.Two),
                new Card(CardSuit.Heart, CardValue.Three),

            };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(5, game.PlayerScore);
        }


        [TestMethod]
        public void GivenIHaveABlackJackGame_WhenIStartAGameAndThePlayerIsDealtATwoThreeAndFour_ThePlayerHasThreeCardsWithAValueOfNine()
        {
            var deck = new List<Card>
            {
                new Card(CardSuit.Heart, CardValue.Two),
                new Card(CardSuit.Heart, CardValue.Three),
                new Card(CardSuit.Heart, CardValue.Four),

            };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(3);

            Assert.AreEqual(3, game.PlayerHand.Count);
            Assert.AreEqual(9, game.PlayerScore);
        }

        [TestMethod]
        public void GivenIHaveABlackJackGame_WhenIStartAGameAndThePlayerIsDealtATwoKingsAndATwo_ThenThePlayerIsBustAndTheDealerIsTheWinner()
        {
            var deck = new List<Card>
            {
                new Card(CardSuit.Heart, CardValue.King),
                new Card(CardSuit.Spade, CardValue.King),
                new Card(CardSuit.Heart, CardValue.Two),

            };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(3);

            Assert.AreEqual(3, game.PlayerHand.Count);
            Assert.AreEqual(22, game.PlayerScore);
            Assert.AreEqual(game.Dealer.Name, game.Winner());
        }

        [TestMethod]
        public void GivenIHaveABlackJackGame_WhenIStartAGameAndThePlayerIsDealtATwoAces_ThenThePlayerHasAScoreOfTwelve()
        {
            var deck = new List<Card>
            {
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Ace),
            };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(12, game.PlayerScore);
        }


        [TestMethod]
        public void GivenIHaveABlackJackCardGame_IfThePlayerSticksOnTen_AndTheDealerHasSeveteen_ThenTheDealerWins()
        {
            var deck = new List<Card>
            {
                new Card(CardSuit.Heart, CardValue.Five),
                new Card(CardSuit.Spade, CardValue.Five),
                new Card(CardSuit.Spade, CardValue.Ten),
                new Card(CardSuit.Spade, CardValue.Seven),
            };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);
            game.Stick();

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(10, game.PlayerScore);
            Assert.AreEqual(17, game.DealerScore);
            Assert.AreEqual(game.Dealer.Name, game.Winner());
        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_IfThePlayerSticksOnNineteen_AndTheDealerHasSeveteen_ThenTheDealerWins()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Nine),
                    new Card(CardSuit.Spade, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Seven),
                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);
            game.Stick();

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(19, game.PlayerScore);
            Assert.AreEqual(17, game.DealerScore);
            Assert.AreEqual(game.Player.Name, game.Winner());
        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_IfThePlayerSticksOnSixteen_AndTheDealerTakesACardUntilTheyReachSeveteen_ThenTheDealerWins()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Six),
                    new Card(CardSuit.Spade, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Two),
                    new Card(CardSuit.Heart, CardValue.Two),
                    new Card(CardSuit.Club, CardValue.Two),
                    new Card(CardSuit.Diamond, CardValue.Two),
                    new Card(CardSuit.Diamond, CardValue.King),
                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);
            game.Stick();

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(5, game.DealerHand.Count);
            Assert.AreEqual(16, game.PlayerScore);
            Assert.AreEqual(18, game.DealerScore);
            Assert.AreEqual(game.Dealer.Name, game.Winner());
        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_IfThePlayerSticksOnTwenty_AndTheDealerTakesACardUntilTheyReachSeveteen_ThenTheDealerWins()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Two),
                    new Card(CardSuit.Heart, CardValue.Two),
                    new Card(CardSuit.Club, CardValue.Two),
                    new Card(CardSuit.Diamond, CardValue.Two),
                    new Card(CardSuit.Diamond, CardValue.King),
                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);
            game.Stick();

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(5, game.DealerHand.Count);
            Assert.AreEqual(20, game.PlayerScore);
            Assert.AreEqual(18, game.DealerScore);
            Assert.AreEqual(game.Player.Name, game.Winner());
        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_IfThePlayerHasAnAceAndAKing_ThenTheirScoreIsTwentyOne()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.Ace),
                    new Card(CardSuit.Heart, CardValue.King),
                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(21, game.PlayerScore);
        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_IfThePlayerHasTwoAcesAndAKing_ThenTheirScoreIsTwelve()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.Ace),
                    new Card(CardSuit.Spade, CardValue.Ace),
                    new Card(CardSuit.Heart, CardValue.King),
                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(3);

            Assert.AreEqual(3, game.PlayerHand.Count);
            Assert.AreEqual(12, game.PlayerScore);
        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_AndIStickWithTwoCards_WhenIAskForAnotherCard_ThenIGetAnException()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.Two),
                    new Card(CardSuit.Heart, CardValue.Three),
                    new Card(CardSuit.Heart, CardValue.Four),
                    new Card(CardSuit.Heart, CardValue.Five),
                    new Card(CardSuit.Heart, CardValue.Six),
                    new Card(CardSuit.Heart, CardValue.Seven),
                    new Card(CardSuit.Heart, CardValue.Eight),
                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);
            game.Stick();

            Assert.ThrowsException<InvalidOperationException>(
                () => game.DealCardToPlayer(1)
            );

        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_AndIRequestACardWhenMyScoreIsTwentyTwo_ThenIGetAnException()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.King),
                    new Card(CardSuit.Heart, CardValue.Jack),
                    new Card(CardSuit.Heart, CardValue.Two),
                    new Card(CardSuit.Heart, CardValue.Three),
                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(3);

            Assert.ThrowsException<InvalidOperationException>(
                () => game.DealCardToPlayer(1)
            );

        }

        [TestMethod]
        public void GivenIHaveABlackJackCardGame_IfThePlayerHasAHandOfEighteen_AndTheDealerHasAHandOfEighteen_AndThePLayerStick_ThenTheTheGameIsADraw()
        {
            var deck = new List<Card>
                {
                    new Card(CardSuit.Heart, CardValue.Ten),
                    new Card(CardSuit.Heart, CardValue.Eight),
                    new Card(CardSuit.Spade, CardValue.Ten),
                    new Card(CardSuit.Spade, CardValue.Eight),

                };
            var game = BlackJackGameFixture.InMemory.WithDeck(deck).Create();

            game.DealCardToPlayer(2);
            game.Stick();

            Assert.AreEqual(2, game.PlayerHand.Count);
            Assert.AreEqual(2, game.DealerHand.Count);
            Assert.AreEqual(18, game.PlayerScore);
            Assert.AreEqual(18, game.DealerScore);
            Assert.AreEqual("Draw", game.Winner());
        }

    }

}

