using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOExamApp.DAL.Models
{
    public class Choice
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsAnswer { get; set; }
        [Required]
        public string Guid { get; set; }
        [Required]

        public int QuestionId { get; set; }
        
        public Question Question { get; set; }
    }
}
