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
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Three),
            };

            _service.StartBlackJack(Arg.Any<int>()).Returns(cards);

            var hand = await _controller.StartAsync(1);

            Assert.AreEqual(cards.First().Suit, hand.First().Suit);
            Assert.AreEqual(cards.First().Value, hand.First().Value);
            Assert.AreEqual(cards.Last().Suit, hand.Last().Suit);
            Assert.AreEqual(cards.Last().Value, hand.Last().Value);
        }

        [TestMethod]
        public async Task TestStickAsync()
        {
            var expectedWinner = "player";
            _service.Stick(Arg.Any<int>(), Arg.Any<int>()).Returns(expectedWinner);

            var winner = await _controller.StickAsync(1,1);
            Assert.AreEqual(expectedWinner, winner);
        }

        [TestMethod]
        public async Task TestHitAsync()
        {
            await _controller.HitAsync(1,1);
        }
    }
}
