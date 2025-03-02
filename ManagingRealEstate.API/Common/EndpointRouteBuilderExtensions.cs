using ManagingRealEstate.API.Endpoints;

namespace ManagingRealEstate.API.Common
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void MapRealEstateEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var realEstateEndpoints = new RealEstateEndpoints();
            realEstateEndpoints.Map(endpoints);
        }
    }
}
