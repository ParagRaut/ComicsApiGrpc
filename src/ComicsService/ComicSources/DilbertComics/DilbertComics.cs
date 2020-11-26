using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.DilbertComics
{
    public class DilbertComics : IDilbertComics
    {
        public async Task<string> GetDilbertComicUri()
        {
            return await Service.GetComicsUrl();
        }
    }
}