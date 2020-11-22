using System.Net.Http;
using ComicApiGrpc.ComicsService;
using ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes;
using ComicApiGrpc.ComicsService.ComicSources.DilbertComics;
using ComicApiGrpc.ComicsService.ComicSources.GarfieldComics;
using ComicApiGrpc.ComicsService.ComicSources.XKCD;
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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddHttpClient<IXKCD, XKCD>();
            services.AddSingleton<IXKCD, XKCD>(p =>
            {
                HttpClient httpClient = p.GetRequiredService<IHttpClientFactory>()
                    .CreateClient(nameof(IXKCD));

                return new XKCD(httpClient, true);
            });
            services.AddSingleton<IXkcdComic, XkcdComic>();
            services.AddSingleton<IGarfieldComics, GarfieldComics>();
            services.AddSingleton<IDilbertComics, DilbertComics>();
            services.AddSingleton<ICalvinAndHobbesComics, CalvinAndHobbesComics>();
            services.AddSingleton<IComicUrlService, ComicUrlService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
