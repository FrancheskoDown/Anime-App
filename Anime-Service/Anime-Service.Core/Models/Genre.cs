using Anime_Service.Core.Constants;
using Anime_Service.Core.Validators;
using CSharpFunctionalExtensions;

namespace Anime_Service.Core.Models;

public class Genre : Entity<Ulid>
{
    public string Name { get; } = string.Empty;
    public string Description { get; } = string.Empty;

    private Genre(in Ulid id, in string name, in string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    public static Result<Genre> TryCreate(Ulid id, string name, string description)
    {
        return Result.Success()
            .Ensure(() => id.IsValidId())
            .Ensure(() => name.IsValidString(GenreConstants.NameMinLength, GenreConstants.NameMaxLength, nameof(name)))
            .Ensure(() => description.IsValidString(GenreConstants.DescriptionMinLength, GenreConstants.DescriptionMaxLength, nameof(description)))
            .Map(() => new Genre(in id, in name, in description));
    }
}