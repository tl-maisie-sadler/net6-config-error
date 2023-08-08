using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Demo.Test;

public class TestServerFixture : WebApplicationFactory<Program>
{
    internal Dictionary<string, string> OverrideConfiguration = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        foreach (var setting in OverrideConfiguration)
        {
            builder.UseSetting(setting.Key, setting.Value);
        }

        base.ConfigureWebHost(builder);

        builder
            .ConfigureAppConfiguration((ctx, builder) =>
            {
                var testDir = Path.GetDirectoryName(GetType().Assembly.Location);
                var configLocation = Path.Combine(testDir!, "testsettings.json");

                builder.Sources.Clear();
                builder.AddJsonFile(configLocation);
            });
    }
}
