// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.CaseController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Microsoft.AspNet.Identity;
using Selfcare.Api.Attributes;
using Selfcare.Api.Models.Case;
using Selfcare.Domain.Security.Managers;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Case;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class CaseController : AdminController
  {
    private readonly ICaseService caseService;
    private readonly UserManager userManager;

    public CaseController(ICaseService caseService, UserManager userManager)
    {
      this.caseService = caseService;
      this.userManager = userManager;
    }

    [HttpPost]
    [Route("cases")]
    [ModelValidation]
    public async Task<HttpResponseMessage> CreateCase(CaseCreateModel caseModel)
    {
      CaseCreateData caseData = this.mapper.Map<CaseCreateData>((object) caseModel);
      string username = IdentityExtensions.GetUserName(this.User.Identity);
      User user = await ((UserManager<User, string>) this.userManager).FindByNameAsync(username);
      caseData.CustomerId = user.CustomerId;
      BackOfficeApiResult<CreateCaseViewData> viewData = await this.caseService.CreateCaseAsync(caseData);
      return this.GenerateResponseMessage<CreateCaseViewData, CreateCaseViewModel>(viewData);
    }

    [HttpPost]
    [Route("cases/customer/account")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveCases(
      CasesRetrieveParametersModel retrieveParametersModel)
    {
      CasesRetrieveParameters retrieveParameters = this.mapper.Map<CasesRetrieveParameters>((object) retrieveParametersModel);
      string username = IdentityExtensions.GetUserName(this.User.Identity);
      User user = await ((UserManager<User, string>) this.userManager).FindByNameAsync(username);
      retrieveParameters.CustomerId = user.CustomerId;
      BackOfficeApiResult<IEnumerable<CaseViewData>> viewData = await this.caseService.RetrieveCasesAsync(retrieveParameters);
      return this.GenerateResponseMessage<IEnumerable<CaseViewData>, IEnumerable<CaseViewModel>>(viewData);
    }
  }
}
