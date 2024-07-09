// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Assets.VehicleResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Assets
{
  public class VehicleResponseModel
  {
    public string CountryCode { get; set; }

    public string State { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }

    public string Color { get; set; }

    public string TypeOfTransportId { get; set; }

    public Decimal UnloadedWeight { get; set; }
  }
}
