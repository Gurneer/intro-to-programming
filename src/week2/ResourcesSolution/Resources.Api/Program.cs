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

var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
