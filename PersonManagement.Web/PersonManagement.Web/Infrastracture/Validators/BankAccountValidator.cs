using FluentValidation;
using PersonManagement.Web.Models.Requests;


namespace PersonManagement.Web.Infrastracture.Validators
{
    public class BankAccountValidator : AbstractValidator<PersonBankAccountRequest>
    {
        public BankAccountValidator()
        {
            RuleFor(x => x.IBAN)
                .Length(16)
                .Matches("^[a-zA-Z0-9]*$")
                .WithMessage(nameof(PersonBankAccountRequest.IBAN) + "must be 16 digits");

            RuleFor(x => x.CCY)
              .Length(3)
              .Matches("^[A-Z]*$")
              .WithMessage(nameof(PersonBankAccountRequest.CCY) + "must be 3 symbols");
        }
    }
}
