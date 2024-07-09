// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.Card2
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class Card2
  {
    public string brand { get; set; }

    public Expiry2 expiry { get; set; }

    public string fundingMethod { get; set; }

    public string nameOnCard { get; set; }

    public string number { get; set; }

    public string scheme { get; set; }

    public string storedOnFile { get; set; }
  }
}
