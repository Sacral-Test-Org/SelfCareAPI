// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Mappings.UserProfile
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using AutoMapper;
using Selfcare.Domain.BackOffice.Models.Users;
using Selfcare.Infrastructure.Entities.Users;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Domain.BackOffice.Mappings
{
  internal class UserProfile : Profile
  {
    public UserProfile()
    {
      this.CreateMap<ValidateCustomerResponseModel, UserRegistrationValidationData>().ForMember<bool>((Expression<Func<UserRegistrationValidationData, bool>>) (dest => dest.IsValid), (Action<IMemberConfigurationExpression<ValidateCustomerResponseModel, UserRegistrationValidationData, bool>>) (opt => opt.MapFrom<bool>((Expression<Func<ValidateCustomerResponseModel, bool>>) (src => src.Found)))).ForMember<int>((Expression<Func<UserRegistrationValidationData, int>>) (dest => dest.UserCustomerId), (Action<IMemberConfigurationExpression<ValidateCustomerResponseModel, UserRegistrationValidationData, int>>) (opt => opt.MapFrom<int>((Expression<Func<ValidateCustomerResponseModel, int>>) (src => src.CustomerId))));
      this.CreateMap<UserDataResponseModel, UserViewData>().ForMember<int>((Expression<Func<UserViewData, int>>) (dest => dest.Id), (Action<IMemberConfigurationExpression<UserDataResponseModel, UserViewData, int>>) (opt => opt.MapFrom<int>((Expression<Func<UserDataResponseModel, int>>) (src => src.CustomerId))));
    }
  }
}
