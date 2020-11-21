using System;
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
            this._logger = logger;
            ComicUrlService = comicUrlService;
        }

        public override async Task<ComicReply> GetComic(ComicRequest request, ServerCallContext context)
        {
            try
            {
                throw new Exception();

                return request.Comicname switch
                {
                    "dilbert" => new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetDilbertComic()
                    },
                    "garfield" => new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetGarfieldComic()
                    },
                    "xkcd" => new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetXkcdComic()
                    },
                    "calvinAndHobbs" => new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetCalvinAndHobbesComic()
                    },
                    _ => new ComicReply
                    {
                        Comicurl = await ComicUrlService.GetRandomComic()
                    },
                };
            }
            catch (Exception exception)
            {
                this._logger.LogError("Something went wrong", exception);

                throw new RpcException(Status.DefaultCancelled, exception.Message);
            }
        }
    }
}
