// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.FAQController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Selfcare.Api.Models.FAQ;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.FAQ;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class FAQController : BaseController
  {
    private readonly IFAQService faqService;

    public FAQController(IFAQService faqService) => this.faqService = faqService;

    [HttpGet]
    [Route("faqs/")]
    public async Task<HttpResponseMessage> RetrieveFAQs()
    {
      BackOfficeApiResult<IEnumerable<FAQViewData>> faqs = await this.faqService.GetFAQAsync();
      return this.GenerateResponseMessage<IEnumerable<FAQViewData>, IEnumerable<FAQViewModel>>(faqs);
    }

    [HttpGet]
    [Route("faqs/categories/")]
    public async Task<HttpResponseMessage> RetrieveFAQCategories()
    {
      BackOfficeApiResult<IEnumerable<FAQCategoryViewData>> faqCategories = await this.faqService.GetFAQCategoriesAsync();
      return this.GenerateResponseMessage<IEnumerable<FAQCategoryViewData>, IEnumerable<FAQCategoryViewModel>>(faqCategories);
    }
  }
}
