using System.Reflection;
using Mediator;

namespace ASPNET.Behaviours;

public class LoggingBehaviour<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse>
    where TMessage : IMessage
{
    private readonly ILogger<LoggingBehaviour<TMessage, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TMessage, TResponse>> logger)
    {
        _logger = logger;
    }

    public async ValueTask<TResponse> Handle(TMessage request, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage, TResponse> next)
    {
        //Request
        _logger.LogInformation($"Handling {typeof(TMessage).Name}");
        var myType = request.GetType();
        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
        foreach (var prop in props)
        {
            var propValue = prop.GetValue(request, null);
            _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
        }
        var response = await next(request, cancellationToken);
        //Response
        _logger.LogInformation($"Handled {typeof(TResponse).Name}");
        return response;
    }
}
