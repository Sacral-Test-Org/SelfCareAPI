// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.Order
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class Order
  {
    public int amount { get; set; }

    public Chargeback2 chargeback { get; set; }

    public DateTime creationTime { get; set; }

    public string currency { get; set; }

    public string description { get; set; }

    public string id { get; set; }

    public string merchantCategoryCode { get; set; }

    public string status { get; set; }

    public int totalAuthorizedAmount { get; set; }

    public int totalCapturedAmount { get; set; }

    public int totalRefundedAmount { get; set; }
  }
}
