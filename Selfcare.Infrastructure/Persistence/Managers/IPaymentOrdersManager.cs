// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Persistence.Managers.IPaymentOrdersManager
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Selfcare.Infrastructure.Entities.Persistence;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.Persistence.Managers
{
  public interface IPaymentOrdersManager
  {
    Task<bool> ExistsByOrderIdAsync(string orderId);

    Task<bool> ExistsByOrderIdAndStatusAsync(string orderId, bool status);

    Task<string> InsertAsync(PaymentOrders paymentOrder);

    Task UpdateAsync(PaymentOrders paymentOrder);
  }
}
