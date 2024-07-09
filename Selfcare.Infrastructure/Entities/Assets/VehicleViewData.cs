// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Assets.VehicleViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Assets
{
  public class VehicleViewData
  {
    public string CountryCode { get; set; }

    public string State { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }

    public string Color { get; set; }

    public int TypeOfTransportId { get; set; }

    public Decimal UnloadedWeight { get; set; }
  }
}
