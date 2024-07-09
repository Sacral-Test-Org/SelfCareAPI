// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Accounts.AccountTransactionsViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Accounts
{
  public class AccountTransactionsViewModel
  {
    public int AccountUnitId { get; set; }

    public int AccountId { get; set; }

    public int GantryId { get; set; }

    public int TransactionId { get; set; }

    public string VRM { get; set; }

    public string BarCode { get; set; }

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
