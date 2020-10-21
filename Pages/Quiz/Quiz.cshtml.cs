using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABTQuiz.Data;
using ABTQuiz.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace ABTQuiz.Pages.Quiz
{
    public class QuizModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public QuizModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<string> QuizAnsList { get;set; }
        public PlayerScore QuizAns { get; set; }
        public IList<QuizQuestions> QuizQuestions { get;set; }
        public bool IsTestComplete { get; set; }
        public int TestScore{ get; set; }
        public async Task OnGetAsync()
        {
            QuizAns = _context.Find<PlayerScore>(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IsTestComplete = QuizAns == null ? false : true;
            TestScore = QuizAns == null ? 0 : QuizAns.TotalScore;
            QuizQuestions = await _context.QuizQuestions.ToListAsync();
        }

        public async Task OnGetRetakeAsync()
        {

            QuizAns = _context.Find<PlayerScore>(User.FindFirstValue(ClaimTypes.NameIdentifier));
            try
            {
                if (QuizAns != null)
                {
                    _context.PlayerScores.Remove(QuizAns);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex) 
            {
                IsTestComplete = QuizAns == null ? false : true;
                TestScore = QuizAns == null ? 0 : QuizAns.TotalScore; 
                ModelState.AddModelError("", "Some error occured During Test Reset");
            }
            finally
            {
                QuizQuestions = await _context.QuizQuestions.ToListAsync();
                QuizAns = _context.Find<PlayerScore>(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            IsTestComplete = QuizAns == null ? false : true;
            TestScore = QuizAns == null ? 0 : QuizAns.TotalScore;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            List<string> answeredQuestion = new List<string>();
            foreach(var ansQ in QuizAnsList)
            {
                if (!string.IsNullOrEmpty(ansQ))
                {
                    answeredQuestion.Add(ansQ);
                }
            }
            if (answeredQuestion.Count() != 10)
            {
                ModelState.AddModelError("", "All the Questions must be Answered");
                QuizQuestions = await _context.QuizQuestions.ToListAsync();
                return Page();
            }
            QuizAns = _context.Find<PlayerScore>(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (QuizAns != null)
            {
                IsTestComplete = QuizAns == null ? false : true;
                TestScore = QuizAns == null ? 0 : QuizAns.TotalScore;
                return Page();
            }

            QuizAns = new PlayerScore();
            QuizAns.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            QuizAns.TotalScore = 0;
            QuizQuestions = await _context.QuizQuestions.ToListAsync();
            for (int i=0; i < 10; i++)
            {
                if (QuizQuestions[i].CorrectAns == QuizAnsList[i])
                {
                    QuizAns.TotalScore += 1;
                }

                switch (i)
                {
                    case 0:
                        QuizAns.AnswerToQOne = QuizAnsList[i];
                        break;
                    case 1:
                        QuizAns.AnswerToQTwo = QuizAnsList[i];
                        break;
                    case 2:
                        QuizAns.AnswerToQThree = QuizAnsList[i];
                        break;
                    case 3:
                        QuizAns.AnswerToQFour = QuizAnsList[i];
                        break;
                    case 4:
                        QuizAns.AnswerToQFive = QuizAnsList[i];
                        break;
                    case 5:
                        QuizAns.AnswerToQSix = QuizAnsList[i];
                        break;
                    case 6:
                        QuizAns.AnswerToQSeven = QuizAnsList[i];
                        break;
                    case 7:
                        QuizAns.AnswerToQEight = QuizAnsList[i];
                        break;
                    case 8:
                        QuizAns.AnswerToQNine = QuizAnsList[i];
                        break;
                    case 9:
                        QuizAns.AnswerToQTen = QuizAnsList[i];
                        break;
                    default:
                        break;
                }
            }
            _context.PlayerScores.Add(QuizAns);

            await _context.SaveChangesAsync();
            IsTestComplete = true;
            TestScore = QuizAns.TotalScore;
            QuizQuestions = await _context.QuizQuestions.ToListAsync();
            return Page();
        }
    }
}
