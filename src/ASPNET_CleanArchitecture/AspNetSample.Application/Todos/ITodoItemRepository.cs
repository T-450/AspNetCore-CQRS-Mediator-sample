using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetSample.Domain;

namespace AspNetSample.Application.Todos;

public interface ITodoItemRepository
{
    ValueTask<IEnumerable<TodoItem>> GetItems(CancellationToken cancellationToken);

    ValueTask AddItem(TodoItem item, CancellationToken cancellationToken);
}
