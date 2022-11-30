using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Test;

public class UnitTest1
{
    [Fact]
    public async Task TestConfigDuringStartup()
    {
        var fixture = new TestServerFixture();
        var client = fixture.CreateClient();

        var response = await client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("test-value", content);
    }

    [Fact]
    public async Task TestServiceConfig()
    {
        var fixture = new TestServerFixture();
        var client = fixture.CreateClient();

        var response = await client.GetAsync("/svc");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("test-value", content);
    }

    [Fact]
    public async Task TestOverrideConfigDuringStartup()
    {
        var fixture = new TestServerFixture();
        fixture.OverrideConfiguration.Add("AppSettings:Options", "custom-value");
        var client = fixture.CreateClient();

        var response = await client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("custom-value", content);
    }

     [Fact]
    public async Task TestOverrideServiceConfig()
    {
        var fixture = new TestServerFixture();
        fixture.OverrideConfiguration.Add("AppSettings:Options", "custom-value");
        var client = fixture.CreateClient();

        var response = await client.GetAsync("/svc");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("custom-value", content);
    }
}
