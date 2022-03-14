using FluentValidation;
using PersonManagement.Web.Infrastracture.Extensions;
using PersonManagement.Web.Infrastracture.Localizations;
using PersonManagement.Web.Models.Requests;
using System;

namespace PersonManagement.Web.Infrastracture.Validators
{
    public class PersonRequestValidator : AbstractValidator<CreatePersonRequest>
    {
        //წესი  - rules 
        public PersonRequestValidator()
        {
            RuleFor(x => x.Identifier)
                .Length(11)
                .NotEmpty();
            //.WithMessage("why it is empty ?")

            //.WithMessage("Identifier date error message")
            //.Matches("^[0-9]+$");

            RuleFor(x => x.BirthDate)
                .LessThanOrEqualTo(x => DateTime.Now)
                .WithMessage(ErrorMessages.BirthDate);

            RuleFor(x => x.Age)
                .Must(value => value > 18)
                .WithMessage(ErrorMessages.Age);


            RuleForEach(x => x.Accounts).SetValidator(new BankAccountValidator());


            When(x => x.IsBankCustomer, () =>
                 {
                     RuleFor(x => x.Accounts)
                     .NotEmpty()
                     .WithMessage("error");
                 });

            RuleFor(x => x.Passport).Passport();

            RuleFor(x => x.PhoneNumber).Phone();


            //RuleSet("Post", () =>
            //{
            //    RuleFor(x => x.Id).Empty();
            //});

            //RuleSet("PUT", () =>
            //{
            //    RuleFor(x => x.Id).NotEmpty();
            //});

            RuleSet("Third", () =>
            {
                RuleFor(x => x.Accounts)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty()
                 .NotNull()
                 .When(x => x.IsBankCustomer)
                 .Empty()
                 .When(x => !x.IsBankCustomer, ApplyConditionTo.CurrentValidator);
            });
        }
    }
}
