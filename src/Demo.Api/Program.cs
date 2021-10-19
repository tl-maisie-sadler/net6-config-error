var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new Options(builder.Configuration["AppSettings:Options"]));

var app = builder.Build();

app.MapGet("/", (Options options) => options.Value);

app.MapGet("/svc", (IConfiguration configuration) => configuration["AppSettings:Options"]);

app.Run();

public partial class Program
{
    // Expose the Program class for use with WebApplicationFactory<T>
}

record Options(string Value);
