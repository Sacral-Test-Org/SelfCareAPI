// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.Repositories.PaymentOrdersRepository
// Assembly: Selfcare.Persistence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC28A518-E4A9-4CDD-8B12-F4E86AD0AF6A
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Persistence.dll

using Dapper;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using Selfcare.Persistence.Sql;
using System.Data;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Persistence.Repositories
{
  public class PaymentOrdersRepository : IPaymentOrdersRepository
  {
    private readonly ISqlConnectionFactory sqlConnectionFactory;

    public PaymentOrdersRepository(ISqlConnectionFactory sqlConFactory)
    {
      this.sqlConnectionFactory = sqlConFactory;
    }

    public async Task<bool> ExistsByOrderIdAndStatusAsync(
      string orderId,
      bool status,
      IDbTransaction transaction = null)
    {
      bool flag;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        PaymentOrders paymentOrder = await SqlMapper.QueryFirstOrDefaultAsync<PaymentOrders>(connection, PaymentOrdersQueries.SelectByOrderIdAndStatus, (object) new
        {
          orderId = orderId,
          status = status
        }, transaction, new int?(), new CommandType?());
        flag = paymentOrder != null;
      }
      return flag;
    }

    public async Task<bool> ExistsByOrderIdAsync(string orderId, IDbTransaction transaction = null)
    {
      bool flag;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        PaymentOrders paymentOrder = await SqlMapper.QueryFirstOrDefaultAsync<PaymentOrders>(connection, PaymentOrdersQueries.SelectByOrderId, (object) new
        {
          orderId = orderId
        }, transaction, new int?(), new CommandType?());
        flag = paymentOrder != null;
      }
      return flag;
    }

    public async Task<string> InsertAsync(PaymentOrders paymentOrder, IDbTransaction transaction = null)
    {
      string str;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
        str = await SqlMapper.ExecuteScalarAsync<string>(connection, PaymentOrdersQueries.Insert, (object) new
        {
          OrderId = paymentOrder.OrderId,
          Status = paymentOrder.Status
        }, transaction, new int?(), new CommandType?());
      return str;
    }

    public async Task UpdateAsync(PaymentOrders paymentOrder, IDbTransaction transaction = null)
    {
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        int num = await SqlMapper.ExecuteAsync(connection, PaymentOrdersQueries.Update, (object) new
        {
          OrderId = paymentOrder.OrderId,
          Status = paymentOrder.Status
        }, transaction, new int?(), new CommandType?());
      }
    }
  }
}
