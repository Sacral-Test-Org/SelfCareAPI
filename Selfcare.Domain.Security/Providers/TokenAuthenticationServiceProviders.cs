// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Providers.TokenAuthenticationServiceProviders
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Provider;
using Selfcare.Domain.Security.Managers;
using Selfcare.Infrastructure.Entities.Persistence;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Domain.Security.Providers
{
  public class TokenAuthenticationServiceProviders : OAuthAuthorizationServerProvider
  {
    public virtual Task ValidateClientAuthentication(
      OAuthValidateClientAuthenticationContext context)
    {
      ((BaseContext<OAuthAuthorizationServerOptions>) context).OwinContext.Set<string>("refreshTokenLifeTimeInMinutes", ConfigurationManager.AppSettings["RefreshTokenExpiresInMinutes"]);
      ((BaseValidatingContext<OAuthAuthorizationServerOptions>) context).Validated();
      return Task.CompletedTask;
    }

    public virtual async Task GrantResourceOwnerCredentials(
      OAuthGrantResourceOwnerCredentialsContext context)
    {
      SignInManager signInManager = OwinContextExtensions.Get<SignInManager>(((BaseContext<OAuthAuthorizationServerOptions>) context).OwinContext);
      User user = await signInManager.UserManager.FindAsync(context.UserName, context.Password);
      if (user != null)
      {
        ClaimsIdentity userClaimsIdentity = await signInManager.UserManager.CreateIdentityAsync(user, "ExternalBearer");
        ((BaseValidatingTicketContext<OAuthAuthorizationServerOptions>) context).Validated(userClaimsIdentity);
        userClaimsIdentity = (ClaimsIdentity) null;
        signInManager = (SignInManager) null;
        user = (User) null;
      }
      else
      {
        ((BaseValidatingContext<OAuthAuthorizationServerOptions>) context).SetError("invalid_grant", "The username or password is incorect");
        signInManager = (SignInManager) null;
        user = (User) null;
      }
    }

    public virtual Task TokenEndpoint(OAuthTokenEndpointContext context)
    {
      foreach (KeyValuePair<string, string> keyValuePair in (IEnumerable<KeyValuePair<string, string>>) context.Properties.Dictionary)
        context.AdditionalResponseParameters.Add(keyValuePair.Key, (object) keyValuePair.Value);
      return (Task) Task.FromResult<int>(0);
    }

    public virtual Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
    {
      ((BaseValidatingTicketContext<OAuthAuthorizationServerOptions>) context).Validated(((BaseValidatingTicketContext<OAuthAuthorizationServerOptions>) context).Ticket);
      return (Task) Task.FromResult<int>(0);
    }
  }
}
