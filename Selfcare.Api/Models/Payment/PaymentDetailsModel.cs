// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Payment.PaymentDetailsModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Payment
{
  public class PaymentDetailsModel
  {
    public string OrderId { get; set; }

    public Decimal Amount { get; set; }

    public string LanguageCode { get; set; }

    public int PaymentType { get; set; }
  }
}
