# Technical Discussion Record

## Mapperly for Mapping

We have decided to use [Mapperly](https://mapperly.riok.app/) to do "mapping" from one .NET type to another.

## Alternatives Considered

### Manual Mapping
We had just been writing our own code to do mapping.

```csharp
public static class EnitityMappers
{

  public static ResourceListItemModel MapToResponse(this ResourceListItemEntity entity)
  {
    return new ResourceListItemModel()
    {
      Id = entity.Id,
      Title = entity.Title,
      Description = entity.Description,
      CreatedBy = entity.CreatedBy,
      CreatedOn = entity.CreatedOn,
      Link = entity.Link,
      Tags = entity.Tags
    };
  }

}
```

This was fine, but we didn't get any good feedback from the compiler (errors, warnings) if we missed properties.

## AutoMapper

Automapper (link here?) is great, but it is more complex to set up, and uses reflection at startup.

This can cause a slight performance hit for startup, but also means we can't reuse these for AOT compiled applications.

## Mapperly

We chose Mapperly because it has a fairly easy configuration, and has no runtime performance cost because it uses source generators.

It does not rely on reflection.

## Reasons we May Want to Reevaluate This

- Licensing changes
- Support issues
- Blah blah blah.


## Examples when we've NOT used this:

- We had a thing and it was too hard to get the attributes and junk correctly, so we just wrote a manual map (see above) and some tests for it.

