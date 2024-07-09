// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.FAQ.FAQResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.FAQ
{
  public class FAQResponseModel
  {
    public int Id { get; set; }

    public string QuestionEn { get; set; }

    public string QuestionAr { get; set; }

    public string QuestionUr { get; set; }

    public string AnswerEn { get; set; }

    public string AnswerAr { get; set; }

    public string AnswerUr { get; set; }

    public FAQCategoryResponseModel Category { get; set; }
  }
}
