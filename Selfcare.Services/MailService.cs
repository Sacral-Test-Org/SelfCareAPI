// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.MailService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Selfcare.Infrastructure.Entities.Accounts;
using Selfcare.Infrastructure.Entities.MailServer;
using Selfcare.Infrastructure.Services;
using Selfcare.Services.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  internal class MailService : IMailService
  {
    public async Task<MailServerResponse> SendResetPasswordEmail(
      string recepientAddress,
      string url)
    {
      SmtpClient client = this.getSmtpClient();
      MailServerResponse serverResponse = new MailServerResponse();
      try
      {
        MimeMessage message = new MimeMessage();
        message.From.Add((InternetAddress) new MailboxAddress(ConfigurationManager.AppSettings["SenderName"], ConfigurationManager.AppSettings["SenderAddress"]));
        message.To.Add((InternetAddress) new MailboxAddress(recepientAddress));
        message.Subject = ConfigurationManager.AppSettings["ResetPasswordMailSubject"];
        string mailBody = this.getResetPasswordEmailTemplate();
        mailBody = mailBody.Replace("{{resetPasswordLink}}", url);
        mailBody = mailBody.Replace("{{regardsBy}}", ConfigurationManager.AppSettings["MailBestRegardsBy"]);
        BodyBuilder builder = new BodyBuilder();
        builder.HtmlBody = mailBody;
        MimeEntity body = builder.ToMessageBody();
        message.Body = body;
        await ((MailTransport) client).SendAsync(message, new CancellationToken(), (ITransferProgress) null);
        serverResponse.IsSuccessfull = true;
        message = (MimeMessage) null;
        mailBody = (string) null;
        builder = (BodyBuilder) null;
        body = (MimeEntity) null;
      }
      catch (Exception ex)
      {
        string error = ex.StackTrace;
        serverResponse.IsSuccessfull = false;
        serverResponse.ResponseMessage = "An error occurred while sending the reset password message.";
        error = (string) null;
      }
      finally
      {
        await ((MailService) client).DisconnectAsync(true, new CancellationToken());
        ((MailService) client).Dispose();
      }
      MailServerResponse mailServerResponse = serverResponse;
      client = (SmtpClient) null;
      serverResponse = (MailServerResponse) null;
      return mailServerResponse;
    }

    public async Task<MailServerResponse> SendSuccessfulTopupRegistrationEmail(
      RegisterAccountTopupData accountTopupData,
      string recepientEmail)
    {
      SmtpClient client = this.getSmtpClient();
      MailServerResponse serverResponse = new MailServerResponse();
      try
      {
        MimeMessage message = new MimeMessage();
        message.From.Add((InternetAddress) new MailboxAddress(ConfigurationManager.AppSettings["SenderName"], ConfigurationManager.AppSettings["SenderAddress"]));
        message.To.Add((InternetAddress) new MailboxAddress(recepientEmail));
        message.Subject = ConfigurationManager.AppSettings["InvoiceDetailsMailSubject"];
        string mailBody = this.getSuccessfulTopupMailTemplate();
        mailBody = mailBody.Replace("{{orderId}}", accountTopupData.OrderId);
        mailBody = mailBody.Replace("{{regardsBy}}", ConfigurationManager.AppSettings["MailBestRegardsBy"]);
        BodyBuilder builder = new BodyBuilder();
        builder.HtmlBody = mailBody;
        MimeEntity body = builder.ToMessageBody();
        message.Body = body;
        await ((MailTransport) client).SendAsync(message, new CancellationToken(), (ITransferProgress) null);
        serverResponse.IsSuccessfull = true;
        message = (MimeMessage) null;
        mailBody = (string) null;
        builder = (BodyBuilder) null;
        body = (MimeEntity) null;
      }
      catch (Exception ex)
      {
        string error = ex.StackTrace;
        serverResponse.IsSuccessfull = false;
        serverResponse.ResponseMessage = "An error occurred while sending the reset password message.";
        error = (string) null;
      }
      finally
      {
        await ((MailService) client).DisconnectAsync(true, new CancellationToken());
        ((MailService) client).Dispose();
      }
      MailServerResponse mailServerResponse = serverResponse;
      client = (SmtpClient) null;
      serverResponse = (MailServerResponse) null;
      return mailServerResponse;
    }

    private SmtpClient getSmtpClient()
    {
      SmtpClient smtpClient = new SmtpClient();
      ((MailService) smtpClient).ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((s, c, h, e) => true);
      this.GetFQDN();
      try
      {
        ((MailService) smtpClient).Timeout = 3000;
        HashSet<string> authenticationMechanisms = ((MailService) smtpClient).AuthenticationMechanisms;
        ((MailService) smtpClient).Connect(ConfigurationManager.AppSettings["MailServerHost"], int.Parse(ConfigurationManager.AppSettings["MailServerPort"]), Convert.ToBoolean(ConfigurationManager.AppSettings["UseSSL"]) ? (SecureSocketOptions) 2 : (SecureSocketOptions) 0, new CancellationToken());
      }
      catch (Exception ex)
      {
      }
      return smtpClient;
    }

    private string getResetPasswordEmailTemplate() => Resources.ResetPasswordEmailTemplate;

    private string getSuccessfulTopupMailTemplate() => Resources.SuccessfulTopupMailTemplate;

    private string GetFQDN()
    {
      string domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
      string hostName = Dns.GetHostName();
      string str = "." + domainName;
      if (!hostName.EndsWith(str))
        hostName += str;
      return hostName;
    }
  }
}
