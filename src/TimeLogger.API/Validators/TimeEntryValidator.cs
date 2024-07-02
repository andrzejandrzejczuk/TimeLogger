using FluentValidation;
using TimeLogger.Contract.Requests;

namespace TimeLogger.API.Validators
{
    public class TimeEntryValidator : AbstractValidator<CreateTimeEntryRequest>
    {
        public TimeEntryValidator() 
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty();

            RuleFor(x => x.Date)
                .NotEmpty();
            
            RuleFor(x => x.Activity)
                .NotEmpty();

            RuleFor(x => x.Time)
                .SetValidator(new TimeValidator());
        }
    }
}
