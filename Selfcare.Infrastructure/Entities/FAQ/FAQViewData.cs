// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.FAQ.FAQViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.FAQ
{
  public class FAQViewData
  {
    public int Id { get; set; }

    public string QuestionEn { get; set; }

    public string QuestionAr { get; set; }

    public string QuestionUr { get; set; }

    public string AnswerEn { get; set; }

    public string AnswerAr { get; set; }

    public string AnswerUr { get; set; }

    public FAQCategoryViewData Category { get; set; }
  }
}
