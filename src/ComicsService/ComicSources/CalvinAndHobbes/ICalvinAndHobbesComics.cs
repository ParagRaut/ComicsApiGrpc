using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes
{
    public interface ICalvinAndHobbesComics
    {
        Task<string> CalvinAndHobbesComicUri();
    }
}
