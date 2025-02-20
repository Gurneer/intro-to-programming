using FluentValidation;
using Marten;
using Resources.Api.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
  // classroom demonstration - probably ok, but check with your local authorities. ;)
  options.AddDefaultPolicy(pol =>
  {
    pol.AllowAnyHeader();
    pol.WithMethods();
    pol.AllowAnyOrigin();
  });
});

builder.Services.AddScoped<IValidator<ResourceListItemCreateModel>, ResourceListItemCreateModelValidationsService>();
builder.Services.AddScoped<UserInformationProvider>(); // tells the API that if you need to inject this somewhere, (class, method) it's cool with us.
var connectionString = builder.Configuration.GetConnectionString("resources") ?? throw new Exception("No Connection String Found! Bailing!");
builder.Services.AddMarten(options =>
{
  options.Connection(connectionString);
}).UseLightweightSessions();
var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseAuthorization();

// This uses "reflection" to scan our entire project and create the route table based on attributes.
app.MapControllers();

app.Run();
