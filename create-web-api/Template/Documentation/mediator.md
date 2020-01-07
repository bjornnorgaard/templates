# MediatR Pattern

Split into feature folders, located in the `Application` project. Each feature must have all needed inputs present in the `Command` class and all outputs in the `Result` class. Pipelines are provided in the `Infrastructure` project and configured in the `Api.Web` project.

```csharp
public class CreatePerson
{
    // Class containing all inputs to handler.
    public class Command : IRequest<Result>
    {
        public string Name { get; set; }
    }

    // Complex type to return.
    public class Result
    {
        public int Id { get; set; }
    }

    // Validates input.
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }

    // Handles action.
    public class Handler : IRequestHandler<Command, Result>
    {
        public Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            // Somehow create the person.
            return Task.FromResult(new Result());
        }
    }
}
```
