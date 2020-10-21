using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABTQuiz.Data;
using ABTQuiz.Models;

namespace ABTQuiz.Pages.Quiz.QAList
{
    public class DetailsModel : PageModel
    {
        private readonly ABTQuiz.Data.ApplicationDbContext _context;

        public DetailsModel(ABTQuiz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public QuizQuestions QuizQuestions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuizQuestions = await _context.QuizQuestions.FirstOrDefaultAsync(m => m.Id == id);

            if (QuizQuestions == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
