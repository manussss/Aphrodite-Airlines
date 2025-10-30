namespace Aphrodite.Airlines.API.Endpoints;

public static class BookingEndpoints
{
    public static IEndpointRouteBuilder MapBookingEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("api/v1/booking", AddAsync);
        endpointRouteBuilder.MapGet("api/v1/booking/{id}", GetByIdAsync);

        return endpointRouteBuilder;
    }

    public static async Task<IResult> AddAsync(
    [FromServices] IMediator mediator,
    [FromBody] CreateBookingCommand command)
    {
        var id = await mediator.Send(command);

        return Results.Created(nameof(GetByIdAsync), new { Id = id });
    }

    public static async Task<IResult> GetByIdAsync(
    [FromServices] IMediator mediator,
    Guid id)
    {
        var booking = await mediator.Send(new GetBookingQuery(id));

        return Results.Ok(booking);
    }
}