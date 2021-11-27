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
    private readonly XKCDService service;

    public ComicService(XKCDService service)
    {
        this.service = service;
    }

    private static ComicEnum ChooseRandomComicSource() => (ComicEnum)new Random().Next(Enum.GetNames(typeof(ComicEnum)).Length);

    public override async Task<ComicReply> GetComic(ComicRequest request, ServerCallContext context)
    {
        var random = ChooseRandomComicSource();

        return request.Comicname switch
        {
            "dilbert" => new ComicReply
            {
                Comicurl = await DilbertService.GetComicUri()
            },
            "garfield" => new ComicReply
            {
                Comicurl = await GarfieldService.GetComicUri()
            },
            "xkcd" => new ComicReply
            {
                Comicurl = await service.GetComicUri()
            },
            "calvinAndHobbs" => new ComicReply
            {
                Comicurl = await CalvinAndHobbesService.GetComicUri()
            },
            _ => new ComicReply
            {
                Comicurl = random switch
                {
                    ComicEnum.Garfield => await GarfieldService.GetComicUri(),
                    ComicEnum.XKCD => await service.GetComicUri(),
                    ComicEnum.Dilbert => await DilbertService.GetComicUri(),
                    ComicEnum.CalvinAndHobbes => await CalvinAndHobbesService.GetComicUri(),
                    _ => throw new ArgumentOutOfRangeException(),
                }
            },
        };
    }
}
