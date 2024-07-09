// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Accounts.AnonymousPaymentRegisterValidator
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
  public class AnonymousPaymentRegisterValidator : AbstractValidator<AnonymousPaymentRegisterModel>
  {
    public AnonymousPaymentRegisterValidator()
    {
      DefaultValidatorExtensions.GreaterThan<AnonymousPaymentRegisterModel, int>((IRuleBuilder<AnonymousPaymentRegisterModel, int>) DefaultValidatorExtensions.NotEmpty<AnonymousPaymentRegisterModel, int>((IRuleBuilder<AnonymousPaymentRegisterModel, int>) DefaultValidatorOptions.Cascade<AnonymousPaymentRegisterModel, int>(this.RuleFor<int>((Expression<Func<AnonymousPaymentRegisterModel, int>>) (anp => anp.AccountId)), (CascadeMode) 1)), 0);
      DefaultValidatorExtensions.GreaterThan<AnonymousPaymentRegisterModel, int>((IRuleBuilder<AnonymousPaymentRegisterModel, int>) DefaultValidatorExtensions.NotEmpty<AnonymousPaymentRegisterModel, int>((IRuleBuilder<AnonymousPaymentRegisterModel, int>) this.RuleFor<int>((Expression<Func<AnonymousPaymentRegisterModel, int>>) (arp => arp.TransactionId))), 0);
      DefaultValidatorExtensions.GreaterThan<AnonymousPaymentRegisterModel, Decimal>((IRuleBuilder<AnonymousPaymentRegisterModel, Decimal>) DefaultValidatorExtensions.NotEmpty<AnonymousPaymentRegisterModel, Decimal>((IRuleBuilder<AnonymousPaymentRegisterModel, Decimal>) this.RuleFor<Decimal>((Expression<Func<AnonymousPaymentRegisterModel, Decimal>>) (arp => arp.Amount))), 0M);
      DefaultValidatorExtensions.MaximumLength<AnonymousPaymentRegisterModel>((IRuleBuilder<AnonymousPaymentRegisterModel, string>) DefaultValidatorExtensions.NotEmpty<AnonymousPaymentRegisterModel, string>((IRuleBuilder<AnonymousPaymentRegisterModel, string>) this.RuleFor<string>((Expression<Func<AnonymousPaymentRegisterModel, string>>) (arp => arp.OrderId))), 256);
      DefaultValidatorExtensions.NotEmpty<AnonymousPaymentRegisterModel, string>((IRuleBuilder<AnonymousPaymentRegisterModel, string>) this.RuleFor<string>((Expression<Func<AnonymousPaymentRegisterModel, string>>) (arp => arp.Reference)));
    }
  }
}
