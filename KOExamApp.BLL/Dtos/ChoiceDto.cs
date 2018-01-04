using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.DAL.Models;

namespace KOExamApp.BLL.Dtos
{
    public class ChoiceDto
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsAnswer { get; set; }
        [Required]

        public int QuestionId { get; set; }

        public QuestionDto Question { get; set; }
    }
}
