// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Mappings.CaseProfile
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using AutoMapper;
using Selfcare.Domain.BackOffice.Models.Case;
using Selfcare.Infrastructure.Entities.Case;

#nullable disable
namespace Selfcare.Domain.BackOffice.Mappings
{
  internal class CaseProfile : Profile
  {
    public CaseProfile() => this.CreateMap<CreateCaseViewData, CreateCaseResponseModel>();
  }
}
