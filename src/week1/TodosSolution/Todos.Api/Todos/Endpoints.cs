using Marten;
namespace Todos.Api.Todos;

public static class Endpoints
{
    //Thisi s called an "Extention Method"
    //This will add a method to the Endpoint Route Builder called "MapTodos"
    public static IEndpointRouteBuilder MapTodos(this IEndpointRouteBuilder builder)
    {
        // GET /todos
        //builder.MapGet("/todos", () =>
        //{
        //    var fakeData = new List<TodoListItem>()
        //{
        //  new TodoListItem() { Id = Guid.NewGuid(), Description = "Clean Garage", Completed = false, CreatedOn = DateTimeOffset.UtcNow }
        //};

        //    return Results.Ok(fakeData);
        //});
        // GET /todos
        builder.MapGet("/todos", async (IDocumentSession session) =>
        {
            var response = await session.Query<TodoListItem>().ToListAsync();
            return Results.Ok(response);
        });

        //POST /todos
        //builder.MapPost("/todos", (TodoListCreateItem request) =>
        //{

        //    var response = new TodoListItem
        //    {
        //        Id = Guid.NewGuid(),
        //        Description = request.Description,
        //        Completed = false,
        //        CreatedOn = DateTimeOffset.UtcNow
        //    };
        //    return Results.Ok(response);
        //});
        // POST /todos


        builder.MapPost("/todos", async (TodoListCreateItem request, IDocumentSession session) =>
        {

            var response = new TodoListItem
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Completed = false,
                CreatedOn = DateTimeOffset.UtcNow
            };

            session.Store(response);
            await session.SaveChangesAsync();
            return Results.Ok(response);
        });

        return builder;
    }
}

    public record TodoListItem
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool Completed { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? CompletedOn { get; set; }
    }

    public record TodoListCreateItem
    {
        public string Description { get; set; } = string.Empty;
    }


