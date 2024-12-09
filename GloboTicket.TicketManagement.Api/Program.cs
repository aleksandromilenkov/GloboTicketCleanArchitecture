using GloboTicket.TicketManagement.Api;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

Log.Information("GloboTicket API starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration
        .WriteTo.Console()
        .ReadFrom.Configuration(context.Configuration));

// Configure services
builder.ConfigureServices();

// Build the application and configure the pipeline
var app = builder.Build();
app.ConfigurePipeline();

app.UseSerilogRequestLogging();

// Reset database (if needed)
//await app.ResetDatabaseAsync();

app.Run();

public partial class Program { }
