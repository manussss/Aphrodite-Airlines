var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<IAphroditeContext, AphroditeContext>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(CreateBookingHandler).Assembly,
    typeof(GetBookingHandler).Assembly,
    typeof(CreateFlightHandler).Assembly,
    typeof(DeleteFlightHandler).Assembly,
    typeof(GetAllFlightsHandler).Assembly,
    typeof(SendNotificationHandler).Assembly,
    typeof(ProcessPaymentHandler).Assembly,
    typeof(RefundPaymentHandler).Assembly,
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

var redisConfiguration = builder.Configuration.GetConnectionString("Redis");
var redis = ConnectionMultiplexer.Connect(redisConfiguration!);
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<NotificationEventConsumer>();
    config.AddConsumer<PaymentProcessedEventConsumer>();
    config.AddConsumer<FlightBookedEventConsumer>();

    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.NotificationSentQueue, c =>
        {
            c.ConfigureConsumer<NotificationEventConsumer>(context);
        });

        cfg.ReceiveEndpoint(EventBusConstants.PaymentProcessedQueue, c =>
        {
            c.ConfigureConsumer<PaymentProcessedEventConsumer>(context);
        });

        cfg.ReceiveEndpoint(EventBusConstants.FlightBookedQueue, c =>
        {
            c.ConfigureConsumer<FlightBookedEventConsumer>(context);
        });
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapBookingEndpoints();
app.MapFlightEndpoints();
app.MapNotificationEndpoints();
app.MapPaymentEndpoints();

await app.RunAsync();