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

        public override Task<ComicReply> GetComic(ComicRequest request, ServerCallContext context)
        {
            switch (request.Comicname)
            {
                case "dilbert":
                    return Task.FromResult(new ComicReply
                    {
                        Comicurl = ComicUrlService.GetDilbertComic().GetAwaiter().GetResult()
                    });
                case "garfield":
                    return Task.FromResult(new ComicReply
                    {
                        Comicurl = ComicUrlService.GetGarfieldComic().GetAwaiter().GetResult()
                    });
                case "xkcd":
                    return Task.FromResult(new ComicReply
                    {
                        Comicurl = ComicUrlService.GetXkcdComic().GetAwaiter().GetResult()
                    });
                case "calvinAndHobbs":
                    return Task.FromResult(new ComicReply
                    {
                        Comicurl = ComicUrlService.GetCalvinAndHobbesComic().GetAwaiter().GetResult()
                    });
                default:
                    return Task.FromResult(new ComicReply
                    {
                        Comicurl = ComicUrlService.GetRandomComic().GetAwaiter().GetResult()
                    });
            }

            
        }


    }
}
