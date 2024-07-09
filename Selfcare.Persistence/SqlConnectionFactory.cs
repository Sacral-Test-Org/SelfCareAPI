// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.SqlConnectionFactory
// Assembly: Selfcare.Persistence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC28A518-E4A9-4CDD-8B12-F4E86AD0AF6A
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Persistence.dll

using Selfcare.Infrastructure.Persistence;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Persistence
{
  public class SqlConnectionFactory : ISqlConnectionFactory
  {
    public Task<IDbConnection> CreateAsync()
    {
      IDbConnection result = (IDbConnection) new SqlConnection(ConfigurationManager.ConnectionStrings["Selfcare.Test"].ConnectionString);
      result.Open();
      return Task.FromResult<IDbConnection>(result);
    }
  }
}
