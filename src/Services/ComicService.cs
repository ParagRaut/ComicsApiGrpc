using System.Threading.Tasks;
using ComicApiGrpc.ComicsService;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace ComicApiGrpc.Services
{
    public class ComicService : ComicApi.ComicApiBase
    {
        private readonly ILogger<ComicService> _logger;

        private IComicUrlService ComicUrlService { get; }

        public ComicService(ILogger<ComicService> logger, IComicUrlService comicUrlService)
        {
            _logger = logger;
            ComicUrlService = comicUrlService;
        }

        public override async Task<ComicReply> GetComic(ComicRequest request, ServerCallContext context)
        {
            switch (request.Comicname)
            {
                case "dilbert":
                    return new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetDilbertComic()
                    };
                case "garfield":
                    return new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetGarfieldComic()
                    };
                case "xkcd":
                    return new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetXkcdComic()
                    };
                case "calvinAndHobbs":
                    return new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetCalvinAndHobbesComic()
                    };
                default:
                    return new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetRandomComic()
                    };
            }

            
        }


    }
}
