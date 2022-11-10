using System.Collections.Generic;
using Mediator;

namespace AspNetSample.Application.Todos;

public sealed record GetTodoItems : IQuery<IEnumerable<TodoItemDto>>;
