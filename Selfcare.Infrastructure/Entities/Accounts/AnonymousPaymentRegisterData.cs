// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Accounts.AnonymousPaymentRegisterData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Accounts
{
  public class AnonymousPaymentRegisterData
  {
    public int AccountId { get; set; }

    public int TransactionId { get; set; }

    public Decimal Amount { get; set; }

    public string Reference { get; set; }

    public string OrderId { get; set; }

    public string LPN { get; set; }

    public int ChannelId { get; set; }
  }
}
