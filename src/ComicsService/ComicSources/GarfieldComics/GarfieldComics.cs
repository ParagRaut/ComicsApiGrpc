using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.GarfieldComics
{
    public class GarfieldComics : IGarfieldComics
    {
        public Task<string> GetGarfieldComicUri()
        {
            return Service.GetGarfieldComicsUrl();
        }
    }
}