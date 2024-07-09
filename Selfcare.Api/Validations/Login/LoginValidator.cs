// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Login.LoginValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Login;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.Login
{
  public class LoginValidator : AbstractValidator<LoginModel>
  {
    public LoginValidator()
    {
      DefaultValidatorExtensions.NotEmpty<LoginModel, string>((IRuleBuilder<LoginModel, string>) this.RuleFor<string>((Expression<Func<LoginModel, string>>) (l => l.Username)));
      DefaultValidatorExtensions.NotEmpty<LoginModel, string>((IRuleBuilder<LoginModel, string>) this.RuleFor<string>((Expression<Func<LoginModel, string>>) (l => l.Password)));
    }
  }
}
