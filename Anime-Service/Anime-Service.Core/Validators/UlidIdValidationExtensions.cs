using System.Runtime.CompilerServices;
using CSharpFunctionalExtensions;

namespace Anime_Service.Core.Validators;

public static class UlidIdValidationExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result IsValidId(this Ulid id)
    {
        return id == Ulid.Empty ? Result.Failure($"{nameof(id)} cannot be empty") : Result.Success();
    }
}