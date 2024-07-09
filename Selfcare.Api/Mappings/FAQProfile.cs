// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Mappings.FAQProfile
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using AutoMapper;
using Selfcare.Api.Models.FAQ;
using Selfcare.Infrastructure.Entities.FAQ;

#nullable disable
namespace Selfcare.Api.Mappings
{
  public class FAQProfile : Profile
  {
    public FAQProfile()
    {
      this.CreateMap<FAQViewData, FAQViewModel>();
      this.CreateMap<FAQCategoryViewData, FAQCategoryViewModel>();
    }
  }
}
