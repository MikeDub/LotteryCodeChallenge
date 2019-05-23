using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LotteryCodeChallenge.Dtos;
using LotteryCodeChallenge.Repositories;
using LotteryCodeChallenge.Services;
using LotteryCodeChallenge.UnitTests.Data;
using Moq;
using NUnit.Framework;

namespace LotteryCodeChallenge.UnitTests.Services
{
    [TestFixture(Author = "Michael Whitman")]
    class LottoDrawServiceTests
    {
        // Service under test
        private ILottoDrawService _lottoDrawService;

        // Mocks
        private Mock<IHttpClientFactory> _httpClientFactoryMock;
        private Mock<CurrentDrawRepository> _currentRepoMock;
        private Mock<OpenDrawsRepository> _openRepoMock;

        [SetUp]
        public void Setup()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _currentRepoMock = new Mock<CurrentDrawRepository>();
            _openRepoMock = new Mock<OpenDrawsRepository>();
        }

        #region Current Draws

        [Test(Author = "Michael Whitman", Description = "Tests the behaviour of getting current draws works as expected.")]
        public async Task GetCurrentDraws_WithValidRequest_ReturnsValidResponseWithoutErrors()
        {
            // Arrange
            var request = LottoDrawData.ValidDrawRequest;
            ConfigureCurrentRepository(LottoDrawData.ValidCurrentDrawsResponse, request);
            _lottoDrawService = new LottoDrawService(_openRepoMock.Object, _currentRepoMock.Object);

            // Act
            var currentDraws = await _lottoDrawService.GetCurrentDraws(request);

            // Assert
            Assert.That(currentDraws, Is.Not.Null.Or.Empty);
            var currentDrawsList = currentDraws.ToList();
            Assert.That(currentDrawsList.Count, Is.GreaterThan(0));
        }

        [Test(Author = "Michael Whitman", Description = "Tests the service appropriately validates a bad request and throws exception.")]
        public void GetCurrentDraws_WithNullOrEmptyDrawsReturned_ThrowsAppropriateError()
        {
            // Arrange
            var request = LottoDrawData.ValidDrawRequest;

            ConfigureCurrentRepository(LottoDrawData.NullCurrentDrawsResponse, request);
            _lottoDrawService = new LottoDrawService(_openRepoMock.Object, _currentRepoMock.Object);

            // Act
            // Assert
            Assert.Throws<InvalidDataException>(() => _lottoDrawService.GetCurrentDraws(request));
        }


        /// <summary>
        /// Sets up the current draw repository to return the required information for a specific test
        /// </summary>
        private void ConfigureCurrentRepository(CurrentDrawResponse currentDrawResponse, DrawRequest request = null)
        {
            Mock<CurrentDrawRepository> currentRepoMock = new Mock<CurrentDrawRepository>();
            currentRepoMock.Setup(x => x.PostAsync(request ?? It.IsAny<DrawRequest>()))
                .Returns(Task.FromResult(currentDrawResponse));

        }

        #endregion

        #region Open Draws

        [Test(Author = "Michael Whitman", Description = "Tests the behaviour of getting open draws works as expected.")]
        public async Task GetOpenDraws_WithValidRequest_ReturnsValidResponseWithoutErrors()
        {
            // Arrange
            var request = LottoDrawData.ValidDrawRequest;
            ConfigureOpenRepository(LottoDrawData.ValidOpenDrawsResponse, request);
            _lottoDrawService = new LottoDrawService(_openRepoMock.Object, _currentRepoMock.Object);

            // Act
            var openDraws = await _lottoDrawService.GetOpenDraws(request);

            // Assert
            Assert.That(openDraws, Is.Not.Null.Or.Empty);
            var openDrawsList = openDraws.ToList();
            Assert.That(openDrawsList.Count, Is.GreaterThan(0));
        }

        [Test(Author = "Michael Whitman", Description = "Tests the service appropriately validates a bad request and throws exception.")]
        public void GetOpenDraws_WithNullOrEmptyDrawsReturned_ThrowsAppropriateError()
        {
            // Arrange
            var request = LottoDrawData.ValidDrawRequest;
            ConfigureOpenRepository(LottoDrawData.NullOpenDrawsResponse, request);
            _lottoDrawService = new LottoDrawService(_openRepoMock.Object, _currentRepoMock.Object);

            // Act
            // Assert
            Assert.Throws<InvalidDataException>(() => _lottoDrawService.GetOpenDraws(request));
        }

        /// <summary>
        /// Sets up the open draws repository to return the required information for a specific test
        /// </summary>
        private void ConfigureOpenRepository(OpenDrawResponse openDrawResponse, DrawRequest request = null)
        {
            Mock<OpenDrawsRepository> openRepoMock = new Mock<OpenDrawsRepository>();
            openRepoMock.Setup(x => x.PostAsync(request ?? It.IsAny<DrawRequest>()))
                .Returns(Task.FromResult(openDrawResponse));

        }

        #endregion

    }
}
