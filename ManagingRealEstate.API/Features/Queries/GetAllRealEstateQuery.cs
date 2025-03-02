using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManagingRealEstate.API.Queries;

public sealed record GetAllRealEstateQuery() : IRequest<IEnumerable<RealEstate>>;


internal sealed class GetAllRealEstateQueryHandler : IRequestHandler<GetAllRealEstateQuery, IEnumerable<RealEstate>>
{
    private readonly IDbContext _context;

    public GetAllRealEstateQueryHandler(IDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RealEstate>> Handle(GetAllRealEstateQuery request, CancellationToken cancellationToken)
    {
        return await _context.Set<RealEstate>().ToListAsync(cancellationToken);
    }
}

