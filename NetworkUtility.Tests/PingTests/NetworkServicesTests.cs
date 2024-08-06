using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServicesTests
    {
        private readonly NetworkService _pingService;

        public NetworkServicesTests() => _pingService = new NetworkService();

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            var result = _pingService.SendPing();

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnsInt(int a, int b, int expected)
        {
            var result = _pingService.PingTimeout(a, b);

            result.Should().Be(expected);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnsDate()
        {
            var result = _pingService.LastPingDate();
            var dateToday = DateTime.Today;

            result.Should().BeSameDateAs(5.August(2024));
            result.Should().BeSameDateAs(dateToday);
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsPingOptions()
        {
            //Arrange
            var expected = new PingOptions { DontFragment = true, Ttl = 1 };

            var result = _pingService.GetPingOptions();

            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(expected.Ttl);
        }

    }
}
