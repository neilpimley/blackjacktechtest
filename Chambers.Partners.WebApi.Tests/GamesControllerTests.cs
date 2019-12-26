using Chambers.Partners.Domain.Services;
using Chambers.Partners.WebApi.Controllers;
using Chambers.Partners.WebApi.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

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
        public void TestMethod1()
        {
            _controller.Start();
        }
    }
}
