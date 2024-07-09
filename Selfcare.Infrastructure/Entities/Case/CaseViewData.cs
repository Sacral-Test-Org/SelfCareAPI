// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Case.CaseViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Case
{
  public class CaseViewData
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
