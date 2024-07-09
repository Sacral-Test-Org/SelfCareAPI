// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.PoiController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Selfcare.Api.Models.PointOfInterest;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.PointOfInterest;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class PoiController : BaseController
  {
    private readonly IPointOfInterestService poiService;

    public PoiController(IPointOfInterestService poiService) => this.poiService = poiService;

    [HttpGet]
    [Route("pois/")]
    public async Task<HttpResponseMessage> RetrievePois()
    {
      BackOfficeApiResult<IEnumerable<PoiViewData>> pois = await this.poiService.GetPointOfInterestAsync();
      return this.GenerateResponseMessage<IEnumerable<PoiViewData>, IEnumerable<PoiViewModel>>(pois);
    }

    [HttpGet]
    [Route("pois/categories/")]
    public async Task<HttpResponseMessage> RetrievePoiCategories()
    {
      BackOfficeApiResult<IEnumerable<PoiCategoryViewData>> poiCategories = await this.poiService.GetPointOfInterestCategoriesAsync();
      return this.GenerateResponseMessage<IEnumerable<PoiCategoryViewData>, IEnumerable<PoiCategoryViewModel>>(poiCategories);
    }

    [HttpGet]
    [Route("pois/services/")]
    public async Task<HttpResponseMessage> RetrievePoiServices()
    {
      BackOfficeApiResult<IEnumerable<PoiServiceViewData>> poiServices = await this.poiService.GetPointOfInterestServicesAsync();
      return this.GenerateResponseMessage<IEnumerable<PoiServiceViewData>, IEnumerable<PoiServiceViewModel>>(poiServices);
    }
  }
}
