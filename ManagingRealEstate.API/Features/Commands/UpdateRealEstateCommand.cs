using FluentValidation;
using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Models;
using MediatR;

namespace ManagingRealEstate.API.Commands;

public class UpdateRealEstateCommand : IRequest<bool>
{
    public UpdateRealEstateCommand(Guid id, string title, string description, decimal price, string location)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }
}

internal sealed class UpdateRealEstateCommandHandler : IRequestHandler<UpdateRealEstateCommand, bool>
{
    private readonly IDbContext _context;

    public UpdateRealEstateCommandHandler(IDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateRealEstateCommand request, CancellationToken cancellationToken)
    {
        var realEstate = await _context.Set<RealEstate>().FindAsync(new object[] { request.Id }, cancellationToken);

        if (realEstate == null)
        {
            return false;
        }

        realEstate.Update(request.Title, request.Description, request.Price, request.Location);
        
        await _context.SaveChangesAsync();

        return true;
    }
}

internal class UpdateRealEstateCommandValidator : AbstractValidator<UpdateRealEstateCommand>
{
    public UpdateRealEstateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

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
