using System;
using Chambers.Partners.Domain.Enums;
using Chambers.Partners.Domain.Services;
using Chambers.Partners.WebApi.Controllers;
using Chambers.Partners.WebApi.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chambers.Partners.Domain.ExtensionMethods;
using Chambers.Partners.WebApi.Models;
using Card = Chambers.Partners.Domain.Card;
using Chambers.Partners.Domain.TestFixtures;
using Microsoft.AspNetCore.Mvc;

namespace Chambers.Partners.WebApi.Tests
{
    [TestClass]
    public class GamesControllerTests
    {
        private GamesController _controller;
        private IGameService _service;
        private ICardGameMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _service = Substitute.For<IGameService>();
            _mapper = new CardGameMapper();
            _controller = new GamesController(_service, _mapper);
        }

        [TestMethod]
        public async Task TestStartAsync()
        {
            // Arrange
            var card1 = new Card(CardSuit.Club, CardValue.Two);
            var card2 = new Card(CardSuit.Club, CardValue.Two);
            var cards = new List<Card> {card1, card2 };
            var domainGame = BlackJackGameFixture.InMemory.WithDeck(cards).Create();
            domainGame.DealCardToPlayer(2);

            var expectedCards = new List<Card> { card1, card2 };

            // Act
            _service.StartBlackJack(Arg.Any<int>()).Returns(Task.FromResult(domainGame));

            var response = await _controller.StartAsync(new PlayRequest { PlayerId = 1 });

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            var result = response as OkObjectResult;
            Assert.IsNotNull(result);
            var game = result.Value as CardGame;
            Assert.IsNotNull(game);

            Assert.AreEqual(expectedCards.First().Suit.ToString(), game.Cards.First().Suit);
            Assert.AreEqual(expectedCards.First().Value.GetDescription(), game.Cards.First().Value);
            Assert.AreEqual(expectedCards.Last().Suit.ToString(), game.Cards.Last().Suit);
            Assert.AreEqual(expectedCards.Last().Value.GetDescription(), game.Cards.Last().Value);
        }

        [TestMethod]
        public async Task TestStickAsync()
        {
            // Arrange
            var playerCard1 = new Card(CardSuit.Club, CardValue.Ace);
            var playerCard2 = new Card(CardSuit.Club, CardValue.King);
            var dealerard1 = new Card(CardSuit.Heart, CardValue.King);
            var dealerCard2 = new Card(CardSuit.Spade, CardValue.King);

            var expectedCards = new List<Card> { playerCard1, playerCard2, dealerard1, dealerCard2 };
            var expectedWinner = "Mr Winner 1";

            var cards = new List<Card> { playerCard1, playerCard2, dealerard1, dealerCard2 };
            var domainGame = BlackJackGameFixture.InMemory
                .WithPlayer(PlayerFixture.InMemory.WithName(expectedWinner).Create())
                .WithDeck(cards).Create();
            domainGame.DealCardToPlayer(2);
            domainGame.Stick();

            _service.Stick(Arg.Any<int>(), Arg.Any<int>()).Returns(domainGame);

            // Act
            var response = await _controller.StickAsync(1, new PlayRequest { PlayerId = 1 });

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            var result = response as OkObjectResult;
            Assert.IsNotNull(result);
            var game = result.Value as CardGame;
            Assert.IsNotNull(game);

            Assert.AreEqual(expectedCards.First().Suit.ToString(), game.Cards.First().Suit);
            Assert.AreEqual(expectedCards.First().Value.GetDescription(), game.Cards.First().Value);
            Assert.AreEqual(expectedCards.ElementAt(1).Suit.ToString(), game.Cards.Last().Suit);
            Assert.AreEqual(expectedCards.ElementAt(1).Value.GetDescription(), game.Cards.Last().Value);
            Assert.AreEqual(expectedWinner, game.Winner);
        }

        [TestMethod]
        public async Task TestHitAsync()
        {
            // Arrange
            var gameId = 1;
            var playerId = 1;
            var card1 = new Card(CardSuit.Club, CardValue.Two);
            var card2 = new Card(CardSuit.Club, CardValue.Two);
            var cards = new List<Card> { card1, card2 };
            var domainGame = BlackJackGameFixture.InMemory
                .WithIdentity(gameId)
                .WithPlayer(PlayerFixture.InMemory.WithIdentity(1).Create())
                .WithDeck(cards).Create();
            domainGame.DealCardToPlayer(2);

            var expectedCards = new List<Card> { card1, card2 };

            _service.Hit(gameId, playerId).Returns(domainGame);

            // Act
            var response = await _controller.HitAsync(gameId, new PlayRequest { PlayerId = 1 });

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            var result = response as OkObjectResult;
            Assert.IsNotNull(result);
            var game = result.Value as CardGame;
            Assert.IsNotNull(game);

            Assert.AreEqual(expectedCards.First().Suit.ToString(), game.Cards.First().Suit);
            Assert.AreEqual(expectedCards.First().Value.GetDescription(), game.Cards.First().Value);
            Assert.AreEqual(expectedCards.Last().Suit.ToString(), game.Cards.Last().Suit);
            Assert.AreEqual(expectedCards.Last().Value.GetDescription(), game.Cards.Last().Value);

        }
    }
}