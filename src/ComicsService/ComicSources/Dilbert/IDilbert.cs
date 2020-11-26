using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.Dilbert
{
    public interface IDilbert
    {
        Task<string> GetDilbertComicUri();
    }
}