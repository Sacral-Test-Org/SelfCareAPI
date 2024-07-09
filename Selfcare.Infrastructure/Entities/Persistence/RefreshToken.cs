// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Persistence.RefreshToken
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Persistence
{
  public class RefreshToken
  {
    public string Id { get; set; }

    public string Username { get; set; }

    public string ClientId { get; set; }

    public DateTime IssuedOn { get; set; }

    public DateTime ExpiresOn { get; set; }

    public string ProtectedTicket { get; set; }
  }
}
