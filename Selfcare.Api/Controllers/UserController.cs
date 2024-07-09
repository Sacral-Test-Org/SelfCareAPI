// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.UserController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Microsoft.AspNet.Identity;
using Selfcare.Api.Attributes;
using Selfcare.Api.Models.Users;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.MailServer;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Entities.Users;
using Selfcare.Infrastructure.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class UserController : AdminController
  {
    private readonly IUserService userService;

    public UserController(IUserService userService) => this.userService = userService;

    [HttpPost]
    [Route("users/validateregistration")]
    [AllowAnonymous]
    [ModelValidation]
    public async Task<HttpResponseMessage> ValidateUserRegistrationData(
      UserRegistrationValidationModel registrationDataModel)
    {
      UserRegistrationData registrationData = this.mapper.Map<UserRegistrationData>((object) registrationDataModel);
      BackOfficeApiResult<UserViewData> validationResult = await this.userService.ValidateUserRegistrationAsync(registrationData);
      return this.GenerateResponseMessage<UserViewData, UserViewModel>(validationResult);
    }

    [HttpPost]
    [Route("users/registration")]
    [AllowAnonymous]
    [ModelValidation]
    public async Task<HttpResponseMessage> RegistrateUser(UserRegistrationModel userCreateModel)
    {
      User userRegistrationData = this.mapper.Map<User>((object) userCreateModel);
      await this.userService.CreateAsync(userRegistrationData, userCreateModel.Password);
      return HttpRequestMessageExtensions.CreateResponse(this.Request, HttpStatusCode.OK);
    }

    [HttpGet]
    [Route("users/info")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveCustomerData()
    {
      string username = IdentityExtensions.GetUserName(this.User.Identity);
      BackOfficeApiResult<UserViewData> validationResult = await this.userService.RetrieveCustomerDataAsync(username);
      return this.GenerateResponseMessage<UserViewData, UserViewModel>(validationResult);
    }

    [HttpPost]
    [Route("users/changepassword")]
    [ModelValidation]
    public async Task<HttpResponseMessage> ChangePassword(
      UserChangePasswordModel userChangePasswordModel)
    {
      string username = this.User.Identity.Name;
      HttpResponseMessage response;
      if (await this.userService.ExistsByUsernameAndPasswordAsync(username, userChangePasswordModel.CurrentPassword))
      {
        string userId = IdentityExtensions.GetUserId(this.User.Identity);
        await this.userService.ChangePasswordAsync(userId, userChangePasswordModel.CurrentPassword, userChangePasswordModel.NewPassword);
        response = HttpRequestMessageExtensions.CreateResponse(this.Request, HttpStatusCode.OK);
        userId = (string) null;
      }
      else
        response = HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.BadRequest, "Invalid current password.", "application/json");
      return response;
    }

    [HttpPost]
    [Route("users/forgotpassword")]
    [ModelValidation]
    [AllowAnonymous]
    public async Task<HttpResponseMessage> ForgotPassword(
      UserForgotPasswordModel userForgotPasswordModel)
    {
      HttpResponseMessage response;
      if (await this.userService.ExistsByEmailAsync(userForgotPasswordModel.Email))
      {
        MailServerResponse smtpResponse = await this.userService.GenerateResetPasswordTokenAsync(userForgotPasswordModel.Email);
        response = !smtpResponse.IsSuccessfull ? HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.BadRequest, smtpResponse.ResponseMessage, "application/json") : HttpRequestMessageExtensions.CreateResponse(this.Request, HttpStatusCode.OK);
        smtpResponse = (MailServerResponse) null;
      }
      else
        response = HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.BadRequest, "Invalid email address.", "application/json");
      return response;
    }

    [HttpPost]
    [Route("users/resetpassword")]
    [ModelValidation]
    [AllowAnonymous]
    public async Task<HttpResponseMessage> ResetPassword(
      UserResetPasswordModel userResetPasswordModel)
    {
      UserResetPasswordData resetPasswordData = this.mapper.Map<UserResetPasswordData>((object) userResetPasswordModel);
      IdentityResult result = await this.userService.ResetPasswordAsync(resetPasswordData);
      HttpResponseMessage response = !result.Succeeded ? HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.BadRequest, result.Errors.First<string>().ToString(), "application/json") : HttpRequestMessageExtensions.CreateResponse(this.Request, HttpStatusCode.OK);
      return response;
    }
  }
}
