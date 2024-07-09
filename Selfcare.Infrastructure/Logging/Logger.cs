// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Logging.Logger
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Newtonsoft.Json;
using NLog;
using System;

#nullable disable
namespace Selfcare.Infrastructure.Logging
{
  internal class Logger : ILogger
  {
    private static Logger logger = LogManager.GetCurrentClassLogger();

    private string SerializeToJson<T>(T value) where T : class
    {
      return JsonConvert.SerializeObject((object) value, (Formatting) 1);
    }

    public void Debug(string message) => Logger.logger.Debug(message);

    public void Debug<T>(string message, T data) where T : class
    {
      Logger.logger.Debug(message);
      Logger.logger.Debug(this.SerializeToJson<T>(data));
    }

    public void Error(string message) => Logger.logger.Error(message);

    public void Error<T>(string message, T data) where T : class
    {
      Logger.logger.Error(message + Environment.NewLine + this.SerializeToJson<T>(data));
    }

    public void Error(string message, Exception ex) => Logger.logger.Error(ex, message);

    public void Error<T>(string message, T data, Exception ex) where T : class
    {
      Logger.logger.Error(ex, message + Environment.NewLine + this.SerializeToJson<T>(data));
    }

    public void Information(string message) => Logger.logger.Info(message);

    public void Information<T>(string message, T data) where T : class
    {
      Logger.logger.Info(message);
      Logger.logger.Info(this.SerializeToJson<T>(data));
    }

    public void Warning(string message) => Logger.logger.Warn(message);

    public void Warning<T>(string message, T data) where T : class
    {
      Logger.logger.Warn(message);
      Logger.logger.Warn(this.SerializeToJson<T>(data));
    }

    public void Warning(string message, Exception ex) => Logger.logger.Warn(ex, message);

    public void Warning<T>(string message, T data, Exception ex) where T : class
    {
      Logger.logger.Warn(ex, message + Environment.NewLine + this.SerializeToJson<T>(data));
    }
  }
}
