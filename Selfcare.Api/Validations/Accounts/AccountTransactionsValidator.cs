// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Accounts.AccountTransactionsValidator
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
  public class AccountTransactionsValidator : AbstractValidator<AccountTransactionsRetrieveModel>
  {
    public AccountTransactionsValidator()
    {
      DefaultValidatorExtensions.GreaterThan<AccountTransactionsRetrieveModel, int>((IRuleBuilder<AccountTransactionsRetrieveModel, int>) DefaultValidatorExtensions.NotEmpty<AccountTransactionsRetrieveModel, int>((IRuleBuilder<AccountTransactionsRetrieveModel, int>) DefaultValidatorOptions.Cascade<AccountTransactionsRetrieveModel, int>(this.RuleFor<int>((Expression<Func<AccountTransactionsRetrieveModel, int>>) (at => at.AccountId)), (CascadeMode) 1)), 0);
      DefaultValidatorExtensions.GreaterThanOrEqualTo<AccountTransactionsRetrieveModel, int>((IRuleBuilder<AccountTransactionsRetrieveModel, int>) DefaultValidatorExtensions.NotNull<AccountTransactionsRetrieveModel, int>((IRuleBuilder<AccountTransactionsRetrieveModel, int>) this.RuleFor<int>((Expression<Func<AccountTransactionsRetrieveModel, int>>) (at => at.AccountUnitId))), 0);
      DefaultValidatorExtensions.GreaterThanOrEqualTo<AccountTransactionsRetrieveModel, int>((IRuleBuilder<AccountTransactionsRetrieveModel, int>) DefaultValidatorExtensions.NotNull<AccountTransactionsRetrieveModel, int>((IRuleBuilder<AccountTransactionsRetrieveModel, int>) this.RuleFor<int>((Expression<Func<AccountTransactionsRetrieveModel, int>>) (at => at.GantryId))), 0);
      DefaultValidatorExtensions.NotEmpty<AccountTransactionsRetrieveModel, DateTime>((IRuleBuilder<AccountTransactionsRetrieveModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<AccountTransactionsRetrieveModel, DateTime>>) (at => at.FromDate)));
      DefaultValidatorExtensions.NotEmpty<AccountTransactionsRetrieveModel, DateTime>((IRuleBuilder<AccountTransactionsRetrieveModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<AccountTransactionsRetrieveModel, DateTime>>) (at => at.ToDate)));
    }
  }
}
