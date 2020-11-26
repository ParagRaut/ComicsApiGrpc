using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.Garfield
{
    public interface IGarfield
    {
        Task<string> GetGarfieldComicUri();
    }
}