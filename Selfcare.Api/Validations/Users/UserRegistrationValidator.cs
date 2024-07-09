// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Users.UserRegistrationValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Users;
using Selfcare.Infrastructure.Services;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Api.Validations.Users
{
  public class UserRegistrationValidator : AbstractValidator<UserRegistrationModel>
  {
    private readonly IUserService userService;

    public UserRegistrationValidator(IUserService userService)
    {
      this.userService = userService;
      DefaultValidatorOptions.WithMessage<UserRegistrationModel, string>(DefaultValidatorExtensions.MustAsync<UserRegistrationModel, string>((IRuleBuilder<UserRegistrationModel, string>) DefaultValidatorExtensions.EmailAddress<UserRegistrationModel>((IRuleBuilder<UserRegistrationModel, string>) DefaultValidatorExtensions.MaximumLength<UserRegistrationModel>((IRuleBuilder<UserRegistrationModel, string>) DefaultValidatorExtensions.NotEmpty<UserRegistrationModel, string>((IRuleBuilder<UserRegistrationModel, string>) DefaultValidatorOptions.Cascade<UserRegistrationModel, string>(this.RuleFor<string>((Expression<Func<UserRegistrationModel, string>>) (u => u.Email)), (CascadeMode) 1)), 100)), new Func<string, CancellationToken, Task<bool>>(this.ValidateEmailAsync)), "User with passed email already exists.");
      DefaultValidatorOptions.WithMessage<UserRegistrationModel, string>(DefaultValidatorExtensions.MustAsync<UserRegistrationModel, string>((IRuleBuilder<UserRegistrationModel, string>) DefaultValidatorExtensions.MaximumLength<UserRegistrationModel>((IRuleBuilder<UserRegistrationModel, string>) DefaultValidatorExtensions.NotEmpty<UserRegistrationModel, string>((IRuleBuilder<UserRegistrationModel, string>) DefaultValidatorOptions.Cascade<UserRegistrationModel, string>(this.RuleFor<string>((Expression<Func<UserRegistrationModel, string>>) (u => u.UserName)), (CascadeMode) 1)), 256), new Func<string, CancellationToken, Task<bool>>(this.ValidateUsernameAsync)), "User with passed username already exists.");
      DefaultValidatorExtensions.NotEmpty<UserRegistrationModel, string>((IRuleBuilder<UserRegistrationModel, string>) this.RuleFor<string>((Expression<Func<UserRegistrationModel, string>>) (u => u.Password)));
      DefaultValidatorExtensions.NotEmpty<UserRegistrationModel, int>((IRuleBuilder<UserRegistrationModel, int>) this.RuleFor<int>((Expression<Func<UserRegistrationModel, int>>) (u => u.CustomerId)));
    }

    private async Task<bool> ValidateEmailAsync(string email, CancellationToken arg2)
    {
      bool flag = await this.userService.ExistsByEmailAsync(email);
      return !flag;
    }

    private async Task<bool> ValidateUsernameAsync(string username, CancellationToken arg2)
    {
      bool flag = await this.userService.ExistsByUsernameAsync(username);
      return !flag;
    }
  }
}
