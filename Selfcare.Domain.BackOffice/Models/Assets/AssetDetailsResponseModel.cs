// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Assets.AssetDetailsResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Assets
{
  public class AssetDetailsResponseModel
  {
    public string Identifier { get; set; }

    public int AssetTypeId { get; set; }

    public int AccountUnitStatus { get; set; }

    public int Class { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public VehicleResponseModel Vehicle { get; set; }
  }
}
