using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using KOExamApp.DAL.Models;

namespace KOExamApp.BLL.Dtos
{
    public class ArticleDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [AllowHtml]
        [Display(Name = "Content")]
        public string Text { get; set; }
        [Required]
        public string Guid { get; set; }

        private IList<ExamDto> _exams = new List<ExamDto>();
        public IList<ExamDto> Exams
        {
            get { return _exams; }
            set { _exams = value; }
        }
        public void AddExam(ExamDto exam)
        {
            _exams.Add(exam);
            exam.Article = this;
        }
    }
}
