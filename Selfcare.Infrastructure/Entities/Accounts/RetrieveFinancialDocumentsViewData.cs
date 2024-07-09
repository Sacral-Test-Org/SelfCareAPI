// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Accounts.RetrieveFinancialDocumentsViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Accounts
{
  public class RetrieveFinancialDocumentsViewData
  {
    public int FinancialDocumentID { get; set; }

    public int DocumentTypeId { get; set; }

    public string ReferenceNumber { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime DueDate { get; set; }

    public Decimal Amount { get; set; }

    public Decimal OutstandingBalance { get; set; }

    public DateTime PeriodFrom { get; set; }

    public DateTime PeriodTo { get; set; }

    public int StatusId { get; set; }

    public byte[] DocumentContent { get; set; }
  }
}
