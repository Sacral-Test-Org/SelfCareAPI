// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Services.IUserService
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Microsoft.AspNet.Identity;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.MailServer;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Entities.Users;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.Services
{
  public interface IUserService
  {
    Task<BackOfficeApiResult<UserViewData>> ValidateUserRegistrationAsync(
      UserRegistrationData registrationData);

    Task CreateAsync(User user, string password);

    Task<bool> ExistsByEmailAsync(string email);

    Task<bool> ExistsByUsernameAsync(string username);

    Task<bool> ExistsByUsernameAndPasswordAsync(string username, string password);

    Task ChangePasswordAsync(string username, string oldPassword, string newPassword);

    Task<BackOfficeApiResult<UserViewData>> RetrieveCustomerDataAsync(string username);

    Task<MailServerResponse> GenerateResetPasswordTokenAsync(string email);

    Task<IdentityResult> ResetPasswordAsync(UserResetPasswordData resetPasswordData);
  }
}
