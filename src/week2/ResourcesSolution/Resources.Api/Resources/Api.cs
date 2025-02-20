using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api(IValidator<ResourceListItemCreateModel> validator, IDocumentSession session, ILogger<Api> _logger) : ControllerBase
{

  [HttpGet("/resources")]
  public async Task<ActionResult> GetAllResources(CancellationToken token)
  {
    
    var response = await session.Query<ResourceListItemEntity>()
     .ProjectToResponse()
       .OrderBy(r => r.CreatedOn)
       .ThenBy(r => r.CreatedBy)
       .ToListAsync(token);
   
    return Ok(response);
  }

  [HttpPost("/resources")]
  public async Task<ActionResult> AddResourceItem(
    [FromBody] ResourceListItemCreateModel request,
    [FromServices] UserInformationProvider userInfo)
  {

    await Task.Delay(3000);
    var validations = await validator.ValidateAsync(request);

    if (validations.IsValid == false)
    {
      return BadRequest(validations.ToDictionary()); // more on that later.
    }

    //var entityToSave = request.MapFromRequestModel();

    var entityToSave = new ResourceListItemEntity
    {
      Id = Guid.NewGuid(),
      Description = request.Description,
      Title = request.Title,
      Link = request.Link,
      LinkText = request.LinkText,
      Tags = request.Tags,
      CreatedBy = await  userInfo.GetUserNameAsync(),
      CreatedOn = DateTimeOffset.Now,
    };
   
    entityToSave.CreatedBy = await userInfo.GetUserNameAsync();
   
    session.Store(entityToSave);
    await session.SaveChangesAsync();



    // From that entity, create a response to send to the requester
    // Mapping from ResourceListItemEntity to ResourceListItemModel
  
    var response = entityToSave.MapToResponse();
   

    // TODO: Consider making this a 201 Created. More "nuanced".
    return Ok(response);
  }

  // GET /resources/3898398039=93898398983-39879839
  [HttpGet("/resources/{id:guid}")]
  public async Task<ActionResult> GetById(Guid id)
  {
    
    return Ok();
  }
}


public class UserInformationProvider
{
  public async Task<string> GetUserNameAsync()
  {
    return "babs@aol.com"; // for now.
  }
}

