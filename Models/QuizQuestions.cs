using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABTQuiz.Models
{
    public class QuizQuestions
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string AnswerOne { get; set; }
        [Required]
        public string AnswerTwo { get; set; }
        [Required]
        public string AnswerThree { get; set; }
        [Required]
        public string AnswerFour { get; set; }
        [Required]
        public string CorrectAns { get; set; }
    }
}
