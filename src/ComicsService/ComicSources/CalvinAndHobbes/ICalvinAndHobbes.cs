using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes
{
    public interface ICalvinAndHobbes
    {
        Task<string> CalvinAndHobbesComicUri();
    }
}
