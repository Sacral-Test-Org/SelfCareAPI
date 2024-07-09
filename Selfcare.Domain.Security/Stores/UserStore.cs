// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Stores.UserStore
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Microsoft.AspNet.Identity;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using System;
using System.Data;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Domain.Security.Stores
{
  public class UserStore : 
    IUserStore<User>,
    IUserStore<User, string>,
    IDisposable,
    IUserPasswordStore<User>,
    IUserPasswordStore<User, string>,
    IUserEmailStore<User>,
    IUserEmailStore<User, string>
  {
    private readonly ISqlConnectionFactory sqlConnectionFactory;
    private readonly IUserRepository userRepository;

    public UserStore(ISqlConnectionFactory sqlConnectionFactory, IUserRepository userRepository)
    {
      this.sqlConnectionFactory = sqlConnectionFactory;
      this.userRepository = userRepository;
    }

    public async Task CreateAsync(User user)
    {
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        string async = await this.userRepository.CreateAsync(connection, user);
      }
    }

    public async Task DeleteAsync(User user)
    {
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
        await this.userRepository.DeleteAsync(connection, user.Id);
    }

    public void Dispose()
    {
    }

    public async Task<User> FindByIdAsync(string userId)
    {
      User user;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
        user = await this.userRepository.SelectAsync(connection, userId);
      User byIdAsync = user;
      user = (User) null;
      return byIdAsync;
    }

    public async Task<User> FindByNameAsync(string userName)
    {
      User user;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
        user = await this.userRepository.SelectByUserNameAsync(connection, userName);
      User byNameAsync = user;
      user = (User) null;
      return byNameAsync;
    }

    public async Task UpdateAsync(User user)
    {
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
        await this.userRepository.UpdateAsync(connection, user);
    }

    public async Task<string> GetPasswordHashAsync(User user)
    {
      string passwordHash = string.Empty;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        User userData = await this.userRepository.SelectAsync(connection, user.Id);
        if (userData != null)
          passwordHash = userData.PasswordHash;
        userData = (User) null;
      }
      string passwordHashAsync = passwordHash;
      passwordHash = (string) null;
      return passwordHashAsync;
    }

    public async Task<bool> HasPasswordAsync(User user)
    {
      bool hasPassword;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        User userData = await this.userRepository.SelectAsync(connection, user.Id);
        hasPassword = !string.IsNullOrWhiteSpace(userData.PasswordHash);
        userData = (User) null;
      }
      return hasPassword;
    }

    public Task SetPasswordHashAsync(User user, string passwordHash)
    {
      user.PasswordHash = passwordHash;
      return (Task) Task.FromResult<int>(0);
    }

    public Task SetEmailAsync(User user, string email)
    {
      user.Email = email;
      return (Task) Task.FromResult<int>(0);
    }

    public async Task<string> GetEmailAsync(User user)
    {
      string email = string.Empty;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        User userData = await this.userRepository.SelectAsync(connection, user.Id);
        if (userData != null)
          email = userData.Email;
        userData = (User) null;
      }
      string emailAsync = email;
      email = (string) null;
      return emailAsync;
    }

    public Task<bool> GetEmailConfirmedAsync(User user) => Task.FromResult<bool>(true);

    public Task SetEmailConfirmedAsync(User user, bool confirmed) => (Task) Task.FromResult<int>(0);

    public async Task<User> FindByEmailAsync(string email)
    {
      User user;
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
        user = await this.userRepository.SelectByEmail(connection, email);
      User byEmailAsync = user;
      user = (User) null;
      return byEmailAsync;
    }
  }
}
