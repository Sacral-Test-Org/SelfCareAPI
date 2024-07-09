// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Users.UserForgotPasswordValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Users;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.Users
{
  public class UserForgotPasswordValidator : AbstractValidator<UserForgotPasswordModel>
  {
    public UserForgotPasswordValidator()
    {
      DefaultValidatorOptions.WithMessage<UserForgotPasswordModel, string>(DefaultValidatorExtensions.EmailAddress<UserForgotPasswordModel>((IRuleBuilder<UserForgotPasswordModel, string>) DefaultValidatorOptions.WithMessage<UserForgotPasswordModel, string>(DefaultValidatorExtensions.NotEmpty<UserForgotPasswordModel, string>((IRuleBuilder<UserForgotPasswordModel, string>) DefaultValidatorOptions.Cascade<UserForgotPasswordModel, string>(this.RuleFor<string>((Expression<Func<UserForgotPasswordModel, string>>) (ufp => ufp.Email)), (CascadeMode) 1)), "Email address is required")), "A valid email is required");
    }
  }
}
