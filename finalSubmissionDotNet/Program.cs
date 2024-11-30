using Serilog;
using finalSubmissionDotNet.BuilderExtensions;
using finalSubmission.Infrastructure.Seeder;
using finalSubmissionDotNet.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});

builder.Services.AddServiceCollection(builder.Configuration);

WebApplication app = builder.Build();

app.UseExceptionMiddleware();

//using (IServiceScope scope = app.Services.CreateScope())
//{
//    var seeder = scope.ServiceProvider.GetRequiredService<IRoleSeeder>();
//    await seeder.SeedRolesAsync();
//}

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
