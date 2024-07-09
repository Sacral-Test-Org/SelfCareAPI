// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.LoginService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Selfcare.Infrastructure.Entities;
using Selfcare.Infrastructure.Enums;
using Selfcare.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  public class LoginService : ILoginService
  {
    private readonly string tokenServiceUrl;

    public LoginService()
    {
      this.tokenServiceUrl = ConfigurationManager.AppSettings["BasicApiUrl"] + ":" + ConfigurationManager.AppSettings["ServicePort"] + ConfigurationManager.AppSettings["TokenUrlPath"];
    }

    private FormUrlEncodedContent GenerateLoginContent(string username, string password)
    {
      return new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>) new List<KeyValuePair<string, string>>()
      {
        new KeyValuePair<string, string>("grant_type", nameof (password)),
        new KeyValuePair<string, string>(nameof (username), username),
        new KeyValuePair<string, string>(nameof (password), password),
        new KeyValuePair<string, string>("client_id", ApplicationClients.Angular.ToString())
      });
    }

    private FormUrlEncodedContent GenerateLoginRefreshContent(string refreshToken)
    {
      return new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>) new List<KeyValuePair<string, string>>()
      {
        new KeyValuePair<string, string>("grant_type", "refresh_token"),
        new KeyValuePair<string, string>("refresh_token", refreshToken),
        new KeyValuePair<string, string>("client_id", ApplicationClients.Angular.ToString())
      });
    }

    private async Task<TokenData> GenerateTokenDataAsync(HttpResponseMessage response)
    {
      string str = await response.Content.ReadAsStringAsync();
      object responseData = JsonConvert.DeserializeObject(str);
      str = (string) null;
      TokenData tokenData;
      if (response.StatusCode == HttpStatusCode.OK)
      {
        TokenData tokenData1 = new TokenData();
        TokenData tokenData2 = tokenData1;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (LoginService)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target1 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p1 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "access_token", typeof (LoginService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) LoginService.\u003C\u003Eo__4.\u003C\u003Ep__0, responseData);
        string str1 = target1((CallSite) p1, obj1);
        tokenData2.AccessToken = str1;
        TokenData tokenData3 = tokenData1;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (LoginService)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target2 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p3 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "refresh_token", typeof (LoginService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__2.Target((CallSite) LoginService.\u003C\u003Eo__4.\u003C\u003Ep__2, responseData);
        string str2 = target2((CallSite) p3, obj2);
        tokenData3.RefreshToken = str2;
        TokenData tokenData4 = tokenData1;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (DateTime?), typeof (LoginService)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, DateTime?> target3 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__5.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, DateTime?>> p5 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__5;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (LoginService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__4.Target((CallSite) LoginService.\u003C\u003Eo__4.\u003C\u003Ep__4, responseData, ".issued");
        DateTime? nullable1 = target3((CallSite) p5, obj3);
        tokenData4.Issued = nullable1;
        TokenData tokenData5 = tokenData1;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (DateTime?), typeof (LoginService)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, DateTime?> target4 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__7.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, DateTime?>> p7 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__7;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (LoginService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__6.Target((CallSite) LoginService.\u003C\u003Eo__4.\u003C\u003Ep__6, responseData, ".expires");
        DateTime? nullable2 = target4((CallSite) p7, obj4);
        tokenData5.Expires = nullable2;
        TokenData tokenData6 = tokenData1;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__9 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (LoginService)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, int> target5 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__9.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, int>> p9 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__9;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "expires_in", typeof (LoginService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__8.Target((CallSite) LoginService.\u003C\u003Eo__4.\u003C\u003Ep__8, responseData);
        int num = target5((CallSite) p9, obj5);
        tokenData6.ExpiresInSeconds = num;
        tokenData1.IsValid = true;
        tokenData = tokenData1;
      }
      else
      {
        TokenData tokenData7 = new TokenData();
        TokenData tokenData8 = tokenData7;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__11 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (LoginService)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__11.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p11 = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__11;
        // ISSUE: reference to a compiler-generated field
        if (LoginService.\u003C\u003Eo__4.\u003C\u003Ep__10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LoginService.\u003C\u003Eo__4.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "error", typeof (LoginService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = LoginService.\u003C\u003Eo__4.\u003C\u003Ep__10.Target((CallSite) LoginService.\u003C\u003Eo__4.\u003C\u003Ep__10, responseData);
        string str3 = target((CallSite) p11, obj);
        tokenData8.ErrorMessage = str3;
        tokenData = tokenData7;
      }
      TokenData tokenDataAsync = tokenData;
      tokenData = (TokenData) null;
      responseData = (object) null;
      return tokenDataAsync;
    }

    public async Task<TokenData> LoginAsync(string username, string password)
    {
      TokenData tokenData;
      using (HttpClient httpClient = new HttpClient())
      {
        ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((sender, certificate, chain, sslPolicyErrors) => true);
        FormUrlEncodedContent loginContent = this.GenerateLoginContent(username, password);
        HttpResponseMessage response = await httpClient.PostAsync(this.tokenServiceUrl, (HttpContent) loginContent);
        tokenData = await this.GenerateTokenDataAsync(response);
        loginContent = (FormUrlEncodedContent) null;
        response = (HttpResponseMessage) null;
      }
      TokenData tokenData1 = tokenData;
      tokenData = (TokenData) null;
      return tokenData1;
    }

    public async Task<TokenData> LoginRefreshAsync(string refreshToken)
    {
      TokenData tokenData;
      using (HttpClient httpClient = new HttpClient())
      {
        ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((sender, certificate, chain, sslPolicyErrors) => true);
        FormUrlEncodedContent loginContent = this.GenerateLoginRefreshContent(refreshToken);
        HttpResponseMessage response = await httpClient.PostAsync(this.tokenServiceUrl, (HttpContent) loginContent);
        tokenData = await this.GenerateTokenDataAsync(response);
        loginContent = (FormUrlEncodedContent) null;
        response = (HttpResponseMessage) null;
      }
      TokenData tokenData1 = tokenData;
      tokenData = (TokenData) null;
      return tokenData1;
    }
  }
}
