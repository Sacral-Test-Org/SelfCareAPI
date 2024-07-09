// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.PaymentController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Selfcare.Api.Attributes;
using Selfcare.Api.Models.Payment;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Payment;
using Selfcare.Infrastructure.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class PaymentController : BaseController
  {
    private readonly IPaymentService paymentService;

    public PaymentController(IPaymentService paymentService)
    {
      this.paymentService = paymentService;
    }

    [HttpPost]
    [Route("payments/obtainsession")]
    [ModelValidation]
    public async Task<HttpResponseMessage> SessionObtaining(PaymentDetailsModel paymentRequestData)
    {
      PaymentDetailsData paymentData = this.mapper.Map<PaymentDetailsData>((object) paymentRequestData);
      BackOfficeApiResult<PaymentViewData> sessionResponse = await this.paymentService.RetrievePaymentSessionAsync(paymentData);
      return this.GenerateResponseMessage<PaymentViewData, PaymentViewModel>(sessionResponse);
    }

    [HttpGet]
    [Route("payments/order/{orderId}")]
    public async Task<HttpResponseMessage> GetOrders(string orderId)
    {
      BackOfficeApiResult<PaymentOrdersViewData> result = await this.paymentService.RetrievePaymentOrderStatusAsync(orderId);
      return this.GenerateResponseMessage<PaymentOrdersViewData, PaymentOrdersViewModel>(result);
    }
  }
}
