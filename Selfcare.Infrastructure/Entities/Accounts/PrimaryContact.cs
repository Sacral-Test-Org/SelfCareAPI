// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Accounts.PrimaryContact
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Accounts
{
  public class PrimaryContact
  {
    public string Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }

    public string PreferredContactMeansData { get; set; }

    public int PreferredContactMeansTypeId { get; set; }
  }
}
