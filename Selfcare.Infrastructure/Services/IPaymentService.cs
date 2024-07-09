// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Services.IPaymentService
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Payment;
using Selfcare.Infrastructure.Entities.Persistence;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.Services
{
  public interface IPaymentService
  {
    Task<BackOfficeApiResult<PaymentViewData>> RetrievePaymentSessionAsync(
      PaymentDetailsData paymentData);

    Task<BackOfficeApiResult<PaymentOrdersViewData>> RetrievePaymentOrderStatusAsync(string orderId);

    Task<bool> ExistsByOrderIdAsync(string orderId);

    Task<bool> ExistsByOrderIdAndStateAsync(string orderId, bool state);

    Task<string> InsertAsync(PaymentOrders paymentOrder);

    Task UpdateAsync(PaymentOrders paymentOrder);
  }
}
