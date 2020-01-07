using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Application.Features.Pet
{
    public class DeletePet
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
            private readonly IContext _context;

            public Handler(IContext context)
            {
                _context = context;
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var pet = await _context.Set<Models.Pet>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (pet == null)
                {
                    throw new NotFoundException(request.Id, typeof(Models.Pet));
                }

                _context.Set<Models.Pet>().Remove(pet);
                await _context.SaveChangesAsync(cancellationToken);

                return new Result();
            }
        }
    }
}
