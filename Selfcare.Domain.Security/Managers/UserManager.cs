// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Managers.UserManager
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Selfcare.Infrastructure.Entities.Persistence;
using System;
using System.Configuration;

#nullable disable
namespace Selfcare.Domain.Security.Managers
{
  public class UserManager : UserManager<User>
  {
    public UserManager(IUserStore<User> userStore)
      : base(userStore)
    {
      DpapiDataProtectionProvider protectionProvider = new DpapiDataProtectionProvider("Selfcare");
      ((UserManager<User, string>) this).PasswordValidator = (IIdentityValidator<string>) Utility.GetPasswordValidator();
      if (protectionProvider == null)
        return;
      IDataProtector idataProtector = protectionProvider.Create(new string[1]
      {
        "ASP.NET Identity"
      });
      int num = int.Parse(ConfigurationManager.AppSettings["ResetTokenExpiresInMinutes"]);
      DataProtectorTokenProvider<User> protectorTokenProvider = new DataProtectorTokenProvider<User>(idataProtector);
      ((DataProtectorTokenProvider<User, string>) protectorTokenProvider).TokenLifespan = TimeSpan.FromMinutes((double) num);
      ((UserManager<User, string>) this).UserTokenProvider = (IUserTokenProvider<User, string>) protectorTokenProvider;
    }
  }
}
