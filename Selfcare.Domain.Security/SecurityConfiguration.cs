// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.SecurityConfiguration
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Selfcare.Domain.Security.Providers;
using Selfcare.Infrastructure.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using System;
using System.Configuration;

#nullable disable
namespace Selfcare.Domain.Security
{
  public static class SecurityConfiguration
  {
    public static OAuthAuthorizationServerOptions GetOAuthAuthorizationServerOptions(
      ISqlConnectionFactory sqlConnectionFactory,
      IRefreshTokenRepository refreshTokenRepository)
    {
      return new OAuthAuthorizationServerOptions()
      {
        TokenEndpointPath = new PathString(ConfigurationManager.AppSettings["TokenUrlPath"]),
        Provider = (IOAuthAuthorizationServerProvider) new TokenAuthenticationServiceProviders(),
        RefreshTokenProvider = (IAuthenticationTokenProvider) new RefreshTokenProvider(sqlConnectionFactory, refreshTokenRepository),
        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes((double) int.Parse(ConfigurationManager.AppSettings["AccessTokenExpireInMinutes"])),
        AllowInsecureHttp = true
      };
    }
  }
}
