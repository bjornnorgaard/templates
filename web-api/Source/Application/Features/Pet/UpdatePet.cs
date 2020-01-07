using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Application.Features.Pet
{
    public class UpdatePet
    {
        public class Command : IRequest<Result>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Result
        {
            public Models.Pet Pet { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(r => r.Name).NotEmpty();
                RuleFor(r => r.Age).GreaterThan(0).NotEmpty();
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
                var pet = await _context.Set<Models.Pet>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (pet == null)
                {
                    throw new NotFoundException(request.Id, typeof(Models.Pet));
                }

                pet = _mapper.Map(request, pet);

                await _context.SaveChangesAsync(cancellationToken);

                var result = new Result { Pet = pet };

                return result;
            }
        }
    }
}
