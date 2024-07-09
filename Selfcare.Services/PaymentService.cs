// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.PaymentService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Payment;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Persistence.Managers;
using Selfcare.Infrastructure.Services;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  public class PaymentService : IPaymentService
  {
    private readonly IBackOfficeManager backOfficeManager;
    private readonly IPaymentOrdersManager paymentManager;

    public PaymentService(
      IBackOfficeManager backOfficeManager,
      IPaymentOrdersManager paymentManager)
    {
      this.backOfficeManager = backOfficeManager;
      this.paymentManager = paymentManager;
    }

    public async Task<BackOfficeApiResult<PaymentOrdersViewData>> RetrievePaymentOrderStatusAsync(
      string orderId)
    {
      BackOfficeApiResult<PaymentOrdersViewData> orderDetails = await this.backOfficeManager.RetrievePaymentOrderStatusAsync(orderId);
      BackOfficeApiResult<PaymentOrdersViewData> backOfficeApiResult = orderDetails;
      orderDetails = (BackOfficeApiResult<PaymentOrdersViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<PaymentViewData>> RetrievePaymentSessionAsync(
      PaymentDetailsData paymentData)
    {
      BackOfficeApiResult<PaymentViewData> paymentSessionData = await this.backOfficeManager.RetrievePaymentSessionAsync(paymentData);
      BackOfficeApiResult<PaymentViewData> backOfficeApiResult = paymentSessionData;
      paymentSessionData = (BackOfficeApiResult<PaymentViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<bool> ExistsByOrderIdAndStateAsync(string orderId, bool state)
    {
      bool flag = await this.paymentManager.ExistsByOrderIdAndStatusAsync(orderId, state);
      return flag;
    }

    public async Task<bool> ExistsByOrderIdAsync(string orderId)
    {
      bool flag = await this.paymentManager.ExistsByOrderIdAsync(orderId);
      return flag;
    }

    public async Task<string> InsertAsync(PaymentOrders paymentOrder)
    {
      string str = await this.paymentManager.InsertAsync(paymentOrder);
      return str;
    }

    public async Task UpdateAsync(PaymentOrders paymentOrder)
    {
      await this.paymentManager.UpdateAsync(paymentOrder);
    }
  }
}
