// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.Response2
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class Response2
  {
    public string acquirerCode { get; set; }

    public string acquirerMessage { get; set; }

    public CardSecurityCode cardSecurityCode { get; set; }

    public string gatewayCode { get; set; }
  }
}
