using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Features.WeatherForecast;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
    };
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public async ValueTask<ActionResult<Result>> Post([FromBody] CreateRequest req, CancellationToken ct = default)
    {
        var r = await _mediator.Send(req, ct);

        return Created(new Uri(Url.Action() ?? throw new InvalidOperationException()), r);
    }
}
