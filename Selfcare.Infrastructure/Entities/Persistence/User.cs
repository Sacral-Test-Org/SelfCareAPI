// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Persistence.User
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Microsoft.AspNet.Identity;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Persistence
{
  public class User : IUser, IUser<string>
  {
    public string Id { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public int CustomerId { get; set; }
  }
}
