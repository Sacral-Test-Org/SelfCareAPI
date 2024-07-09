// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.UserService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Microsoft.AspNet.Identity;
using Selfcare.Domain.Security.Managers;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.MailServer;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Entities.Users;
using Selfcare.Infrastructure.Services;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  public class UserService : IUserService
  {
    private readonly UserManager userManager;
    private readonly IBackOfficeManager backOfficeManager;
    private readonly IMailService mailServer;

    public UserService(
      UserManager userManager,
      IBackOfficeManager backOfficeManager,
      IMailService mailServer)
    {
      this.userManager = userManager;
      this.backOfficeManager = backOfficeManager;
      this.mailServer = mailServer;
    }

    public async Task CreateAsync(User user, string password)
    {
      IdentityResult async = await ((UserManager<User, string>) this.userManager).CreateAsync(user, password);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
      User user = await ((UserManager<User, string>) this.userManager).FindByEmailAsync(email);
      bool flag = user != null;
      user = (User) null;
      return flag;
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
      User user = await ((UserManager<User, string>) this.userManager).FindByNameAsync(username);
      bool flag = user != null;
      user = (User) null;
      return flag;
    }

    public async Task ChangePasswordAsync(string userId, string oldPassword, string newPassword)
    {
      IdentityResult identityResult = await ((UserManager<User, string>) this.userManager).ChangePasswordAsync(userId, oldPassword, newPassword);
    }

    public async Task<BackOfficeApiResult<UserViewData>> ValidateUserRegistrationAsync(
      UserRegistrationData registrationData)
    {
      BackOfficeApiResult<UserRegistrationValidationData> validationResult = await this.backOfficeManager.ValidateUserRegistrationAsync(registrationData.RegistrationCode, registrationData.Email);
      BackOfficeApiResult<UserViewData> result;
      if (validationResult.StatusCode == HttpStatusCode.OK)
      {
        if (validationResult.Data.IsValid)
        {
          result = await this.backOfficeManager.RetrieveUserCustomerDataAsync(validationResult.Data.UserCustomerId);
          result.Data.Email = registrationData.Email;
          result.Data.UserName = registrationData.Email;
        }
        else
          result = new BackOfficeApiResult<UserViewData>()
          {
            StatusCode = HttpStatusCode.BadRequest,
            ErrorMessage = "Registration data are not valid."
          };
      }
      else
        result = new BackOfficeApiResult<UserViewData>()
        {
          StatusCode = validationResult.StatusCode,
          ErrorMessage = validationResult.ErrorMessage
        };
      BackOfficeApiResult<UserViewData> backOfficeApiResult = result;
      result = (BackOfficeApiResult<UserViewData>) null;
      validationResult = (BackOfficeApiResult<UserRegistrationValidationData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<UserViewData>> RetrieveCustomerDataAsync(string username)
    {
      User user = await ((UserManager<User, string>) this.userManager).FindByNameAsync(username);
      BackOfficeApiResult<UserViewData> result = await this.backOfficeManager.RetrieveUserCustomerDataAsync(user.CustomerId);
      result.Data.Email = user.Email;
      result.Data.UserName = user.UserName;
      BackOfficeApiResult<UserViewData> backOfficeApiResult = result;
      user = (User) null;
      result = (BackOfficeApiResult<UserViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<bool> ExistsByUsernameAndPasswordAsync(string username, string password)
    {
      User user = await ((UserManager<User, string>) this.userManager).FindAsync(username, password);
      bool flag = user != null;
      user = (User) null;
      return flag;
    }

    public async Task<MailServerResponse> GenerateResetPasswordTokenAsync(string email)
    {
      User user = UserManagerExtensions.FindByEmail<User, string>((UserManager<User, string>) this.userManager, email);
      string callbackUrl = string.Empty;
      if (user != null)
      {
        string resetToken = await ((UserManager<User, string>) this.userManager).GeneratePasswordResetTokenAsync(user.Id);
        callbackUrl = ConfigurationManager.AppSettings["ResetPasswordBaseUrl"] + "?userid=" + user.Id + "&code=" + resetToken;
        resetToken = (string) null;
      }
      MailServerResponse smtpResponse = await this.mailServer.SendResetPasswordEmail(email, callbackUrl);
      MailServerResponse passwordTokenAsync = smtpResponse;
      user = (User) null;
      callbackUrl = (string) null;
      smtpResponse = (MailServerResponse) null;
      return passwordTokenAsync;
    }

    public async Task<IdentityResult> ResetPasswordAsync(UserResetPasswordData resetPasswordData)
    {
      IdentityResult identityResult = await ((UserManager<User, string>) this.userManager).ResetPasswordAsync(resetPasswordData.UserId, resetPasswordData.Code, resetPasswordData.Password);
      return identityResult;
    }
  }
}
