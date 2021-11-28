using System.Threading.Tasks;
using ComicApiGrpc.ComicsService;
using ComicApiGrpc.ComicsService.Dilbert;
using ComicApiGrpc.ComicsService.Garfield;
using ComicApiGrpc.ComicsService.CalvinAndHobbes;
using ComicApiGrpc.ComicsService.XKCD;
using Grpc.Core;

namespace ComicApiGrpc.Services;

public class ComicService : ComicApi.ComicApiBase
{
    private readonly XKCDService _xKCDService;
    private readonly CalvinAndHobbesService _calvinAndHobbesService;
    private readonly DilbertService _dilbertService;
    private readonly GarfieldService _garfieldService;

    public ComicService(XKCDService xKCDService, CalvinAndHobbesService calvinAndHobbesService, DilbertService dilbertService, GarfieldService garfieldService)
    {
        _xKCDService = xKCDService;
        _calvinAndHobbesService = calvinAndHobbesService;
        _dilbertService = dilbertService;
        _garfieldService = garfieldService;
    }

    private static ComicEnum ChooseRandomComicSource() => (ComicEnum)new Random().Next(Enum.GetNames(typeof(ComicEnum)).Length);

    public override async Task<ComicReply> GetComic(ComicRequest request, ServerCallContext context)
    {
        var random = ChooseRandomComicSource();

        return request.Comicname.ToLower() switch
        {
            "dilbert" => new ComicReply
            {
                Comicurl = await _dilbertService.GetComicUri()
            },
            "garfield" => new ComicReply
            {
                Comicurl = await _garfieldService.GetComicUri()
            },
            "xkcd" => new ComicReply
            {
                Comicurl = await _xKCDService.GetComicUri()
            },
            "calvinAndHobbs" => new ComicReply
            {
                Comicurl = await _calvinAndHobbesService.GetComicUri()
            },
            _ => new ComicReply
            {
                Comicurl = random switch
                {
                    ComicEnum.Garfield => await _garfieldService.GetComicUri(),
                    ComicEnum.XKCD => await _xKCDService.GetComicUri(),
                    ComicEnum.Dilbert => await _dilbertService.GetComicUri(),
                    ComicEnum.CalvinAndHobbes => await _calvinAndHobbesService.GetComicUri(),
                    _ => throw new ArgumentOutOfRangeException(),
                }
            },
        };
    }
}
