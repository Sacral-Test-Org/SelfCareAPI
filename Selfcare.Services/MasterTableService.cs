// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.MasterTableService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.MasterTable;
using Selfcare.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  internal class MasterTableService : BaseService, IMasterTableService
  {
    private readonly IBackOfficeManager backOfficeManager;

    public MasterTableService(IBackOfficeManager backOfficeManager)
    {
      this.backOfficeManager = backOfficeManager;
    }

    public async Task<BackOfficeApiResult<MasterTableRootViewData>> RetrieveMasterTableData(
      string tableName)
    {
      BackOfficeApiResult<MasterTableRootViewData> masterTableData = await this.backOfficeManager.RetrieveMasterTableData(tableName);
      BackOfficeApiResult<MasterTableRootViewData> backOfficeApiResult = masterTableData;
      masterTableData = (BackOfficeApiResult<MasterTableRootViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<PlateViewData>>> RetrievePlateData(
      string tableName,
      string region)
    {
      BackOfficeApiResult<MasterTableRootViewData> masterTableData = await this.backOfficeManager.RetrieveMasterTableData(tableName);
      BackOfficeApiResult<IEnumerable<PlateViewData>> platesList = new BackOfficeApiResult<IEnumerable<PlateViewData>>();
      IEnumerable<MasterTableViewData> tempCategories = (IEnumerable<MasterTableViewData>) new List<MasterTableViewData>();
      IEnumerable<MasterTableViewData> tempNoCategories = (IEnumerable<MasterTableViewData>) new List<MasterTableViewData>();
      List<PlateViewData> plateResult = new List<PlateViewData>();
      tempCategories = (IEnumerable<MasterTableViewData>) masterTableData.Data.Items.ToList<MasterTableViewData>().Where<MasterTableViewData>((Func<MasterTableViewData, bool>) (x => x.ItemName.Contains("-") && x.AdditionalData == region)).ToList<MasterTableViewData>();
      tempNoCategories = (IEnumerable<MasterTableViewData>) masterTableData.Data.Items.ToList<MasterTableViewData>().Where<MasterTableViewData>((Func<MasterTableViewData, bool>) (x => !x.ItemName.Contains("-") && x.AdditionalData == region)).ToList<MasterTableViewData>();
      PlateViewData item = new PlateViewData();
      item.Id = 0;
      item.Description = "Private";
      for (int i = 0; i < tempCategories.Count<MasterTableViewData>(); ++i)
      {
        int id = tempCategories.ToList<MasterTableViewData>()[i].ItemId;
        string plateName = tempCategories.ToList<MasterTableViewData>()[i].ItemName;
        PlateTypeViewData itemCategory = new PlateTypeViewData()
        {
          Id = id,
          Description = plateName.Substring(plateName.IndexOf("-") + 1)
        };
        item.addPlateType(itemCategory);
        plateName = (string) null;
        itemCategory = (PlateTypeViewData) null;
      }
      plateResult.Add(item);
      for (int i = 0; i < tempNoCategories.Count<MasterTableViewData>(); ++i)
      {
        PlateViewData plate = new PlateViewData();
        int id = tempNoCategories.ToList<MasterTableViewData>()[i].ItemId;
        string plateName = tempNoCategories.ToList<MasterTableViewData>()[i].ItemName;
        plate.Id = id;
        plate.Description = plateName;
        plateResult.Add(plate);
        plate = (PlateViewData) null;
        plateName = (string) null;
      }
      IEnumerable<PlateViewData> plates = BaseService.GetItemsFromList<PlateViewData>(plateResult);
      platesList.Data = plates;
      platesList.StatusCode = masterTableData.StatusCode;
      platesList.ErrorMessage = masterTableData.ErrorMessage;
      BackOfficeApiResult<IEnumerable<PlateViewData>> backOfficeApiResult = platesList;
      masterTableData = (BackOfficeApiResult<MasterTableRootViewData>) null;
      platesList = (BackOfficeApiResult<IEnumerable<PlateViewData>>) null;
      tempCategories = (IEnumerable<MasterTableViewData>) null;
      tempNoCategories = (IEnumerable<MasterTableViewData>) null;
      plateResult = (List<PlateViewData>) null;
      item = (PlateViewData) null;
      plates = (IEnumerable<PlateViewData>) null;
      return backOfficeApiResult;
    }
  }
}
