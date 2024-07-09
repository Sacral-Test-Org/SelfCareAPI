// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Accounts.AnonymousTransactionsRetrieveParametersModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Accounts
{
  public class AnonymousTransactionsRetrieveParametersModel
  {
    public int CountryId { get; set; }

    public int RegionId { get; set; }

    public int PlateTypeCodeId { get; set; }

    public string LicensePlateNumber { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }
  }
}
