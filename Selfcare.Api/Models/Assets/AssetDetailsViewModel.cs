// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Assets.AssetDetailsViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Assets
{
  public class AssetDetailsViewModel
  {
    public string AssetIdentifier { get; set; }

    public int AssetTypeId { get; set; }

    public int AccountUnitId { get; set; }

    public int StatusId { get; set; }

    public int OverallClassId { get; set; }

    public DateTime ValidFromDate { get; set; }

    public DateTime? ValidToDate { get; set; }

    public VehicleViewModel Vehicle { get; set; }

    public string RelatedAssetIdentifier { get; set; }
  }
}
