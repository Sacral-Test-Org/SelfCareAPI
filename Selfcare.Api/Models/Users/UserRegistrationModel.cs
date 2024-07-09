// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Users.UserRegistrationModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

#nullable disable
namespace Selfcare.Api.Models.Users
{
  public class UserRegistrationModel
  {
    public string Email { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public int CustomerId { get; set; }
  }
}
