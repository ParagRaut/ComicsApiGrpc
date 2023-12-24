using ComicsProvider;
using Grpc.Core;

namespace ComicApiGrpc.Services;

public class ComicService : ComicApi.ComicApiBase
{
    private readonly IComicsService _service;

    public ComicService(IComicsService service)
    {
        this._service = service;
    }

    private static ComicEnum ChooseRandomComicSource() =>
        (ComicEnum)new Random().Next(Enum.GetNames(typeof(ComicEnum)).Length);

    public override async Task<ComicReply> GetComic(ComicRequest request, ServerCallContext context)
    {
        var random = ChooseRandomComicSource();

        return request.Comicname.ToLower() switch
        {
            "garfield" => new ComicReply
            {
                Comicurl = await this._service.GetGarfieldComics()
            },
            "xkcd" => new ComicReply
            {
                Comicurl = await this._service.GetXkcdComics()
            },
            "calvinandhobbs" => new ComicReply
            {
                Comicurl = await this._service.GetCalvinAndHobbesComics()
            },
            _ => new ComicReply
            {
                Comicurl = random switch
                {
                    ComicEnum.Garfield => await this._service.GetGarfieldComics(),
                    ComicEnum.Xkcd => await this._service.GetXkcdComics(),
                    ComicEnum.CalvinAndHobbes => await this._service.GetCalvinAndHobbesComics(),
                    _ => throw new ArgumentOutOfRangeException(),
                }
            },
        };
    }
}