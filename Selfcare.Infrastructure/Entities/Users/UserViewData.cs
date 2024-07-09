// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Users.UserViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Users
{
  public class UserViewData
  {
    public int Id { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public int CustomerCode { get; set; }

    public int CustomerTypeId { get; set; }

    public string Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string CompanyName { get; set; }

    public string TradingName { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }
  }
}
