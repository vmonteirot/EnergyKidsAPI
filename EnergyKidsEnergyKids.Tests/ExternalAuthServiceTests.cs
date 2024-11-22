
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Protected;
using EnergyKidsEnergyKids.Services;

namespace EnergyKidsEnergyKids.Tests
{
    public class ExternalAuthServiceTests
    {
        [Fact]
        public async Task AuthenticateUserAsync_ReturnsToken_OnSuccess()
        {
            // Arrange
            var token = "sample-token";
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                       .Setup<Task<HttpResponseMessage>>(
                           "SendAsync",
                           ItExpr.IsAny<HttpRequestMessage>(),
                           ItExpr.IsAny<System.Threading.CancellationToken>()
                       )
                       .ReturnsAsync(new HttpResponseMessage
                       {
                           StatusCode = System.Net.HttpStatusCode.OK,
                           Content = new StringContent("authenticated")
                       });

            var httpClient = new HttpClient(handlerMock.Object);
            var authService = new ExternalAuthService(httpClient);

            // Act
            var result = await authService.AuthenticateUserAsync(token);

            // Assert
            Assert.Equal("authenticated", result);
        }

        [Fact]
        public async Task AuthenticateUserAsync_ThrowsException_OnFailure()
        {
            // Arrange
            var token = "sample-token";
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                       .Setup<Task<HttpResponseMessage>>(
                           "SendAsync",
                           ItExpr.IsAny<HttpRequestMessage>(),
                           ItExpr.IsAny<System.Threading.CancellationToken>()
                       )
                       .ReturnsAsync(new HttpResponseMessage
                       {
                           StatusCode = System.Net.HttpStatusCode.Unauthorized,
                       });

            var httpClient = new HttpClient(handlerMock.Object);
            var authService = new ExternalAuthService(httpClient);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => authService.AuthenticateUserAsync(token));
        }
    }
}
