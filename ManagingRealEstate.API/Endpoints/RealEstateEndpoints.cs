using ManagingRealEstate.API.Commands;
using ManagingRealEstate.API.Common;
using ManagingRealEstate.API.Features.Commands;
using ManagingRealEstate.API.Features.Queries;
using ManagingRealEstate.API.Models;
using ManagingRealEstate.API.Queries;
using MediatR;

namespace ManagingRealEstate.API.Endpoints;

public class RealEstateEndpoints : EndpointGroupBase
{
    public override void Map(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("realestate")
            .WithTags("RealEstate");
            //.RequireAuthorization();

        group.MapPost("/", CreateRealEstateAsync)
            .WithName(nameof(CreateRealEstateAsync))
            .WithSummary("Create a new real estate listing")
            .Produces<Guid>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        group.MapGet("/", GetAllRealEstateAsync)
            .WithName(nameof(GetAllRealEstateAsync))
            .WithSummary("Retrieve all real estate listings")
            .Produces<IEnumerable<RealEstate>>(StatusCodes.Status200OK);

        group.MapGet("/{id:guid}", GetRealEstateByIdAsync)
            .WithName(nameof(GetRealEstateByIdAsync))
            .WithSummary("Retrieve a real estate listing by ID")
            .Produces<RealEstate>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id:guid}", UpdateRealEstateAsync)
            .WithName(nameof(UpdateRealEstateAsync))
            .WithSummary("Update an existing real estate listing")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();

        group.MapDelete("/{id:guid}", DeleteRealEstateAsync)
            .WithName(nameof(DeleteRealEstateAsync))
            .WithSummary("Delete a real estate listing")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> CreateRealEstateAsync(CreateRealEstateCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        return Results.Created($"/realestate/{result}", result);
    }

    private static async Task<IResult> GetAllRealEstateAsync(ISender sender)
    {
        var result = await sender.Send(new GetAllRealEstateQuery());
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> GetRealEstateByIdAsync(Guid id, ISender sender)
    {
        var result = await sender.Send(new GetRealEstateByIdQuery { RealEstateId = id });
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
    }

    private static async Task<IResult> UpdateRealEstateAsync(Guid id, UpdateRealEstateCommand command, ISender sender)
    {
        command.Id = id;
        var result = await sender.Send(command);
        return result ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    private static async Task<IResult> DeleteRealEstateAsync(Guid id, ISender sender)
    {
        var result = await sender.Send(new DeleteRealEstateCommand { RealEstateId = id });
        return result ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}
