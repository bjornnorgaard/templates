using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Application.Features.Pet
{
    public class GetAllPet
    {
        public class Command : IRequest<Result>
        {
            public int Take { get; set; } = 10;
            public int Skip { get; set; } = 0;
        }

        public class Result
        {
            public IEnumerable<Models.Pet> Pets { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Take).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);

                RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
            }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly IContext _context;

            public Handler(IContext context)
            {
                _context = context;
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var pets = await _context.Set<Models.Pet>()
                                         .Skip(request.Skip)
                                         .Take(request.Take)
                                         .ToListAsync(cancellationToken);

                var result = new Result { Pets = pets };

                return result;
            }
        }
    }
}
