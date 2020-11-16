using System.Threading.Tasks;
using ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes.CalvinAndHobbesService;

namespace ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes
{
    public class CalvinAndHobbesComics : ICalvinAndHobbesComics
    {
        public async Task<string> CalvinAndHobbesComicUri()
        {
            var calvinAndHobbesServiceApi = new CalvinAndHobbesServiceApi();

            string comicStripUri = await calvinAndHobbesServiceApi.CalvinAndHobbesComicUrl();

            return comicStripUri;
        }
    }
}
