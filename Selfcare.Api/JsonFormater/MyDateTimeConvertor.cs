// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.JsonFormater.MyDateTimeConvertor
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

#nullable disable
namespace Selfcare.Api.JsonFormater
{
  public class MyDateTimeConvertor : DateTimeConverterBase
  {
    public virtual object ReadJson(
      JsonReader reader,
      Type objectType,
      object existingValue,
      JsonSerializer serializer)
    {
      return (object) DateTime.Parse(reader.Value.ToString());
    }

    public virtual void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      writer.WriteValue(((DateTime) value).ToString());
    }
  }
}
