using FluentValidation;
using TimeLogger.Contract.Requests;

namespace TimeLogger.API.Validators
{
    public class TimeValidator : AbstractValidator<Time>
    {
        private const int MinTimeValue = 0;
        private const int MaxHourValue = 24;
        private const int MaxMinutesValue = 59;

        public TimeValidator() 
        {
            RuleFor(x => x.Hours)
                .InclusiveBetween(MinTimeValue, MaxHourValue)
                .WithMessage($"Hours must be between {MinTimeValue} and {MaxHourValue}.");

            RuleFor(x => x.Minutes)
                .InclusiveBetween(MinTimeValue, MaxMinutesValue)
                .WithMessage($"Minutes must be between {MinTimeValue} and {MaxMinutesValue}.");
        }
    }
}
