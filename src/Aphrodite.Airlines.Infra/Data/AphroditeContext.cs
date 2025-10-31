namespace Aphrodite.Airlines.Infra.Data;

public class AphroditeContext : IAphroditeContext
{
    public IMongoCollection<Flight> Flights { get; }

    public AphroditeContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDb");
        var databaseName = configuration["MongoDbSettings:DatabaseName"];
        var collectionName = configuration["MongoDbSettings:CollectionName:0"];

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        var collections = database.ListCollectionNames().ToList();
        if (!collections.Contains(collectionName))
            database.CreateCollection(collectionName);

        Flights = database.GetCollection<Flight>(collectionName);
    }
}