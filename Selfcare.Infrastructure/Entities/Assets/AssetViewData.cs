// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Assets.AssetViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Assets
{
  public class AssetViewData
  {
    public int AccountUnitId { get; set; }

    public int AssetTypeId { get; set; }

    public string AssetIdentifier { get; set; }

    public int Status { get; set; }

    public int OverallClassId { get; set; }

    public string TypeOfTransportId { get; set; }

    public DateTime ValidFromDate { get; set; }

    public DateTime? ValidToDate { get; set; }

    public VehicleViewData Vehicle { get; set; }

    public string RelatedAssetIdentifier { get; set; }
  }
}
