// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.AuthorizationResponse
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class AuthorizationResponse
  {
    public string cardSecurityCodeError { get; set; }

    public string commercialCard { get; set; }

    public string commercialCardIndicator { get; set; }

    public string date { get; set; }

    public string processingCode { get; set; }

    public string responseCode { get; set; }

    public string returnAci { get; set; }

    public string stan { get; set; }

    public string time { get; set; }
  }
}
