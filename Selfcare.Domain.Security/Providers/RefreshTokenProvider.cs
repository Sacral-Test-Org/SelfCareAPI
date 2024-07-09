// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Providers.RefreshTokenProvider
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Provider;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Enums;
using Selfcare.Infrastructure.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using System;
using System.Data;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Domain.Security.Providers
{
  public class RefreshTokenProvider : IAuthenticationTokenProvider
  {
    private readonly ISqlConnectionFactory sqlConnectionFactory;
    private readonly IRefreshTokenRepository refreshTokenRepository;

    public RefreshTokenProvider(
      ISqlConnectionFactory sqlConnectionFactory,
      IRefreshTokenRepository refreshTokenRepository)
    {
      this.sqlConnectionFactory = sqlConnectionFactory;
      this.refreshTokenRepository = refreshTokenRepository;
    }

    public void Create(AuthenticationTokenCreateContext context)
    {
    }

    public async Task CreateAsync(AuthenticationTokenCreateContext context)
    {
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        string refreshTokenId = Guid.NewGuid().ToString();
        string refreshTokenLifeTimeInMinutes = ((BaseContext) context).OwinContext.Get<string>("refreshTokenLifeTimeInMinutes");
        RefreshToken refreshToken = new RefreshToken()
        {
          Id = Utility.Hash(refreshTokenId),
          Username = context.Ticket.Identity.Name,
          ClientId = ApplicationClients.Angular.ToString(),
          IssuedOn = DateTime.UtcNow,
          ExpiresOn = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTimeInMinutes))
        };
        context.Ticket.Properties.IssuedUtc = new DateTimeOffset?((DateTimeOffset) refreshToken.IssuedOn);
        context.Ticket.Properties.ExpiresUtc = new DateTimeOffset?((DateTimeOffset) refreshToken.ExpiresOn);
        refreshToken.ProtectedTicket = context.SerializeTicket();
        using (IDbTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            if (await this.refreshTokenRepository.ExistsByUsernameAndClientIdAsync(connection, refreshToken.Username, refreshToken.ClientId, transaction))
            {
              RefreshToken oldRefreshToken = await this.refreshTokenRepository.SelectByUsernameAndClientIdAsync(connection, refreshToken.Username, refreshToken.ClientId, transaction);
              await this.refreshTokenRepository.DeleteAsync(connection, oldRefreshToken.Id, transaction);
              oldRefreshToken = (RefreshToken) null;
            }
            string str = await this.refreshTokenRepository.InsertAsync(connection, refreshToken, transaction);
            transaction.Commit();
          }
          catch
          {
            transaction.Rollback();
            throw;
          }
        }
        context.SetToken(refreshTokenId);
        refreshTokenId = (string) null;
        refreshTokenLifeTimeInMinutes = (string) null;
        refreshToken = (RefreshToken) null;
      }
    }

    public void Receive(AuthenticationTokenReceiveContext context)
    {
    }

    public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
    {
      string refreshTokenId = Utility.Hash(context.Token);
      using (IDbConnection connection = await this.sqlConnectionFactory.CreateAsync())
      {
        if (await this.refreshTokenRepository.ExistsAsync(connection, refreshTokenId))
        {
          RefreshToken refreshToken = await this.refreshTokenRepository.Select(connection, refreshTokenId);
          context.DeserializeTicket(refreshToken.ProtectedTicket);
          await this.refreshTokenRepository.DeleteAsync(connection, refreshTokenId);
          refreshToken = (RefreshToken) null;
        }
      }
      refreshTokenId = (string) null;
    }
  }
}
