using FluentValidation;
using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Models;
using MediatR;

namespace ManagingRealEstate.API.Features.Commands;

public sealed record CreateRealEstateCommand : IRequest<Guid>
{
    public CreateRealEstateCommand(string title, string description, decimal price, string location)
    {
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }
}

internal sealed class CreateRealEstateCommandHandler : IRequestHandler<CreateRealEstateCommand, Guid>
{
    private readonly IDbContext _context;

    public CreateRealEstateCommandHandler(IDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateRealEstateCommand request, CancellationToken cancellationToken)
    {
        var realEstate = RealEstate.Create(request.Title, request.Description, request.Price, request.Location);

        await _context.Set<RealEstate>().AddAsync(realEstate, cancellationToken);

        await _context.SaveChangesAsync();

        return realEstate.Id;
    }
}

internal class CreateRealEstateCommandValidator : AbstractValidator<CreateRealEstateCommand>
{
    public CreateRealEstateCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(200).WithMessage("Location must not exceed 200 characters.");
    }
}
