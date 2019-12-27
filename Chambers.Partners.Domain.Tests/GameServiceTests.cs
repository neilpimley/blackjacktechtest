using Chambers.Partners.Domain.Factories;
using Chambers.Partners.Domain.Providers;
using Chambers.Partners.Domain.Services;
using Chambers.Partners.Domain.TestFixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Tests
{
    [TestClass]
    public class GameServiceTests 
    {
        private ICardGameProvider _provider;
        private IGameService _service;
        private IGameFactory _factory;
        private List<Card> _deck;

        [TestInitialize]
        public void Setup()
        {
            _provider = Substitute.For<ICardGameProvider>();
            _factory = Substitute.For<IGameFactory>();

            _service = new GameService(_factory, _provider);
        }

        [TestMethod]
        public async Task TestGetNextGameId()
        {
            var identity = 1;
            _provider.GetNextGameIdentityAsync().Returns(identity);

            Assert.AreEqual(identity, await _service.GetNextGameId());
        }

        [TestMethod]
        public async Task TestStartBlackJack()
        {
            var game = BlackJackGameFixture.InMemory.Create();
            _factory.CreateBlackJackGame(game.Identity).Returns(game);
            
            await _service.StartBlackJack(game.Identity);

            await _provider.Received().InsertOrUpdateAsync(game);
        }

        [TestMethod]
        public async Task TestHit()
        {
            var game = BlackJackGameFixture.InMemory.Create();
            _provider.GetAsync(game.Identity).Returns(game);

            await _service.Hit(game.Identity, game.Player.Identity);

            await _provider.Received().InsertOrUpdateAsync(game);
        }

        [TestMethod]
        public async Task TestHitWithWrongUser()
        {
            var game = BlackJackGameFixture.InMemory.Create();
            _provider.GetAsync(game.Identity).Returns(game);

            try
            {
                await _service.Hit(game.Identity, 999);
                Assert.Fail("An exception should have been thrown");
            }
            catch (UnauthorizedAccessException ae)
            {
                Assert.AreEqual("The player is not valid for this game", ae.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }
        }

        [TestMethod]
        public async Task TestStick()
        {
            var game = BlackJackGameFixture.InMemory.Create();
            _provider.GetAsync(game.Identity).Returns(game);

            await _service.Stick(game.Identity, game.Player.Identity);

            await _provider.Received().InsertOrUpdateAsync(game);
        }

        [TestMethod]
        public async Task TestStickWithWrongUser()
        {
            var game = BlackJackGameFixture.InMemory.Create();
            _provider.GetAsync(game.Identity).Returns(game);

            try
            {
                await _service.Stick(game.Identity, 999);
                Assert.Fail("An exception should have been thrown");
            }
            catch (UnauthorizedAccessException ae)
            {
                Assert.AreEqual("The player is not valid for this game", ae.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }
        }
        
    }
}
