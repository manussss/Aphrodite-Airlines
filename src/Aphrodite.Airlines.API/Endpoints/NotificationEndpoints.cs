namespace Aphrodite.Airlines.API.Endpoints;

public static class NotificationEndpoints
{
    public static IEndpointRouteBuilder MapNotificationEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("api/v1/notification", SendAsync);

        return endpointRouteBuilder;
    }

    public static async Task<IResult> SendAsync(
        [FromServices] IMediator mediator,
        [FromBody] SendNotificationCommand command)
    {
        await mediator.Send(command);

        return Results.Ok();
    }
}