// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Assets.AssetResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Assets
{
  public class AssetResponseModel
  {
    public int AccountUnitID { get; set; }

    public int AssetTypeId { get; set; }

    public string AssetIdentifier { get; set; }

    public int Status { get; set; }

    public int OverallClassId { get; set; }

    public string TypeOfTransportId { get; set; }

    public DateTime ValidFromDate { get; set; }

    public DateTime? ValidToDate { get; set; }

    public string RelatedAssetIdentifier { get; set; }
  }
}
