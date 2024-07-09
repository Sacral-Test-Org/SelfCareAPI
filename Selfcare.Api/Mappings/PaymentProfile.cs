// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Mappings.PaymentProfile
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using AutoMapper;
using Selfcare.Api.Models.Payment;
using Selfcare.Infrastructure.Entities.Payment;

#nullable disable
namespace Selfcare.Api.Mappings
{
  public class PaymentProfile : Profile
  {
    public PaymentProfile()
    {
      this.CreateMap<PaymentDetailsData, PaymentDetailsModel>();
      this.CreateMap<PaymentSessionData, PaymentSessionDetails>();
      this.CreateMap<PaymentViewData, PaymentViewModel>();
      this.CreateMap<PaymentOrdersViewData, PaymentOrdersViewModel>();
    }
  }
}
