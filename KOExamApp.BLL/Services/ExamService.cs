using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.BLL.Dtos;

namespace KOExamApp.BLL.Services
{
    public class ExamService
    {
        private ArticleManager _am;
        private QuestionManager _qm;
        private ChoiceManager _cm;
        private ExamManager _em;

        public ExamService()
        {
            _am = new ArticleManager();
            _qm = new QuestionManager();
            _cm = new ChoiceManager();
            _em = new ExamManager();
        }
        public ExamDto CreateExam(int articleId)
        {
            
            ExamDto exam = new ExamDto()
            {
                ArticleId = articleId
            };
            for (int i = 0; i < 1; i++)
            {
                QuestionDto question = new QuestionDto();
                for (int j = 0; j < 2; j++)
                {
                    ChoiceDto choice = new ChoiceDto();
                    question.AddChoice(choice);
                }
                exam.AddQuestion(question);
            }
            return exam;
        }

        public void AddExam(ExamDto exam)
        {
            _em.Add(exam);
        }
    }
}
