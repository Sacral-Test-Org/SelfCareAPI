// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.LoginController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Selfcare.Api.Attributes;
using Selfcare.Api.Models.Login;
using Selfcare.Infrastructure.Entities;
using Selfcare.Infrastructure.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class LoginController : BaseController
  {
    private readonly ILoginService loginService;

    public LoginController(ILoginService loginService) => this.loginService = loginService;

    [HttpPost]
    [Route("login")]
    [ModelValidation]
    public async Task<HttpResponseMessage> Login(LoginModel loginModel)
    {
      TokenData tokenData = await this.loginService.LoginAsync(loginModel.Username, loginModel.Password);
      HttpResponseMessage response = !tokenData.IsValid ? HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.Unauthorized, "Invalid username or password", "application/json") : HttpRequestMessageExtensions.CreateResponse<TokenData>(this.Request, HttpStatusCode.OK, tokenData, "application/json");
      return response;
    }

    [HttpPost]
    [Route("login/refresh")]
    [ModelValidation]
    public async Task<HttpResponseMessage> LoginRefresh(LoginRefreshModel loginRefreshModel)
    {
      TokenData tokenData = await this.loginService.LoginRefreshAsync(loginRefreshModel.RefreshToken);
      HttpStatusCode statusCode = tokenData.IsValid ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
      return HttpRequestMessageExtensions.CreateResponse<TokenData>(this.Request, statusCode, tokenData, "application/json");
    }
  }
}
