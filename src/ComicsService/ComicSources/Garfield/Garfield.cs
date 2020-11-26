using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.Garfield
{
    public class Garfield : IGarfield
    {
        public Task<string> GetGarfieldComicUri()
        {
            return Service.GetGarfieldComicsUrl();
        }
    }
}