// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.PointOfInterest.PoiViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System.Collections.Generic;

#nullable disable
namespace Selfcare.Api.Models.PointOfInterest
{
  public class PoiViewModel
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

    public float Latitude { get; set; }

    public PoiCategoryViewModel Category { get; set; }

    public IEnumerable<PoiServiceViewModel> Services { get; set; }
  }
}
