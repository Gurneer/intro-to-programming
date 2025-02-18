using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api : ControllerBase
{

  [HttpGet("/resources")]
  public async Task<ActionResult> GetAllResources()
  {
    var fakeData = new List<ResourceListItemModel>()
    {
        new ResourceListItemModel()
        {
          Id = Guid.NewGuid(),
          Title = "Learn .NET",
          Description = "Microsoft's .NET Educational Site",
          CreatedBy = "bob@aol.com",
          CreatedOn = DateTime.Now,
          Link = "https://dotnet.microsoft.com/en-us/learn",
          Tags = [".NET","Microsoft", "APIS"]
        }
    };
    return Ok(fakeData);
  }
}
