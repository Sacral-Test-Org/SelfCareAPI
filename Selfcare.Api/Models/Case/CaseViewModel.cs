// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Case.CaseViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Case
{
  public class CaseViewModel
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
