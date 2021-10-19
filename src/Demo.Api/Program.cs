using Microsoft.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        return WebHost.CreateDefaultBuilder(args)
            .ConfigureServices((ctx, services) =>
            {
                services.AddSingleton<Options>(new Options(ctx.Configuration["AppSettings:Options"]));
            })
            .Configure(appBuilder =>
            {
                appBuilder.UseRouting();
                appBuilder.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/", (Options options) => options.Value);

                    endpoints.MapGet("/svc", (IConfiguration configuration) => configuration["AppSettings:Options"]);
                });
            });
    }
}

record Options(string Value);
