// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Accounts.RetrieveFinancialDocumentsParametersModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Accounts
{
  public class RetrieveFinancialDocumentsParametersModel
  {
    public int AccountId { get; set; }

    public int? FinancialDocumentTypeId { get; set; }

    public string ReferenceNumber { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }
  }
}
