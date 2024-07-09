// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Accounts.RetrieveAnonymousTransactionsValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Accounts;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.Accounts
{
  public class RetrieveAnonymousTransactionsValidator : 
    AbstractValidator<AnonymousTransactionsRetrieveParametersModel>
  {
    public RetrieveAnonymousTransactionsValidator()
    {
      DefaultValidatorExtensions.NotEmpty<AnonymousTransactionsRetrieveParametersModel, string>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, string>) DefaultValidatorOptions.Cascade<AnonymousTransactionsRetrieveParametersModel, string>(this.RuleFor<string>((Expression<Func<AnonymousTransactionsRetrieveParametersModel, string>>) (at => at.LicensePlateNumber)), (CascadeMode) 1));
      DefaultValidatorExtensions.GreaterThan<AnonymousTransactionsRetrieveParametersModel, int>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, int>) DefaultValidatorExtensions.NotEmpty<AnonymousTransactionsRetrieveParametersModel, int>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, int>) DefaultValidatorOptions.Cascade<AnonymousTransactionsRetrieveParametersModel, int>(this.RuleFor<int>((Expression<Func<AnonymousTransactionsRetrieveParametersModel, int>>) (at => at.CountryId)), (CascadeMode) 1)), 0);
      DefaultValidatorExtensions.GreaterThan<AnonymousTransactionsRetrieveParametersModel, int>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, int>) DefaultValidatorExtensions.NotEmpty<AnonymousTransactionsRetrieveParametersModel, int>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, int>) DefaultValidatorOptions.Cascade<AnonymousTransactionsRetrieveParametersModel, int>(this.RuleFor<int>((Expression<Func<AnonymousTransactionsRetrieveParametersModel, int>>) (at => at.RegionId)), (CascadeMode) 1)), 0);
      DefaultValidatorExtensions.GreaterThanOrEqualTo<AnonymousTransactionsRetrieveParametersModel, int>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, int>) DefaultValidatorExtensions.NotNull<AnonymousTransactionsRetrieveParametersModel, int>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, int>) DefaultValidatorOptions.Cascade<AnonymousTransactionsRetrieveParametersModel, int>(this.RuleFor<int>((Expression<Func<AnonymousTransactionsRetrieveParametersModel, int>>) (at => at.PlateTypeCodeId)), (CascadeMode) 1)), 0);
      DefaultValidatorExtensions.NotEmpty<AnonymousTransactionsRetrieveParametersModel, DateTime>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, DateTime>) DefaultValidatorOptions.Cascade<AnonymousTransactionsRetrieveParametersModel, DateTime>(this.RuleFor<DateTime>((Expression<Func<AnonymousTransactionsRetrieveParametersModel, DateTime>>) (at => at.From)), (CascadeMode) 1));
      DefaultValidatorExtensions.NotEmpty<AnonymousTransactionsRetrieveParametersModel, DateTime>((IRuleBuilder<AnonymousTransactionsRetrieveParametersModel, DateTime>) DefaultValidatorOptions.Cascade<AnonymousTransactionsRetrieveParametersModel, DateTime>(this.RuleFor<DateTime>((Expression<Func<AnonymousTransactionsRetrieveParametersModel, DateTime>>) (at => at.To)), (CascadeMode) 1));
    }
  }
}
