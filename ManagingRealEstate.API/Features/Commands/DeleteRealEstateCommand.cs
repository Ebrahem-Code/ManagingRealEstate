using FluentValidation;
using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Models;
using MediatR;

namespace ManagingRealEstate.API.Features.Commands;

public sealed record DeleteRealEstateCommand : IRequest<bool>
{
    public Guid RealEstateId { get; set; }
}

internal sealed class DeleteRealEstateCommandHandler : IRequestHandler<DeleteRealEstateCommand, bool>
{
    private readonly IDbContext _context;

    public DeleteRealEstateCommandHandler(IDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteRealEstateCommand request, CancellationToken cancellationToken)
    {
        var realEstate = await _context.Set<RealEstate>().FindAsync(new object[] { request.RealEstateId }, cancellationToken);
        
        if (realEstate == null)
        {
            return false;
        }

        _context.Set<RealEstate>().Remove(realEstate);

        await _context.SaveChangesAsync();

        return true;
    }
}

internal class DeleteRealEstateCommandValidator : AbstractValidator<DeleteRealEstateCommand>
{
    public DeleteRealEstateCommandValidator()
    {
        RuleFor(x => x.RealEstateId)
            .NotEmpty().WithMessage("RealEstateId is required.");
    }
}
