// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.ErrorResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using System.Net;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models
{
  public class ErrorResponseModel
  {
    public HttpStatusCode StatusCode { get; set; }

    public string StatusDescription { get; set; }

    public string Content { get; set; }
  }
}
