using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.Dilbert
{
    public class Dilbert : IDilbert
    {
        public async Task<string> GetDilbertComicUri()
        {
            return await Service.GetComicsUrl();
        }
    }
}