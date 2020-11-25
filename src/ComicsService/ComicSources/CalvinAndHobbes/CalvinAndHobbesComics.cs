using System.Threading.Tasks;
using ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes.CalvinAndHobbesService;

namespace ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes
{
    public class CalvinAndHobbesComics : ICalvinAndHobbesComics
    {
        public async Task<string> CalvinAndHobbesComicUri()
        {
            return await CalvinAndHobbesServiceApi.CalvinAndHobbesComicUrl();
        }
    }
}
