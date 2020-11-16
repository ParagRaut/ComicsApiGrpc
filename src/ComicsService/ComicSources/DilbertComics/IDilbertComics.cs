using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.DilbertComics
{
    public interface IDilbertComics
    {
        Task<string> GetDilbertComicUri();
    }
}