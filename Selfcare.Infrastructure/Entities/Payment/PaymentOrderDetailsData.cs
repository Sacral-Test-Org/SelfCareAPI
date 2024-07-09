// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.PaymentOrderDetailsData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class PaymentOrderDetailsData
  {
    public int amount { get; set; }

    public Chargeback chargeback { get; set; }

    public DateTime creationTime { get; set; }

    public string currency { get; set; }

    public Customer customer { get; set; }

    public string description { get; set; }

    public Device device { get; set; }

    public string id { get; set; }

    public string merchant { get; set; }

    public string merchantCategoryCode { get; set; }

    public string result { get; set; }

    public Risk risk { get; set; }

    public SourceOfFunds sourceOfFunds { get; set; }

    public string status { get; set; }

    public int totalAuthorizedAmount { get; set; }

    public int totalCapturedAmount { get; set; }

    public int totalRefundedAmount { get; set; }

    public List<Transaction> transaction { get; set; }
  }
}
