using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using ComicApiGrpc.ComicsService.ComicSources;
using ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes;
using ComicApiGrpc.ComicsService.ComicSources.Dilbert;
using ComicApiGrpc.ComicsService.ComicSources.Garfield;
using ComicApiGrpc.ComicsService.ComicSources.Xkcd;
using Microsoft.Extensions.Logging;

namespace ComicApiGrpc.ComicsService
{
    public class ComicUrlService : IComicUrlService
    {
        public ComicUrlService(
            [NotNull] IXkcdComic xkcd,
            [NotNull] IGarfield garfield,
            [NotNull] IDilbert dilbert,
            [NotNull] ICalvinAndHobbes calvinAndHobbes,
            ILogger<ComicUrlService> logger)
        {
            _xkcd = xkcd;
            _garfield = garfield;
            _dilbert = dilbert;
            _calvinAndHobbes = calvinAndHobbes;
            _logger = logger;
        }

        private readonly IXkcdComic _xkcd;
        private readonly IGarfield _garfield;
        private readonly IDilbert _dilbert;
        private readonly ICalvinAndHobbes _calvinAndHobbes;
        private readonly ILogger _logger;

        public Task<string> GetRandomComic()
        {
            ComicEnum comicName = ChooseRandomComicSource();

            return comicName switch
            {
                ComicEnum.Garfield => GetGarfieldComic(),
                ComicEnum.Xkcd => GetXkcdComic(),
                ComicEnum.Dilbert => GetDilbertComic(),
                ComicEnum.CalvinAndHobbes => GetCalvinAndHobbesComic(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static ComicEnum ChooseRandomComicSource()
        {
            var random = new Random();

            return (ComicEnum)random.Next(Enum.GetNames(typeof(ComicEnum)).Length);
        }

        public async Task<string> GetDilbertComic()
        {
            _logger.LogInformation($"Returning Dilbert comic strip");

            return await _dilbert.GetDilbertComicUri();
        }

        public async Task<string> GetGarfieldComic()
        {
            _logger.LogInformation($"Returning Garfield comic strip");

            return await _garfield.GetGarfieldComicUri();
        }

        public async Task<string> GetXkcdComic()
        {
            _logger.LogInformation($"Returning XKCD comic strip");

            return await _xkcd.GetXkcdComicUri();
        }

        public async Task<string> GetCalvinAndHobbesComic()
        {
            _logger.LogInformation($"Returning Calvin and Hobbes comic strip");

            return await _calvinAndHobbes.CalvinAndHobbesComicUri();
        }
    }
}
