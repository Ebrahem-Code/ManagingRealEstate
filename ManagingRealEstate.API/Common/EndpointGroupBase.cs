using Microsoft.Extensions.Localization;

namespace ManagingRealEstate.API.Common
{
    public abstract class EndpointGroupBase
    {
        public abstract void Map(IEndpointRouteBuilder endpoints);

    }
}
