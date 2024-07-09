// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.PointOfInterestService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.PointOfInterest;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  public class PointOfInterestService : IPointOfInterestService
  {
    private readonly IBackOfficeManager backOfficeManager;

    public PointOfInterestService(IBackOfficeManager backOfficeManager)
    {
      this.backOfficeManager = backOfficeManager;
    }

    public async Task<BackOfficeApiResult<IEnumerable<PoiViewData>>> GetPointOfInterestAsync()
    {
      BackOfficeApiResult<IEnumerable<PoiViewData>> pointOfInterests = await this.backOfficeManager.RetrievePointOfInterestsAsync();
      BackOfficeApiResult<IEnumerable<PoiViewData>> pointOfInterestAsync = pointOfInterests;
      pointOfInterests = (BackOfficeApiResult<IEnumerable<PoiViewData>>) null;
      return pointOfInterestAsync;
    }

    public async Task<BackOfficeApiResult<IEnumerable<PoiCategoryViewData>>> GetPointOfInterestCategoriesAsync()
    {
      BackOfficeApiResult<IEnumerable<PoiCategoryViewData>> pointOfInterstCategories = await this.backOfficeManager.RetrievePointOfInterestCategoriesAsync();
      BackOfficeApiResult<IEnumerable<PoiCategoryViewData>> interestCategoriesAsync = pointOfInterstCategories;
      pointOfInterstCategories = (BackOfficeApiResult<IEnumerable<PoiCategoryViewData>>) null;
      return interestCategoriesAsync;
    }

    public async Task<BackOfficeApiResult<IEnumerable<PoiServiceViewData>>> GetPointOfInterestServicesAsync()
    {
      BackOfficeApiResult<IEnumerable<PoiServiceViewData>> pointOfInterstServices = await this.backOfficeManager.RetrievePointOfInterestServicesAsync();
      BackOfficeApiResult<IEnumerable<PoiServiceViewData>> interestServicesAsync = pointOfInterstServices;
      pointOfInterstServices = (BackOfficeApiResult<IEnumerable<PoiServiceViewData>>) null;
      return interestServicesAsync;
    }
  }
}
