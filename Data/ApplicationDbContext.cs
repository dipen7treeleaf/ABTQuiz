using System;
using System.Collections.Generic;
using System.Text;
using ABTQuiz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ABTQuiz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QuizQuestions> QuizQuestions { get; set; }
        public DbSet<PlayerScore> PlayerScores { get; set; }
    }
}