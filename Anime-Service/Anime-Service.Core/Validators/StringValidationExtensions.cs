using System.Runtime.CompilerServices;
using CSharpFunctionalExtensions;

namespace Anime_Service.Core.Validators;

public static class StringValidationExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result IsValidString(this string s, in string nameOfString)
    {
        return string.IsNullOrWhiteSpace(s) ? Result.Failure($"{nameOfString} cannot be null or empty") : Result.Success();
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result IsValidString(this string s, in int minLength, in int maxLength, in string nameOfString)
    {
        var stringValidationResult = s.IsValidString(nameOfString);
        if (stringValidationResult.IsFailure) return stringValidationResult;
        
        var stringLength =  s.Length;
        if (stringLength < minLength)
            return Result.Failure($"{nameOfString} cannot be shorter than {minLength}");
        if (stringLength > maxLength)
            return Result.Failure($"{nameOfString} cannot be longer than {maxLength}");
        
        return Result.Success();
    }
}