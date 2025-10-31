namespace Aphrodite.Airlines.Domain.Entities;

public class Flight
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    
    [BsonElement("FlightNumber")]
    public string FlightNumber { get; set; }
    
    [BsonElement("Origin")]
    public string Origin { get; set; }
    
    [BsonElement("Destination")]
    public string Destination { get; set; }

    [BsonElement("DepartureDate")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime DepartureDate { get; set; }

    [BsonElement("ArrivalDate")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime ArrivalDate { get; set; }
}