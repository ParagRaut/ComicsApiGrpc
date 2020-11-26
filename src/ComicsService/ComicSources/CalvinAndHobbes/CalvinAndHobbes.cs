using System.Threading.Tasks;

namespace ComicApiGrpc.ComicsService.ComicSources.CalvinAndHobbes
{
    public class CalvinAndHobbes : ICalvinAndHobbes
    {
        public async Task<string> CalvinAndHobbesComicUri()
        {
            return await Service.GetComicUri();
        }
    }
}
