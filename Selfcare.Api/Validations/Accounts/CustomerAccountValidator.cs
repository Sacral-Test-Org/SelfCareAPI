// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Accounts.CustomerAccountValidator
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
  public class CustomerAccountValidator : AbstractValidator<CustomerAccountModel>
  {
    public CustomerAccountValidator()
    {
      DefaultValidatorOptions.WithMessage<CustomerAccountModel, int>(DefaultValidatorExtensions.InclusiveBetween<CustomerAccountModel, int>((IRuleBuilder<CustomerAccountModel, int>) DefaultValidatorOptions.WithMessage<CustomerAccountModel, int>(DefaultValidatorExtensions.NotNull<CustomerAccountModel, int>((IRuleBuilder<CustomerAccountModel, int>) DefaultValidatorOptions.Cascade<CustomerAccountModel, int>(this.RuleFor<int>((Expression<Func<CustomerAccountModel, int>>) (ca => ca.CustomerId)), (CascadeMode) 1)), "CustomerId is required"), 1, int.MaxValue), "CustomerId invalid value");
      DefaultValidatorOptions.WithErrorCode<CustomerAccountModel, bool>(DefaultValidatorExtensions.Must<CustomerAccountModel, bool>((IRuleBuilder<CustomerAccountModel, bool>) DefaultValidatorExtensions.NotEmpty<CustomerAccountModel, bool>((IRuleBuilder<CustomerAccountModel, bool>) DefaultValidatorOptions.Cascade<CustomerAccountModel, bool>(this.RuleFor<bool>((Expression<Func<CustomerAccountModel, bool>>) (ca => ca.OnlyNotClosed)), (CascadeMode) 1)), (Func<bool, bool>) (x => !x | x)), "Boolean Validation Failed");
    }
  }
}
