using Chambers.Partners.Domain;
using Chambers.Partners.Domain.Enums;
using Chambers.Partners.Domain.Services;
using Chambers.Partners.WebApi.Controllers;
using Chambers.Partners.WebApi.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chambers.Partners.WebApi.Tests
{
    [TestClass]
    public class GamesControllerTests
    {
        private GamesController _controller;
        private IGameService _service;
        private IPlayerHandMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _service = Substitute.For<IGameService>();
            _mapper = new PlayerHandMapper();
            _controller = new GamesController(_service, _mapper);
        }

        [TestMethod]
        public async Task TestStartAsync()
        {
            // Arrange
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Three),
            };

            // Act
            _service.StartBlackJack(Arg.Any<int>()).Returns(cards);

            var hand = await _controller.StartAsync(1);

            // Assert
            Assert.AreEqual(cards.First().Suit.ToString(), hand.First().Suit);
            Assert.AreEqual(((int)cards.First().Value).ToString(), hand.First().Value);
            Assert.AreEqual(cards.Last().Suit.ToString(), hand.Last().Suit);
            Assert.AreEqual(((int)cards.Last().Value).ToString(), hand.Last().Value);
        }

        [TestMethod]
        public async Task TestStickAsync()
        {
            // Arrange
            var expectedWinner = "player";

            _service.Stick(Arg.Any<int>(), Arg.Any<int>()).Returns(expectedWinner);

            // Act
            var winner = await _controller.StickAsync(1, 1);

            // Assert
            Assert.AreEqual(expectedWinner, winner);
        }

        [TestMethod]
        public async Task TestHitAsync()
        {
            // Arrange
            var gameId = 1;
            var playerId = 1;
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Three),
            };

            _service.Hit(gameId, playerId).Returns(cards);

            // Act
            var hand = await _controller.HitAsync(gameId, playerId);

            // Assert
            Assert.AreEqual(cards.First().Suit.ToString(), hand.First().Suit);
            Assert.AreEqual(((int)cards.First().Value).ToString(), hand.First().Value);
            Assert.AreEqual(cards.Last().Suit.ToString(), hand.Last().Suit);
            Assert.AreEqual(((int)cards.Last().Value).ToString(), hand.Last().Value);

        }
    }
}