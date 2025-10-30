namespace Aphrodite.Airlines.API.Endpoints;

public static class PaymentEndpoints
{
    public static IEndpointRouteBuilder MapPaymentEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("api/v1/payment", ProcessPaymentAsync);
        endpointRouteBuilder.MapPost("api/v1/payment:refund/{id}", RefundPaymentAsync);

        return endpointRouteBuilder;
    }

    public static async Task<IResult> ProcessPaymentAsync(
    [FromServices] IMediator mediator,
    [FromBody] ProcessPaymentCommand command)
    {
        var id = await mediator.Send(command);

        return Results.Created(nameof(ProcessPaymentAsync), new { Id = id });
    }

    public static async Task<IResult> RefundPaymentAsync(
    [FromServices] IMediator mediator,
    Guid id)
    {
        await mediator.Send(new RefundPaymentCommand(id));

        return Results.NoContent();
    }
}