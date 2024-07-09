// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.BackOffice.BackOfficeApiResult`1
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System.Net;

#nullable disable
namespace Selfcare.Infrastructure.BackOffice
{
  public class BackOfficeApiResult<T> where T : class
  {
    public HttpStatusCode StatusCode { get; set; }

    public string ErrorMessage { get; set; }

    public T Data { get; set; }
  }
}
