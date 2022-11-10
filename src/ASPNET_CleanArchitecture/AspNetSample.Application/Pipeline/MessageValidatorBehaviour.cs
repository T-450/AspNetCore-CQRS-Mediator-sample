using System;
using System.Threading;
using System.Threading.Tasks;
using Mediator;

namespace AspNetSample.Application.Pipeline;

public sealed class MessageValidatorBehaviour<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse>
    where TMessage : IValidate
{
    public ValueTask<TResponse> Handle(
        TMessage message,
        CancellationToken cancellationToken,
        MessageHandlerDelegate<TMessage, TResponse> next
    )
    {
        if (!message.IsValid(out var validationError))
        {
            throw new Exception(validationError.ToString());
        }

        return next(message, cancellationToken);
    }
}
