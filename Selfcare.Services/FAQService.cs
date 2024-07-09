// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.FAQService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.FAQ;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  public class FAQService : IFAQService
  {
    private readonly IBackOfficeManager backOfficeManager;

    public FAQService(IBackOfficeManager backOfficeManager)
    {
      this.backOfficeManager = backOfficeManager;
    }

    public async Task<BackOfficeApiResult<IEnumerable<FAQViewData>>> GetFAQAsync()
    {
      BackOfficeApiResult<IEnumerable<FAQViewData>> faqs = await this.backOfficeManager.RetrieveFaqsAsync();
      BackOfficeApiResult<IEnumerable<FAQViewData>> faqAsync = faqs;
      faqs = (BackOfficeApiResult<IEnumerable<FAQViewData>>) null;
      return faqAsync;
    }

    public async Task<BackOfficeApiResult<IEnumerable<FAQCategoryViewData>>> GetFAQCategoriesAsync()
    {
      BackOfficeApiResult<IEnumerable<FAQCategoryViewData>> faqCategories = await this.backOfficeManager.RetrieveFaqCategoriesAsync();
      BackOfficeApiResult<IEnumerable<FAQCategoryViewData>> faqCategoriesAsync = faqCategories;
      faqCategories = (BackOfficeApiResult<IEnumerable<FAQCategoryViewData>>) null;
      return faqCategoriesAsync;
    }
  }
}
