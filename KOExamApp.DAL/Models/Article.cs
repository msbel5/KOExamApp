using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KOExamApp.DAL.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [AllowHtml]
        public string Text { get; set; }
        [Required]
        public string Guid { get; set; }

        private IList<Exam> _exams = new List<Exam>();
        public IList<Exam> Exams
        {
            get { return _exams; }
            set { _exams = value; }
        }
        public void AddExam(Exam exam)
        {
            _exams.Add(exam);
            exam.Article = this;
        }
    }
}
