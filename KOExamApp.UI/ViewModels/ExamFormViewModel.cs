using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KOExamApp.BLL.Dtos;

namespace KOExamApp.UI.ViewModels
{
    public class ExamFormViewModel
    {
        public ExamDto Exam { get; set; }

        //public IList<QuestionDto> Questions { get; set; }

        //public QuestionDto Question { get; set; }

        //public IList<ChoiceDto> Choices { get; set; }

        //public ChoiceDto Choice { get; set; }

        public ArticleDto Article { get; set; }

        public string Title
        {
            get
            {
                if (Exam != null && Exam.Id != 0)
                    return "Edit Exam";

                return "New Exam";

            }
        }
    }
}