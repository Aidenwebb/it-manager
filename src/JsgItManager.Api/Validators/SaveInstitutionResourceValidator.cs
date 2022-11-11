using FluentValidation;
using JsgItManager.Api.Resources;

namespace JsgItManager.Api.Validators;

public class SaveInstitutionResourceValidator : AbstractValidator<SaveInstitutionResource>
{
    public SaveInstitutionResourceValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}