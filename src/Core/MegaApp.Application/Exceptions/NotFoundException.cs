

using System.ComponentModel.DataAnnotations;

using FluentValidation.Results;
namespace MegaApp.Application.Exceptions;


[System.Serializable]
public class NotFoundException : Exception
{
    public NotFoundException() { }

    public NotFoundException(string name, object Key) : base($"{name} ({Key}) was not found.")
    {

    }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception inner) : base(message, inner) { }
    protected NotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}


public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, FluentValidation.Results.ValidationResult validationResult) : base(message)
    {
        ValidationErrors = new();
        foreach (var error in validationResult.Errors)
        {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }
    public List<String> ValidationErrors { get; set; }
}