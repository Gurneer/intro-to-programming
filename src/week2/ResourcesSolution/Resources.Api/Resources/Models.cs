using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Resources.Api.Resources;

/* {
    id: '2',
    title: 'NGRX',
    description: 'NGRX Family of Fine Angular Libraries',
    link: 'https://ngrx.io',
    linkText: 'NGRX.io',
    createdBy: 'sue@aol.com',
    createdOn: '2025-02-18T17:27:32.084Z',
    tags: ['Angular', 'TypeScript', 'Training', 'State', 'Signals', 'Redux'],
  },*/

public record ResourceListItemModel
{
  public Guid Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Link { get; set; } = string.Empty;
  public string LinkText { get; set; } = string.Empty;
  public string CreatedBy { get; set; } = string.Empty;
  public DateTimeOffset CreatedOn { get; set; }
  public List<string> Tags { get; set; } = new();

}

// {"title":"Some title","description":"Some Description","link":"https://wwww.microsoft.com","linkText":"Microsoft","tags":["where","do","you","want","to","go","today"]}

public record ResourceListItemCreateModel
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Link { get; set; } = string.Empty;
  public string LinkText { get; set; } = string.Empty;
  public List<string> Tags { get; set; } = new();
}

public class ResourceListItemCreateModelValidationsService : AbstractValidator<ResourceListItemCreateModel>
{
  public ResourceListItemCreateModelValidationsService()
  {
    RuleFor(m => m.Title).NotEmpty().MinimumLength(3).MaximumLength(100);
    RuleFor(m => m.Link).NotEmpty();
    RuleFor(m => m.LinkText).NotEmpty().MinimumLength(3).MaximumLength(20);
  }
}
