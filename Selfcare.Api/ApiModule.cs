// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.ApiModule
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Autofac;
using FluentValidation;
using FluentValidation.WebApi;
using Selfcare.Api.Models.Accounts;
using Selfcare.Api.Models.Assets;
using Selfcare.Api.Models.Case;
using Selfcare.Api.Models.Login;
using Selfcare.Api.Models.MasterTable;
using Selfcare.Api.Models.Payment;
using Selfcare.Api.Models.Users;
using Selfcare.Api.Validations;
using Selfcare.Api.Validations.Accounts;
using Selfcare.Api.Validations.Assets;
using Selfcare.Api.Validations.Case;
using Selfcare.Api.Validations.Login;
using Selfcare.Api.Validations.MasterTables;
using Selfcare.Api.Validations.Payment;
using Selfcare.Api.Validations.Users;
using System.Web.Http.Validation;

#nullable disable
namespace Selfcare.Api
{
  public class ApiModule : Module
  {
    protected virtual void Load(ContainerBuilder builder)
    {
      RegistrationExtensions.RegisterType<FluentValidationModelValidatorProvider>(builder).As<ModelValidatorProvider>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<ValidatorFactory>(builder).As<IValidatorFactory>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<UserRegistrationValidationValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<UserRegistrationValidationModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<UserRegistrationValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<UserRegistrationModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<LoginValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<LoginModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<LoginRefreshValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<LoginRefreshModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<RegisterAccountTopupValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<RegisterAccountTopupModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<CustomerAccountValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<CustomerAccountModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<AccountTransactionsValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<AccountTransactionsRetrieveModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<AssetsRetrieveParametersValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<AssetsRetrieveParametersModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<AnonymousPaymentRegisterValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<AnonymousPaymentRegisterModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<CaseCreateValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<CaseCreateModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<UserChangePasswordValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<UserChangePasswordModel>)).InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<CaseRetrieveParametersValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<CasesRetrieveParametersModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<RetrieveFinancialDocumentsValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<RetrieveFinancialDocumentsParametersModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<UserForgotPasswordValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<UserForgotPasswordModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<UserResetPasswordValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<UserResetPasswordModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<RetrieveAnonymousTransactionsValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<AnonymousTransactionsRetrieveParametersModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<PaymentObtainSessionValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<PaymentDetailsModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<EmiratesRetrieveParametersValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<PlateTypeCategoryRetrieveParametersModel>)).As<IValidator>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<DashboardValidator>(builder).Keyed<IValidator>((object) typeof (IValidator<DashboardRetrieveModel>)).As<IValidator>().InstancePerLifetimeScope();
    }
  }
}
