// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Managers.PaymentOrdersManager
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Persistence.Managers;
using Selfcare.Infrastructure.Persistence.Repositories;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Domain.Security.Managers
{
  public class PaymentOrdersManager : IPaymentOrdersManager
  {
    private readonly IPaymentOrdersRepository paymentRepository;

    public PaymentOrdersManager(IPaymentOrdersRepository paymentRepository)
    {
      this.paymentRepository = paymentRepository;
    }

    public async Task<bool> ExistsByOrderIdAndStatusAsync(string orderId, bool status)
    {
      bool flag = await this.paymentRepository.ExistsByOrderIdAndStatusAsync(orderId, status);
      return flag;
    }

    public async Task<bool> ExistsByOrderIdAsync(string orderId)
    {
      bool flag = await this.paymentRepository.ExistsByOrderIdAsync(orderId);
      return flag;
    }

    public async Task<string> InsertAsync(PaymentOrders paymentOrder)
    {
      string str = await this.paymentRepository.InsertAsync(paymentOrder);
      return str;
    }

    public async Task UpdateAsync(PaymentOrders paymentOrder)
    {
      await this.paymentRepository.UpdateAsync(paymentOrder);
    }
  }
}
