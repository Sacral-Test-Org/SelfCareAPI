// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.MasterTableController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Selfcare.Api.Attributes;
using Selfcare.Api.Models.MasterTable;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.MasterTable;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class MasterTableController : AdminController
  {
    private readonly IMasterTableService masterService;

    public MasterTableController(IMasterTableService masterService)
    {
      this.masterService = masterService;
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("mastertables/{tableName}")]
    public async Task<HttpResponseMessage> GetMasterTableData(string tableName)
    {
      BackOfficeApiResult<MasterTableRootViewData> tableData = await this.masterService.RetrieveMasterTableData(tableName);
      return this.GenerateMasterTableResponseMessage(tableData);
    }

    [HttpPost]
    [AllowAnonymous]
    [ModelValidation]
    [Route("mastertables/platetypecategory")]
    public async Task<HttpResponseMessage> GetPlateTypeCategoryData(
      PlateTypeCategoryRetrieveParametersModel emirate)
    {
      string tableName = "PlateTypes";
      BackOfficeApiResult<IEnumerable<PlateViewData>> tableData = await this.masterService.RetrievePlateData(tableName, emirate.RegionName);
      return this.GenerateResponseMessage<IEnumerable<PlateViewData>, IEnumerable<PlateViewModel>>(tableData);
    }

    protected HttpResponseMessage GenerateMasterTableResponseMessage(
      BackOfficeApiResult<MasterTableRootViewData> apiResult)
    {
      return apiResult.StatusCode != HttpStatusCode.OK && apiResult.StatusCode != HttpStatusCode.Created ? HttpRequestMessageExtensions.CreateResponse<string>(this.Request, apiResult.StatusCode, apiResult.ErrorMessage, "application/json") : HttpRequestMessageExtensions.CreateResponse<IEnumerable<MasterTableViewModel>>(this.Request, HttpStatusCode.OK, this.mapper.Map<IEnumerable<MasterTableViewModel>>((object) apiResult.Data.Items), "application/json");
    }
  }
}
