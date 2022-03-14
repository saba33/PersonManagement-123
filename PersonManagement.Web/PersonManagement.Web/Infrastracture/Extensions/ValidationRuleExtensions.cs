using FluentValidation;
using PersonManagement.Web.Infrastracture.Localizations;
using System.Text.RegularExpressions;


namespace PersonManagement.Web.Infrastracture.Extensions
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, string> Passport<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^[0-9a-zA-Z]+$")).WithMessage(ErrorMessages.Passport);
        }

        public static IRuleBuilderOptions<T, string> Phone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^5\d{8}$")).WithMessage(ErrorMessages.Phone);
        }
    }
}
