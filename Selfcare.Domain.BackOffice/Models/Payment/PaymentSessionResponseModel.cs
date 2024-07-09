// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Payment.PaymentSessionResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Payment
{
  internal class PaymentSessionResponseModel
  {
    public string merchant { get; set; }

    public string result { get; set; }

    public PaymentSessionModel session { get; set; }

    public string successIndicator { get; set; }
  }
}
