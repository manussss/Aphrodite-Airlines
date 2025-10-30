namespace Aphrodite.Airlines.API.Endpoints;

public static class FlighEndpoints
{
    public static IEndpointRouteBuilder MapFlightEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("api/v1/flight", AddAsync);
        endpointRouteBuilder.MapGet("api/v1/flight", GetAllAsync);
        endpointRouteBuilder.MapDelete("api/v1/flight/{id}", DeleteAsync);

        return endpointRouteBuilder;
    }

    public static async Task<IResult> AddAsync(
    [FromServices] IMediator mediator,
    [FromBody] CreateFlightCommand command)
    {
        var id = await mediator.Send(command);

        return Results.Created(nameof(GetAllAsync), new { Id = id });
    }

    public static async Task<IResult> GetAllAsync(
    [FromServices] IMediator mediator)
    {
        var flights = await mediator.Send(new GetAllFlightsQuery());

        return Results.Ok(flights);
    }

    public static async Task<IResult> DeleteAsync(
    [FromServices] IMediator mediator,
    Guid id)
    {
        await mediator.Send(new DeleteFlightCommand(id));

        return Results.NoContent();
    }
}