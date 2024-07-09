// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Users.UserChangePasswordValidator
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
  public class UserChangePasswordValidator : AbstractValidator<UserChangePasswordModel>
  {
    public UserChangePasswordValidator()
    {
      DefaultValidatorExtensions.NotEmpty<UserChangePasswordModel, string>((IRuleBuilder<UserChangePasswordModel, string>) this.RuleFor<string>((Expression<Func<UserChangePasswordModel, string>>) (urp => urp.CurrentPassword)));
      DefaultValidatorExtensions.NotEmpty<UserChangePasswordModel, string>((IRuleBuilder<UserChangePasswordModel, string>) this.RuleFor<string>((Expression<Func<UserChangePasswordModel, string>>) (urp => urp.NewPassword)));
      DefaultValidatorExtensions.Equal<UserChangePasswordModel, string>((IRuleBuilder<UserChangePasswordModel, string>) DefaultValidatorExtensions.NotEmpty<UserChangePasswordModel, string>((IRuleBuilder<UserChangePasswordModel, string>) DefaultValidatorOptions.Cascade<UserChangePasswordModel, string>(this.RuleFor<string>((Expression<Func<UserChangePasswordModel, string>>) (urp => urp.NewPasswordConfirmed)), (CascadeMode) 1)), (Expression<Func<UserChangePasswordModel, string>>) (urp => urp.NewPassword), (IEqualityComparer) null);
    }
  }
}
