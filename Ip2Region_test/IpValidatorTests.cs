namespace Ip2Region_test
{
    using FluentAssertions;
    using NUnit.Framework;

    public class IpValidatorTests
    {
        [Test]
        public void isValidIpTest()
        {
            var ipValidator = new IP2Region.Features.IPValidator.IpValidatorService();
            ipValidator.IsValidIp("127.0.0.1").Should().BeFalse();
            ipValidator.IsValidIp("157.12.0.1").Should().BeTrue();
            ipValidator.IsValidIp("290.0.0.1").Should().BeFalse();
            ipValidator.IsValidIp("2001:16B8:2D67:FC00:21A8:94EF:43F4:8E33").Should().BeTrue();

        }
        [Test]
        public void IsPublicIpTest()
        {
            var ipValidator = new IP2Region.Features.IPValidator.IpValidatorService();
            ipValidator.IsPublicIp("120.0.0.1").Should().BeTrue();
            ipValidator.IsPublicIp("10.0.0.1").Should().BeFalse();
        }
    }
}