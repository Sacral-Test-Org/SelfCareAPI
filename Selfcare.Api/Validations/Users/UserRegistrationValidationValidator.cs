// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Users.UserRegistrationValidationValidator
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
  public class UserRegistrationValidationValidator : 
    AbstractValidator<UserRegistrationValidationModel>
  {
    private readonly IUserService userService;

    public UserRegistrationValidationValidator(IUserService userService)
    {
      this.userService = userService;
      DefaultValidatorExtensions.NotEmpty<UserRegistrationValidationModel, string>((IRuleBuilder<UserRegistrationValidationModel, string>) this.RuleFor<string>((Expression<Func<UserRegistrationValidationModel, string>>) (urd => urd.RegistrationCode)));
      DefaultValidatorOptions.WithMessage<UserRegistrationValidationModel, string>(DefaultValidatorExtensions.MustAsync<UserRegistrationValidationModel, string>((IRuleBuilder<UserRegistrationValidationModel, string>) DefaultValidatorExtensions.EmailAddress<UserRegistrationValidationModel>((IRuleBuilder<UserRegistrationValidationModel, string>) DefaultValidatorExtensions.NotEmpty<UserRegistrationValidationModel, string>((IRuleBuilder<UserRegistrationValidationModel, string>) DefaultValidatorOptions.Cascade<UserRegistrationValidationModel, string>(this.RuleFor<string>((Expression<Func<UserRegistrationValidationModel, string>>) (urd => urd.Email)), (CascadeMode) 1))), new Func<string, CancellationToken, Task<bool>>(this.ValidateEmailAsync)), "User with passed email already exists.");
    }

    private async Task<bool> ValidateEmailAsync(string email, CancellationToken cancellationToken)
    {
      bool flag = await this.userService.ExistsByEmailAsync(email);
      return !flag;
    }
  }
}
