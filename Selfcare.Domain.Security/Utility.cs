// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Utility
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Microsoft.AspNet.Identity;
using System;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace Selfcare.Domain.Security
{
  internal static class Utility
  {
    public static PasswordValidator GetPasswordValidator()
    {
      return new PasswordValidator() { RequiredLength = 1 };
    }

    public static string Hash(string value)
    {
      return Convert.ToBase64String(new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(value)));
    }
  }
}
