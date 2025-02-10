

using Marten;
using Todos.Api.Todos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("todos") ?? throw new Exception("Can't start the new API without a connection string");
builder.Services.AddMarten(builder =>
{
    builder.Connection(connectionString);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//above this line is configuration for the services inside out application
var app = builder.Build();
//below this line is configuration for how HTTP requests and responses are handled

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapTodos();

app.Run();
