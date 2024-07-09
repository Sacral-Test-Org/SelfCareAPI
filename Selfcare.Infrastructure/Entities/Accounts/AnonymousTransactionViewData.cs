// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Accounts.AnonymousTransactionViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Accounts
{
  public class AnonymousTransactionViewData
  {
    public int AccountID { get; set; }

    public int AccountUnitId { get; set; }

    public string AssetIdentifier { get; set; }

    public int TransactionId { get; set; }

    public string LocationName { get; set; }

    public Decimal Amount { get; set; }

    public int StatusId { get; set; }

    public string Service { get; set; }

    public DateTime PostingDate { get; set; }

    public DateTime TransactionDate { get; set; }
  }
}
