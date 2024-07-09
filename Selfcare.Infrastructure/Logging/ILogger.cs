// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Logging.ILogger
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Logging
{
  public interface ILogger
  {
    void Debug(string message);

    void Debug<T>(string message, T data) where T : class;

    void Information(string message);

    void Information<T>(string message, T data) where T : class;

    void Warning(string message);

    void Warning<T>(string message, T data) where T : class;

    void Warning(string message, Exception ex);

    void Warning<T>(string message, T data, Exception ex) where T : class;

    void Error(string message);

    void Error<T>(string message, T data) where T : class;

    void Error(string message, Exception ex);

    void Error<T>(string message, T data, Exception ex) where T : class;
  }
}
