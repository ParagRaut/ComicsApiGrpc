using System.Net.Http;
using ComicApiGrpc.ComicsService;
using ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes;
using ComicApiGrpc.ComicsService.ComicSources.Dilbert;
using ComicApiGrpc.ComicsService.ComicSources.Garfield;
using ComicApiGrpc.ComicsService.ComicSources.Xkcd;
using ComicApiGrpc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComicApiGrpc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddHttpClient<IXKCD, XKCD>();
            services.AddTransient<IXKCD, XKCD>(p =>
            {
                HttpClient httpClient = p.GetRequiredService<IHttpClientFactory>()
                    .CreateClient(nameof(IXKCD));

                return new XKCD(httpClient, true);
            });
            services.AddTransient<IXkcdComic, XkcdComic>();
            services.AddTransient<IGarfield, Garfield>();
            services.AddTransient<IDilbert, Dilbert>();
            services.AddTransient<ICalvinAndHobbes, CalvinAndHobbes>();
            services.AddTransient<IComicUrlService, ComicUrlService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ComicService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. Try using bloom rpc to test it https://appimage.github.io/BloomRPC/");
                });
            });
        }
    }
}
