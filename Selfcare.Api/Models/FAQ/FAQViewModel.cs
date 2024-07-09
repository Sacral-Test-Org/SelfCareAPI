// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.FAQ.FAQViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

#nullable disable
namespace Selfcare.Api.Models.FAQ
{
  public class FAQViewModel
  {
    public int Id { get; set; }

    public string QuestionEn { get; set; }

    public string QuestionAr { get; set; }

    public string QuestionUr { get; set; }

    public string AnswerEn { get; set; }

    public string AnswerAr { get; set; }

    public string AnswerUr { get; set; }

    public FAQCategoryViewModel Category { get; set; }
  }
}
