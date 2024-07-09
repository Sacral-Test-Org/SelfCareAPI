// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Accounts.RegisterAccountTopupValidator
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
  public class RegisterAccountTopupValidator : AbstractValidator<RegisterAccountTopupModel>
  {
    public RegisterAccountTopupValidator()
    {
      DefaultValidatorExtensions.GreaterThan<RegisterAccountTopupModel, int>((IRuleBuilder<RegisterAccountTopupModel, int>) DefaultValidatorExtensions.NotEmpty<RegisterAccountTopupModel, int>((IRuleBuilder<RegisterAccountTopupModel, int>) this.RuleFor<int>((Expression<Func<RegisterAccountTopupModel, int>>) (tp => tp.AccountId))), 0);
      DefaultValidatorExtensions.GreaterThan<RegisterAccountTopupModel, Decimal>((IRuleBuilder<RegisterAccountTopupModel, Decimal>) DefaultValidatorExtensions.NotEmpty<RegisterAccountTopupModel, Decimal>((IRuleBuilder<RegisterAccountTopupModel, Decimal>) this.RuleFor<Decimal>((Expression<Func<RegisterAccountTopupModel, Decimal>>) (tp => tp.TopUpAmount))), 0M);
      DefaultValidatorExtensions.MaximumLength<RegisterAccountTopupModel>((IRuleBuilder<RegisterAccountTopupModel, string>) DefaultValidatorExtensions.NotEmpty<RegisterAccountTopupModel, string>((IRuleBuilder<RegisterAccountTopupModel, string>) this.RuleFor<string>((Expression<Func<RegisterAccountTopupModel, string>>) (tp => tp.OrderId))), 256);
      DefaultValidatorExtensions.MaximumLength<RegisterAccountTopupModel>((IRuleBuilder<RegisterAccountTopupModel, string>) DefaultValidatorExtensions.NotEmpty<RegisterAccountTopupModel, string>((IRuleBuilder<RegisterAccountTopupModel, string>) this.RuleFor<string>((Expression<Func<RegisterAccountTopupModel, string>>) (tp => tp.Reference))), 256);
    }
  }
}
