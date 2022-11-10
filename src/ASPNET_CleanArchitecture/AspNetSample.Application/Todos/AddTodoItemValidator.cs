using FluentValidation;

namespace AspNetSample.Application.Todos;

public class AddTodoItemValidator : AbstractValidator<AddTodoItem>
{
    public AddTodoItemValidator()
    {
        RuleFor(x => x.Title).Length(1, 40);
        RuleFor(x => x.Text).Length(1, 150);
    }
}
