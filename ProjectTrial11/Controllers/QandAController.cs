using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTrial11.Data;
using ProjectTrial11.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjectTrial11.Controllers
{
    [Authorize]
    public class QandAController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QandAController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult QAndA()
        {
            var questions = _context.Question.Include(q => q.Comments).OrderByDescending(q => q.DatePosted).ToList();
            return View(questions);
        }

        public IActionResult AskQuestion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int questionId, string commentBody)
        {
            // Retrieve the question from the database
            var question = _context.Question.Include(q => q.Comments).FirstOrDefault(q => q.Id == questionId);

            if (question == null)
            {
                return NotFound(); // Or handle the case when the question is not found
            }

            // Create a new comment
            var newComment = new Comment
            {
                Body = commentBody,
                DatePosted = DateTime.Now, // Assuming you want to set the DatePosted to the current date and time
                QuestionId = questionId,
                Likes = 0,
                Dislikes = 0
            };

            // Initialize the Comments collection if it's null
            if (question.Comments == null)
            {
                question.Comments = new List<Comment>();
            }

            // Add the comment to the question
            question.Comments.Add(newComment);

            // Save changes to the database
            _context.SaveChanges();

            // Redirect back to the original question page or wherever you'd like
            return RedirectToAction("QAndA");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AskQuestion(Question question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Set default values for Likes and Dislikes
                    question.Likes = 0;
                    question.Dislikes = 0;

                    // Set the date posted
                    question.DatePosted = DateTime.Now;

                    // Add the question to the context
                    _context.Question.Add(question);
                    _context.SaveChanges();

                    // If it's an AJAX request, return a JSON result
                    if (Request.Headers["x-requested-with"] == "XMLHttpRequest")
                    {
                        return Json(new { success = true });
                    }

                    // Redirect to the QAndA action to refresh the question list
                    return RedirectToAction("QAndA");
                }
                else
                {
                    // Log ModelState errors for debugging
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine(ex.Message);
            }

            // Retrieve the updated list of questions
            var questions = _context.Question.Include(q => q.Comments).OrderByDescending(q => q.DatePosted).ToList();

            // Return the view with the list of questions
            return View("QAndA", questions);
        }
    }
}