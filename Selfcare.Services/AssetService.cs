// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.AssetService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Assets;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  public class AssetService : IAssetService
  {
    private readonly IBackOfficeManager backOfficeManager;

    public AssetService(IBackOfficeManager backOfficeManager)
    {
      this.backOfficeManager = backOfficeManager;
    }

    protected static IEnumerable<T> GetItemsFromList<T>(List<T> listOfItems)
    {
      return (IEnumerable<T>) listOfItems.OfType<T>().ToList<T>();
    }

    public async Task<BackOfficeApiResult<IEnumerable<AssetViewData>>> RetrieveAssetsAsync(
      AssetsRetrieveParameters retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<AssetViewData>> accountInfo = await this.backOfficeManager.RetrieveAssetsAsync(retrieveParameters);
      BackOfficeApiResult<IEnumerable<AssetViewData>> backOfficeApiResult = accountInfo;
      accountInfo = (BackOfficeApiResult<IEnumerable<AssetViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AssetDetailsViewData>> RetrieveAssetDetailsAsync(
      int accountUnitId)
    {
      BackOfficeApiResult<AssetDetailsViewData> assetDetails = await this.backOfficeManager.RetrieveAssetDetailsAsync(accountUnitId);
      BackOfficeApiResult<AssetDetailsViewData> backOfficeApiResult = assetDetails;
      assetDetails = (BackOfficeApiResult<AssetDetailsViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AssetDetailsViewData>>> RetrieveFilteredAssetsListAsync(
      AssetsFilterParameters retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<AssetDetailsViewData>> assetsDetailsList = await this.backOfficeManager.RetrieveFilteredAssetsListAsync(retrieveParameters);
      BackOfficeApiResult<IEnumerable<AssetDetailsViewData>> backOfficeApiResult = assetsDetailsList;
      assetsDetailsList = (BackOfficeApiResult<IEnumerable<AssetDetailsViewData>>) null;
      return backOfficeApiResult;
    }
  }
}
