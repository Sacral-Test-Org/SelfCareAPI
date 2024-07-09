// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Managers.SignInManager
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Selfcare.Infrastructure.Entities.Persistence;

#nullable disable
namespace Selfcare.Domain.Security.Managers
{
  public class SignInManager : SignInManager<User, string>
  {
    public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
      : base((UserManager<User, string>) userManager, authenticationManager)
    {
    }
  }
}
