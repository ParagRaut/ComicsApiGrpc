using System.Threading.Tasks;
using ComicApiGrpc.ComicsService;
using Grpc.Core;

namespace ComicApiGrpc.Services
{
    public class ComicService : ComicApi.ComicApiBase
    {
        private readonly IComicUrlService _comicUrlService;

        public ComicService(IComicUrlService comicUrlService)
        {
            _comicUrlService = comicUrlService;
        }

        public override async Task<ComicReply> GetComic(ComicRequest request, ServerCallContext context)
        {
            return request.Comicname switch
            {
                "dilbert" => new ComicReply
                {
                    Comicurl = await _comicUrlService.GetDilbertComic()
                },
                "garfield" => new ComicReply
                {
                    Comicurl = await _comicUrlService.GetGarfieldComic()
                },
                "xkcd" => new ComicReply
                {
                    Comicurl = await _comicUrlService.GetXkcdComic()
                },
                "calvinAndHobbs" => new ComicReply
                {
                    Comicurl = await _comicUrlService.GetCalvinAndHobbesComic()
                },
                _ => new ComicReply
                {
                    Comicurl = await _comicUrlService.GetRandomComic()
                },
            };
        }
    }
}
