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
    public class IndexModel : PageModel
    {
        private readonly ABTQuiz.Data.ApplicationDbContext _context;

        public IndexModel(ABTQuiz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<QuizQuestions> QuizQuestions { get;set; }

        public async Task OnGetAsync()
        {
            QuizQuestions = await _context.QuizQuestions.ToListAsync();
        }
    }
}
