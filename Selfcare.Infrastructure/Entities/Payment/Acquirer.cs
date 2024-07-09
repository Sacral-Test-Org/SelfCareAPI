// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.Acquirer
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class Acquirer
  {
    public int batch { get; set; }

    public string date { get; set; }

    public string id { get; set; }

    public string merchantId { get; set; }

    public string settlementDate { get; set; }

    public string timeZone { get; set; }
  }
}
