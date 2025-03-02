using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManagingRealEstate.API.Features.Queries
{
    public sealed record GetRealEstateByIdQuery : IRequest<RealEstate?>
    {
        public Guid RealEstateId { get; set; }
    }

    internal sealed class GetRealEstateByIdQueryHandler : IRequestHandler<GetRealEstateByIdQuery, RealEstate?>
    {
        private readonly IDbContext _context;

        public GetRealEstateByIdQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<RealEstate?> Handle(GetRealEstateByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<RealEstate>().SingleOrDefaultAsync(x => x.Id == request.RealEstateId, cancellationToken);
        }
    }
}
