using System.Diagnostics.CodeAnalysis;
using Mediator;

namespace AspNetSample.Application;

public interface IValidate : IMessage
{
    bool IsValid([NotNullWhen(false)] out ValidationError? error);
}
