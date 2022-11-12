using FluentValidation;
using ItManager.Api.Resources;

namespace ItManager.Api.Validators;

public class SaveInstitutionResourceValidator : AbstractValidator<SaveInstitutionResource>
{
    public SaveInstitutionResourceValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}