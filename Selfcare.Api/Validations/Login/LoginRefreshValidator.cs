// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Login.LoginRefreshValidator
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
  public class LoginRefreshValidator : AbstractValidator<LoginRefreshModel>
  {
    public LoginRefreshValidator()
    {
      DefaultValidatorExtensions.NotEmpty<LoginRefreshModel, string>((IRuleBuilder<LoginRefreshModel, string>) this.RuleFor<string>((Expression<Func<LoginRefreshModel, string>>) (lr => lr.RefreshToken)));
    }
  }
}
