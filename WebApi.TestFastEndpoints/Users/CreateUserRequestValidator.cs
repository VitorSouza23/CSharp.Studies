using FastEndpoints.Validation;

namespace TestFestEndpoints.Users;

public class CreateUserRequestValidator : Validator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("The First Name is required");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("The Last Name is required");

        RuleFor(x => x.Age)
            .NotEmpty()
            .WithMessage("The Age is required");
    }
}