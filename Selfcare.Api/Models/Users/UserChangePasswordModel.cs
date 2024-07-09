// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Users.UserChangePasswordModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

#nullable disable
namespace Selfcare.Api.Models.Users
{
  public class UserChangePasswordModel
  {
    public string CurrentPassword { get; set; }

    public string NewPassword { get; set; }

    public string NewPasswordConfirmed { get; set; }
  }
}
