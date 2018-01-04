using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.DAL.Models;

namespace KOExamApp.BLL.Dtos
{
    public class QuestionDto
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Question")]
        public string Query { get; set; }
        [Required]
        public int ExamId { get; set; }
        public ExamDto Exam { get; set; }

        private IList<ChoiceDto> _choices = new List<ChoiceDto>();
        public IList<ChoiceDto> Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }
        public void AddChoice(ChoiceDto choice)
        {
            _choices.Add(choice);
            choice.Question = this;
        }
    }
}
