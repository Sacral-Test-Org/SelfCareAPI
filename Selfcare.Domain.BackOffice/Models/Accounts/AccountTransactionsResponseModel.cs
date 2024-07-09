// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Accounts.AccountTransactionsResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Accounts
{
  public class AccountTransactionsResponseModel
  {
    public int TransactionId { get; set; }

    public int AccountUnitId { get; set; }

    public int AccountId { get; set; }

    public int GantryId { get; set; }

    public string BarCode { get; set; }

    public string VRM { get; set; }

    public DateTime TransactionDate { get; set; }

    public string LocationName { get; set; }

    public Decimal AmountDebits { get; set; }

    public Decimal AmountCredits { get; set; }

    public Decimal AmountFinal { get; set; }

    public int StatusId { get; set; }

    public string Service { get; set; }

    public DateTime PostingDate { get; set; }

    public string DocumentNumber { get; set; }

    public string CaseRelated { get; set; }
  }
}
