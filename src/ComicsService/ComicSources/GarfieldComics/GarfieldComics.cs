using System.Threading.Tasks;
using ComicApiGrpc.ComicsService.ComicSources.GarfieldComics.GarfieldService;

namespace ComicApiGrpc.ComicsService.ComicSources.GarfieldComics
{
    public class GarfieldComics : IGarfieldComics
    {
        public Task<string> GetGarfieldComicUri()
        {
            return GarfieldServiceApi.GetGarfieldComicsUrl();
        }
    }
}