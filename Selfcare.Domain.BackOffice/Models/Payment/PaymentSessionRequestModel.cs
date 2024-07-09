// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Payment.PaymentSessionRequestModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Payment
{
  internal class PaymentSessionRequestModel
  {
    public string apiOperation { get; set; }

    public PaymentOrderDetails order { get; set; }

    public PaymentInteractionDetails interaction { get; set; }
  }
}
