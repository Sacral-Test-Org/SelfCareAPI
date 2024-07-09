// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Accounts.RetrieveFinancialDocumentsResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Accounts
{
  public class RetrieveFinancialDocumentsResponseModel
  {
    public int FinancialDocumentID { get; set; }

    public int DocumentTypeId { get; set; }

    public string ReferenceNumber { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime DueDate { get; set; }

    public Decimal Amount { get; set; }

    public Decimal Outstanding { get; set; }

    public DateTime PeriodFrom { get; set; }

    public DateTime PeriodTo { get; set; }

    public int StatusId { get; set; }

    public byte[] DocumentContent { get; set; }
  }
}
