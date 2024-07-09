// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.PointOfInterest.PoiResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System.Collections.Generic;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.PointOfInterest
{
  public class PoiResponseModel
  {
    public int Id { get; set; }

    public string TitleEn { get; set; }

    public string TitleAr { get; set; }

    public string TitleUr { get; set; }

    public string DescriptionEn { get; set; }

    public string DescriptionAr { get; set; }

    public string DescriptionUr { get; set; }

    public string AddressEn { get; set; }

    public string AddressAr { get; set; }

    public string AddressUr { get; set; }

    public bool ShowTiming1 { get; set; }

    public bool ShowTiming2 { get; set; }

    public bool ShowTiming3 { get; set; }

    public string Timing1En { get; set; }

    public string Timing1Ar { get; set; }

    public string Timing1Ur { get; set; }

    public string Timing2En { get; set; }

    public string Timing2Ar { get; set; }

    public string Timing2Ur { get; set; }

    public string Timing3En { get; set; }

    public string Timing3Ar { get; set; }

    public string Timing3Ur { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public float Longitude { get; set; }

    public float latitude { get; set; }

    public PoiCategoryResponseModel Category { get; set; }

    public IEnumerable<PoiServiceResponseModel> Services { get; set; }
  }
}
