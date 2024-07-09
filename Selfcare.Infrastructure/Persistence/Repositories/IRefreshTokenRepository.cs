// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Persistence.Repositories.IRefreshTokenRepository
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Selfcare.Infrastructure.Entities.Persistence;
using System.Data;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.Persistence.Repositories
{
  public interface IRefreshTokenRepository
  {
    Task<bool> ExistsByUsernameAndClientIdAsync(
      IDbConnection connection,
      string username,
      string clientId,
      IDbTransaction transaction = null);

    Task<RefreshToken> SelectByUsernameAndClientIdAsync(
      IDbConnection connection,
      string username,
      string clientId,
      IDbTransaction transaction = null);

    Task<string> InsertAsync(
      IDbConnection connection,
      RefreshToken refreshToken,
      IDbTransaction transaction = null);

    Task DeleteAsync(IDbConnection connection, string id, IDbTransaction transaction = null);

    Task<bool> ExistsAsync(IDbConnection connection, string id, IDbTransaction transaction = null);

    Task<RefreshToken> Select(IDbConnection connection, string id, IDbTransaction transaction = null);
  }
}
