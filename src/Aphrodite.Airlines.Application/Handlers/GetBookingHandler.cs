namespace Aphrodite.Airlines.Application.Handlers;

public class GetBookingHandler(
    IBookingRepository repository) : IRequestHandler<GetBookingQuery, Booking?>
{
    public async Task<Booking?> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id);
    }
}