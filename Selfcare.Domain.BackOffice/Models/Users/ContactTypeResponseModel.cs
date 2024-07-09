// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Users.ContactTypeResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Users
{
  public class ContactTypeResponseModel
  {
    public string Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => this.FirstName + " " + this.LastName;

    public int PreferredContactMeansTypeId { get; set; }

    public string PreferredContactMeansData { get; set; }
  }
}
