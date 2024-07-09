// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Users.UserResetPasswordValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Users;
using System;
using System.Collections;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.Users
{
  public class UserResetPasswordValidator : AbstractValidator<UserResetPasswordModel>
  {
    public UserResetPasswordValidator()
    {
      DefaultValidatorExtensions.NotEmpty<UserResetPasswordModel, string>((IRuleBuilder<UserResetPasswordModel, string>) DefaultValidatorOptions.Cascade<UserResetPasswordModel, string>(this.RuleFor<string>((Expression<Func<UserResetPasswordModel, string>>) (urp => urp.UserId)), (CascadeMode) 1));
      DefaultValidatorExtensions.NotEmpty<UserResetPasswordModel, string>((IRuleBuilder<UserResetPasswordModel, string>) this.RuleFor<string>((Expression<Func<UserResetPasswordModel, string>>) (urp => urp.Code)));
      DefaultValidatorExtensions.NotEmpty<UserResetPasswordModel, string>((IRuleBuilder<UserResetPasswordModel, string>) this.RuleFor<string>((Expression<Func<UserResetPasswordModel, string>>) (urp => urp.PasswordConfirm)));
      DefaultValidatorOptions.WithMessage<UserResetPasswordModel, string>(DefaultValidatorOptions.When<UserResetPasswordModel, string>(DefaultValidatorExtensions.Equal<UserResetPasswordModel, string>((IRuleBuilder<UserResetPasswordModel, string>) DefaultValidatorExtensions.NotEmpty<UserResetPasswordModel, string>((IRuleBuilder<UserResetPasswordModel, string>) this.RuleFor<string>((Expression<Func<UserResetPasswordModel, string>>) (urp => urp.Password))), (Expression<Func<UserResetPasswordModel, string>>) (urp => urp.PasswordConfirm), (IEqualityComparer) null), (Func<UserResetPasswordModel, bool>) (user => !string.IsNullOrWhiteSpace(user.PasswordConfirm)), (ApplyConditionTo) 0), "'NewPassowrd' and  'ConfirmPassword' don't match");
    }
  }
}
