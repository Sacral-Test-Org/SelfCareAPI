// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.Repositories.UserRepository
// Assembly: Selfcare.Persistence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC28A518-E4A9-4CDD-8B12-F4E86AD0AF6A
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Persistence.dll

using Dapper;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using Selfcare.Persistence.Sql;
using System;
using System.Data;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Persistence.Repositories
{
  public class UserRepository : IUserRepository
  {
    public async Task<string> CreateAsync(
      IDbConnection connection,
      User user,
      IDbTransaction transaction = null)
    {
      string id = Guid.NewGuid().ToString();
      object obj = await SqlMapper.ExecuteScalarAsync(connection, UserQueries.Insert, (object) new
      {
        id = id,
        Email = user.Email,
        UserName = user.UserName,
        PasswordHash = user.PasswordHash,
        CustomerId = user.CustomerId
      }, transaction, new int?(), new CommandType?());
      string async = id;
      id = (string) null;
      return async;
    }

    public async Task DeleteAsync(IDbConnection connection, string id, IDbTransaction transaction = null)
    {
      int num = await SqlMapper.ExecuteAsync(connection, UserQueries.Delete, (object) new
      {
        id = id
      }, transaction, new int?(), new CommandType?());
    }

    public async Task<User> SelectAsync(
      IDbConnection connection,
      string id,
      IDbTransaction transaction = null)
    {
      User user = await SqlMapper.QueryFirstOrDefaultAsync<User>(connection, UserQueries.Select, (object) new
      {
        id = id
      }, transaction, new int?(), new CommandType?());
      return user;
    }

    public async Task<User> SelectByEmail(
      IDbConnection connection,
      string email,
      IDbTransaction transaction = null)
    {
      User user = await SqlMapper.QueryFirstOrDefaultAsync<User>(connection, UserQueries.SelectByEmail, (object) new
      {
        email = email
      }, transaction, new int?(), new CommandType?());
      return user;
    }

    public async Task<User> SelectByUserNameAsync(
      IDbConnection connection,
      string username,
      IDbTransaction transaction = null)
    {
      User user = await SqlMapper.QueryFirstOrDefaultAsync<User>(connection, UserQueries.SelectByUserName, (object) new
      {
        username = username
      }, transaction, new int?(), new CommandType?());
      return user;
    }

    public async Task UpdateAsync(IDbConnection connection, User user, IDbTransaction transaction = null)
    {
      int num = await SqlMapper.ExecuteAsync(connection, UserQueries.Update, (object) new
      {
        Id = user.Id,
        Email = user.Email,
        PasswordHash = user.PasswordHash,
        CustomerId = user.CustomerId
      }, transaction, new int?(), new CommandType?());
    }
  }
}
