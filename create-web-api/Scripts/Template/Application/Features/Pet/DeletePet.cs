using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Application.Features.[Entity]
{
    public class Delete[Entity]
    {
        public class Command : IRequest<Result>
        {
            public Guid Id { get; set; }
        }

        public class Result { }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(r => r.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly ITmpContext _context;

            public Handler(ITmpContext context)
            {
                _context = context;
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                // TODO: Implement method.
                throw new NotImplementedException();
            }
        }
    }
}
