using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.DAL.Models;

namespace KOExamApp.BLL.Dtos
{
    public class ExamDto
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArticleId { get; set; }

        public ArticleDto Article { get; set; }

        private IList<QuestionDto> _questions = new List<QuestionDto>();

        public IList<QuestionDto> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        public void AddQuestion(IList<QuestionDto> questions)
        {
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public void AddQuestion(QuestionDto question)
        {
            _questions.Add(question);
        }

        public List<string> CorrectChoicesGuid { get; set; }
    }
}
