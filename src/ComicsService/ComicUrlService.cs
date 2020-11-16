using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using ComicApiGrpc.ComicsService.ComicSources;
using ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes;
using ComicApiGrpc.ComicsService.ComicSources.DilbertComics;
using ComicApiGrpc.ComicsService.ComicSources.GarfieldComics;
using ComicApiGrpc.ComicsService.ComicSources.XKCD;
using Microsoft.Extensions.Logging;

namespace ComicApiGrpc.ComicsService
{
    public class ComicUrlService : IComicUrlService
    {
        public ComicUrlService(
            [NotNull] IXkcdComic xkcdComic,
            [NotNull] IGarfieldComics garfieldComics,
            [NotNull] IDilbertComics dilbertComics,
            [NotNull] ICalvinAndHobbesComics calvinAndHobbesComics,
            ILogger<ComicUrlService> logger)
        {
            XkcdComicsService = xkcdComic;
            GarfieldComicsService = garfieldComics;
            DilbertComicsService = dilbertComics;
            CalvinAndHobbesComicsService = calvinAndHobbesComics;
            _logger = logger;
        }

        private IXkcdComic XkcdComicsService { get; }

        private IGarfieldComics GarfieldComicsService { get; }

        private IDilbertComics DilbertComicsService { get; }

        private ICalvinAndHobbesComics CalvinAndHobbesComicsService { get; }

        private Task<string> ComicImageUri { get; set; }

        private readonly ILogger _logger;

        public Task<string> GetRandomComic()
        {
            ComicEnum comicName = ChooseRandomComicSource();

            switch (comicName)
            {
                case ComicEnum.Garfield:
                    ComicImageUri = GetGarfieldComic();
                    break;
                case ComicEnum.Xkcd:
                    ComicImageUri = GetXkcdComic();
                    break;
                case ComicEnum.Dilbert:
                    ComicImageUri = GetDilbertComic();
                    break;
                case ComicEnum.CalvinAndHobbes:
                    ComicImageUri = GetCalvinAndHobbesComic();
                    break;
                default:
                    _logger.LogInformation("Argument exception is thrown");
                    throw new ArgumentOutOfRangeException();
            }

            return ComicImageUri;
        }

        private ComicEnum ChooseRandomComicSource()
        {
            var random = new Random();
            return (ComicEnum)random.Next(Enum.GetNames(typeof(ComicEnum)).Length);
        }

        public async Task<string> GetDilbertComic()
        {
            _logger.LogInformation($"Returning Dilbert comic strip");

            return await DilbertComicsService.GetDilbertComicUri();
        }

        public async Task<string> GetGarfieldComic()
        {
            _logger.LogInformation($"Returning Garfield comic strip");

            return await GarfieldComicsService.GetGarfieldComicUri();
        }

        public async Task<string> GetXkcdComic()
        {
            _logger.LogInformation($"Returning XKCD comic strip");

            return await XkcdComicsService.GetXkcdComicUri();
        }

        public async Task<string> GetCalvinAndHobbesComic()
        {
            _logger.LogInformation($"Returning Calvin and Hobbes comic strip");

            return await CalvinAndHobbesComicsService.CalvinAndHobbesComicUri();
        }
    }
}
