// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Case.CaseResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Case
{
  public class CaseResponseModel
  {
    public int CustomerId { get; set; }

    public int CaseId { get; set; }

    public int AccountId { get; set; }

    public string CaseType { get; set; }

    public string ShortDescription { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime CommitedDate { get; set; }

    public string ResponsibleArea { get; set; }

    public int StatusId { get; set; }
  }
}
