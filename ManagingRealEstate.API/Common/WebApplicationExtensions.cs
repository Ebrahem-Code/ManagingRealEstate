﻿using System.Reflection;

namespace ManagingRealEstate.API.Common;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group, string route = "",
        string groupName = "")
    {
        return app
            .MapGroup($"/api/{route}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);

        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
