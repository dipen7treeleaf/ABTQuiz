using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABTQuiz.Models
{
    public class PlayerScore
    {
        [Key]
        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }
        [Required]
        public string AnswerToQOne { get; set; }
        [Required]
        public string AnswerToQTwo { get; set; }
        [Required]
        public string AnswerToQThree { get; set; }
        [Required]
        public string AnswerToQFour { get; set; }
        [Required]
        public string AnswerToQFive { get; set; }
        [Required]
        public string AnswerToQSix { get; set; }
        [Required]
        public string AnswerToQSeven { get; set; }
        [Required]
        public string AnswerToQEight { get; set; }
        [Required]
        public string AnswerToQNine { get; set; }
        [Required]
        public string AnswerToQTen { get; set; }
        [Required]
        public int TotalScore { get; set; }
    }
}
