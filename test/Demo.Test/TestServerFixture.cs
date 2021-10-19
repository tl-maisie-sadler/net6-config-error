using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Demo.Test;

public class TestServerFixture : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder
            .ConfigureAppConfiguration((ctx, builder) =>
            {
                System.Console.WriteLine("configure test");
                var testDir = Path.GetDirectoryName(GetType().Assembly.Location);
                var configLocation = Path.Combine(testDir!, "testsettings.json");

                builder.Sources.Clear();
                builder.AddJsonFile(configLocation);
            });
    }
}
