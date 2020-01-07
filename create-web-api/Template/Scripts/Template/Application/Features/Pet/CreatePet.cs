using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Repository;

namespace Application.Features.[Entity]
{
    public class Create[Entity]
    {
        public class Command : IRequest<Result>
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Result
        {
            public Models.[Entity] [Entity] { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(r => r.Name).NotEmpty();
                RuleFor(r => r.Age).GreaterThan(0);
            }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly IContext _context;
            private readonly IMapper _mapper;

            public Handler(IContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                // TODO: Implement method.
                throw new NotImplementedException();
            }
        }
    }
}
