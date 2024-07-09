// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Users.UserViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

#nullable disable
namespace Selfcare.Api.Models.Users
{
  public class UserViewModel
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
