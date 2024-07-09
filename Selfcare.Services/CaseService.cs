// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.CaseService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Case;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  internal class CaseService : ICaseService
  {
    private readonly IBackOfficeManager backOfficeManager;

    public CaseService(IBackOfficeManager backOfficeManager)
    {
      this.backOfficeManager = backOfficeManager;
    }

    public async Task<BackOfficeApiResult<CreateCaseViewData>> CreateCaseAsync(
      CaseCreateData caseData)
    {
      BackOfficeApiResult<CreateCaseViewData> result = await this.backOfficeManager.CreateCaseAsync(caseData);
      BackOfficeApiResult<CreateCaseViewData> caseAsync = result;
      result = (BackOfficeApiResult<CreateCaseViewData>) null;
      return caseAsync;
    }

    public async Task<BackOfficeApiResult<IEnumerable<CaseViewData>>> RetrieveCasesAsync(
      CasesRetrieveParameters retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<CaseViewData>> result = await this.backOfficeManager.RetrieveCasesAsync(retrieveParameters);
      BackOfficeApiResult<IEnumerable<CaseViewData>> backOfficeApiResult = result;
      result = (BackOfficeApiResult<IEnumerable<CaseViewData>>) null;
      return backOfficeApiResult;
    }
  }
}
