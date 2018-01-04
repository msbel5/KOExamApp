using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KOExamApp.DAL.Models
{
    public class Exam
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        private IList<Question> _questions = new List<Question>();

        public IList<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        public void AddQuestion(IList<Question> questions)
        {
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }
    }
}
