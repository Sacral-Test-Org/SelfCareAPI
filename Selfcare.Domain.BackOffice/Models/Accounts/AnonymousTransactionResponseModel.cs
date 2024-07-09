// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Accounts.AnonymousTransactionResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Accounts
{
  public class AnonymousTransactionResponseModel
  {
    public int AccountID { get; set; }

    public int AccountUnitId { get; set; }

    public string AssetIdentifier { get; set; }

    public int TransactionId { get; set; }

    public string LocationName { get; set; }

    public Decimal Amount { get; set; }

    public int StatusId { get; set; }

    public string Service { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime PostingDate { get; set; }
  }
}
