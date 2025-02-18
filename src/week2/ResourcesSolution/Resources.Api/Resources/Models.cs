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
  public string CreatedBy { get; set; } = string.Empty;
  public DateTimeOffset CreatedOn { get; set; }
  public List<string> Tags { get; set; } = new();

}
