using ASPNET.Models;
using Mediator;

namespace ASPNET.Features.WeatherForecast;

public sealed record Result(Guid Id);

public class CreateRequest : IRequest<Result> { }

public class WeatherForecastRequestHandler : IRequestHandler<CreateRequest, Result>
{
    private IEnumerable<WeatherForecastModel> _db;

    public WeatherForecastRequestHandler(IEnumerable<WeatherForecastModel> db)
    {
        _db = db;
    }

    public ValueTask<Result> Handle(CreateRequest createRequest, CancellationToken cancellationToken)
    {
        var newGame = new WeatherForecastModel
        {
            Date = DateTime.Now.AddDays(1),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = "This is a summmary.",
        };

        _db = _db!.Append(newGame);
        return new ValueTask<Result>(new Result(Guid.NewGuid()));
    }
}
