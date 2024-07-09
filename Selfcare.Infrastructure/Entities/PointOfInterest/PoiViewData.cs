// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.PointOfInterest.PoiViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System.Collections.Generic;

#nullable disable
namespace Selfcare.Infrastructure.Entities.PointOfInterest
{
  public class PoiViewData
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

    public PoiCategoryViewData Category { get; set; }

    public IEnumerable<PoiServiceViewData> Services { get; set; }
  }
}
