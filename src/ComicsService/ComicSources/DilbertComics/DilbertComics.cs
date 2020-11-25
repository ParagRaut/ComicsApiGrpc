using System.Threading.Tasks;
using ComicApiGrpc.ComicsService.ComicSources.DilbertComics.DilbertService;

namespace ComicApiGrpc.ComicsService.ComicSources.DilbertComics
{
    public class DilbertComics : IDilbertComics
    {
        public async Task<string> GetDilbertComicUri()
        {
            return await DilbertServiceApi.GetDilbertComicsUrl();
        }
    }
}