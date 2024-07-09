// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Assets.VehicleViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Assets
{
  public class VehicleViewModel
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
