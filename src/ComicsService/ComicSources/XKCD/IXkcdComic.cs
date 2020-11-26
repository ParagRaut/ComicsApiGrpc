using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.Xkcd
{
    public interface IXkcdComic
    {
        Task<string> GetXkcdComicUri();
    }
}