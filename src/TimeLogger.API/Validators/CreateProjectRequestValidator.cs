using FluentValidation;
using TimeLogger.Contract.Requests;

namespace TimeLogger.API.Validators
{
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        private const int ProjectNameMinLength = 10;
        private const int ProjectNameMaxLength = 255;

        public CreateProjectRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(ProjectNameMinLength)
                .MaximumLength(ProjectNameMaxLength);
        }
    }
}
