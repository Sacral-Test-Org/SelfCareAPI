// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.Repositories.RefreshTokenRepository
// Assembly: Selfcare.Persistence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC28A518-E4A9-4CDD-8B12-F4E86AD0AF6A
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Persistence.dll

using Dapper;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using Selfcare.Persistence.Sql;
using System.Data;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Persistence.Repositories
{
  public class RefreshTokenRepository : IRefreshTokenRepository
  {
    public async Task DeleteAsync(IDbConnection connection, string id, IDbTransaction transaction = null)
    {
      int num = await SqlMapper.ExecuteAsync(connection, RefreshTokenQueries.Delete, (object) new
      {
        id = id
      }, transaction, new int?(), new CommandType?());
    }

    public async Task<bool> ExistsAsync(
      IDbConnection connection,
      string id,
      IDbTransaction transaction = null)
    {
      RefreshToken refreshToken = await SqlMapper.QueryFirstOrDefaultAsync<RefreshToken>(connection, RefreshTokenQueries.Select, (object) new
      {
        id = id
      }, transaction, new int?(), new CommandType?());
      bool flag = refreshToken != null;
      refreshToken = (RefreshToken) null;
      return flag;
    }

    public async Task<bool> ExistsByUsernameAndClientIdAsync(
      IDbConnection connection,
      string username,
      string clientId,
      IDbTransaction transaction = null)
    {
      RefreshToken refreshToken = await SqlMapper.QueryFirstOrDefaultAsync<RefreshToken>(connection, RefreshTokenQueries.SelectByUsernameAndClientId, (object) new
      {
        username = username,
        clientId = clientId
      }, transaction, new int?(), new CommandType?());
      bool flag = refreshToken != null;
      refreshToken = (RefreshToken) null;
      return flag;
    }

    public async Task<string> InsertAsync(
      IDbConnection connection,
      RefreshToken refreshToken,
      IDbTransaction transaction = null)
    {
      string str = await SqlMapper.ExecuteScalarAsync<string>(connection, RefreshTokenQueries.Insert, (object) new
      {
        Id = refreshToken.Id,
        Username = refreshToken.Username,
        ClientId = refreshToken.ClientId,
        IssuedOn = refreshToken.IssuedOn,
        ExpiresOn = refreshToken.ExpiresOn,
        ProtectedTicket = refreshToken.ProtectedTicket
      }, transaction, new int?(), new CommandType?());
      return str;
    }

    public async Task<RefreshToken> Select(
      IDbConnection connection,
      string id,
      IDbTransaction transaction = null)
    {
      RefreshToken refreshToken = await SqlMapper.QueryFirstOrDefaultAsync<RefreshToken>(connection, RefreshTokenQueries.Select, (object) new
      {
        id = id
      }, transaction, new int?(), new CommandType?());
      return refreshToken;
    }

    public async Task<RefreshToken> SelectByUsernameAndClientIdAsync(
      IDbConnection connection,
      string username,
      string clientId,
      IDbTransaction transaction = null)
    {
      RefreshToken refreshToken = await SqlMapper.QueryFirstOrDefaultAsync<RefreshToken>(connection, RefreshTokenQueries.SelectByUsernameAndClientId, (object) new
      {
        username = username,
        clientId = clientId
      }, transaction, new int?(), new CommandType?());
      return refreshToken;
    }
  }
}
