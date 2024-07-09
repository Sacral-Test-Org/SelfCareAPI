// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.AssetController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using AutoMapper;
using Selfcare.Api.Attributes;
using Selfcare.Api.Mappings;
using Selfcare.Api.Models.Assets;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Assets;
using Selfcare.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class AssetController : AdminController
  {
    private readonly IAssetService assetService;

    public AssetController(IAssetService assetService) => this.assetService = assetService;

    private IMapper GenerateMapper()
    {
      return new MapperConfiguration((Action<IMapperConfigurationExpression>) (cfg => cfg.AddProfile<AssetProfile>())).CreateMapper();
    }

    [HttpPost]
    [Route("assets/account")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAssets(
      AssetsRetrieveParametersModel retrieveParametersModel)
    {
      AssetsRetrieveParameters retrieveParameters = this.mapper.Map<AssetsRetrieveParameters>((object) retrieveParametersModel);
      BackOfficeApiResult<IEnumerable<AssetViewData>> assetsResult = await this.assetService.RetrieveAssetsAsync(retrieveParameters);
      return this.GenerateResponseMessage<IEnumerable<AssetViewData>, IEnumerable<AssetViewModel>>(assetsResult);
    }

    [HttpPost]
    [Route("assets/details")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveFilteredAssets(
      AssetsFilterParametersModel assetsFilterParametersModel)
    {
      AssetsFilterParameters retrieveParameters = this.mapper.Map<AssetsFilterParameters>((object) assetsFilterParametersModel);
      BackOfficeApiResult<IEnumerable<AssetDetailsViewData>> assetResult = await this.assetService.RetrieveFilteredAssetsListAsync(retrieveParameters);
      return this.GenerateResponseMessage<IEnumerable<AssetDetailsViewData>, IEnumerable<AssetDetailsViewModel>>(assetResult);
    }
  }
}
