// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Persistence.Repositories.IUserRepository
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Selfcare.Infrastructure.Entities.Persistence;
using System.Data;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.Persistence.Repositories
{
  public interface IUserRepository
  {
    Task<string> CreateAsync(IDbConnection connection, User user, IDbTransaction transaction = null);

    Task UpdateAsync(IDbConnection connection, User user, IDbTransaction transaction = null);

    Task DeleteAsync(IDbConnection connection, string id, IDbTransaction transaction = null);

    Task<User> SelectAsync(IDbConnection connection, string id, IDbTransaction transaction = null);

    Task<User> SelectByUserNameAsync(
      IDbConnection connection,
      string username,
      IDbTransaction transaction = null);

    Task<User> SelectByEmail(IDbConnection connection, string email, IDbTransaction transaction = null);
  }
}
