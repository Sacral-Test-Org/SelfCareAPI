// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.TokenData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities
{
  public class TokenData
  {
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public DateTime? Issued { get; set; }

    public DateTime? Expires { get; set; }

    public int ExpiresInSeconds { get; set; }

    public bool IsValid { get; set; }

    public string ErrorMessage { get; set; }
  }
}
