using GloboTicket.TicketManagement.Api;


var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.ConfigureServices();

// Build the application and configure the pipeline
var app = builder.Build();
app.ConfigurePipeline();

// Reset database (if needed)
await app.ResetDatabaseAsync();

app.Run();

public partial class Program { }
