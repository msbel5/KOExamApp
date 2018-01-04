using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOExamApp.DAL.Models
{
    public class Question
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Question")]
        public string Query { get; set; }
        [Required]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        private IList<Choice> _choices = new List<Choice>();
        public IList<Choice> Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }
        public void AddChoice(Choice choice)
        {
            _choices.Add(choice);
            choice.Question = this;
        }

    }
}
