// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Mappings.PointOfInterestProfile
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using AutoMapper;
using Selfcare.Domain.BackOffice.Models.PointOfInterest;
using Selfcare.Infrastructure.Entities.PointOfInterest;

#nullable disable
namespace Selfcare.Domain.BackOffice.Mappings
{
  internal class PointOfInterestProfile : Profile
  {
    public PointOfInterestProfile()
    {
      this.CreateMap<PoiResponseModel, PoiViewData>();
      this.CreateMap<PoiCategoryResponseModel, PoiCategoryViewData>();
      this.CreateMap<PoiServiceResponseModel, PoiServiceViewData>();
    }
  }
}
