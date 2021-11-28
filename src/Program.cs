using ComicApiGrpc.ComicsService.CalvinAndHobbes;
using ComicApiGrpc.ComicsService.Dilbert;
using ComicApiGrpc.ComicsService.Garfield;
using ComicApiGrpc.ComicsService.XKCD;
using ComicApiGrpc.ComicsService.XKCD.Generated;
using ComicApiGrpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddHttpClient<CalvinAndHobbesService>(client => client.BaseAddress = new Uri("https://www.gocomics.com/random/"));

builder.Services.AddHttpClient<DilbertService>(client => client.BaseAddress = new Uri("https://dilbert.com/strip/"));

builder.Services.AddHttpClient<GarfieldService>(client => client.BaseAddress = new Uri("https://www.gocomics.com/garfield/"));

builder.Services.AddScoped<IXKCD, XKCD>(p => new XKCD(new HttpClient(), true));

builder.Services.AddScoped<XKCDService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ComicService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
