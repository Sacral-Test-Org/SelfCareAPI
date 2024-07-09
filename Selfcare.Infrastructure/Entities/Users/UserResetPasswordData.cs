// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Users.UserResetPasswordData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Users
{
  public class UserResetPasswordData
  {
    public string UserId { get; set; }

    public string Code { get; set; }

    public string Password { get; set; }

    public string PasswordConfirm { get; set; }
  }
}
