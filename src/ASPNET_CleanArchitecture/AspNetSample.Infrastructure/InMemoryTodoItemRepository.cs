using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetSample.Application;
using AspNetSample.Application.Todos;
using AspNetSample.Domain;

namespace AspNetSample.Infrastructure;

internal sealed class InMemoryTodoItemRepository : ITodoItemRepository
{
    private readonly List<TodoItem> _db = new List<TodoItem>();
    private readonly object _lock = new { };

    public ValueTask AddItem(TodoItem item, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            if (_db.Any(i => i.Id == item.Id))
            {
                throw new Exception("Item already exists");
            }

            _db.Add(item);
        }

        return default;
    }

    public ValueTask<IEnumerable<TodoItem>> GetItems(CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            return new ValueTask<IEnumerable<TodoItem>>(_db.ToArray());
        }
    }
}
