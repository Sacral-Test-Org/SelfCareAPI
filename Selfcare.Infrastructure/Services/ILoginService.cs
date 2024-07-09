// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Services.ILoginService
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Selfcare.Infrastructure.Entities;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.Services
{
  public interface ILoginService
  {
    Task<TokenData> LoginAsync(string username, string password);

    Task<TokenData> LoginRefreshAsync(string refreshToken);
  }
}
