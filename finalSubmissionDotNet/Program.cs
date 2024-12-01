using Serilog;
using finalSubmissionDotNet.BuilderExtensions;
using finalSubmissionDotNet.Middleware;
using finalSubmission.Infrastructure.ISeeder;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});

builder.Services.AddServiceCollection(builder.Configuration);

// Build the application
WebApplication app = builder.Build();

// Seed roles
await SeedRolesAsync(app.Services);

// Middleware setup
app.UseExceptionMiddleware();
app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Seed roles
async Task SeedRolesAsync(IServiceProvider services)
{
    using (var scope = services.CreateScope())
    {
        var roleSeeder = scope.ServiceProvider.GetRequiredService<IRoleSeeder>();
        await roleSeeder.SeedRolesAsync();
    }
}
