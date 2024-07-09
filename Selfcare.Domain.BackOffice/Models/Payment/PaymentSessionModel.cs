// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Payment.PaymentSessionModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Payment
{
  internal class PaymentSessionModel
  {
    public string aes256Key { get; set; }

    public int authenticationLimit { get; set; }

    public string id { get; set; }

    public string updateStatus { get; set; }

    public string version { get; set; }
  }
}
