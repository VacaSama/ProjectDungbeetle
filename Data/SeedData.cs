using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.Data;


/// <summary>
/// This class seeds data into the database. 
/// </summary>
public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new DungbeetleDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<DungbeetleDbContext>>()
        );

        // if the database context does not have any entries then ADD sample entries
        if (!context.Entries.Any())
        {
            // *** SAMPLE ENTRY *** 
            context.Entries.Add( // .Add
                new Models.Entry
                {
                    // sample entry that the user can delete later
                    Title = "Hello World!",
                    CodingLanguage = "C#",
                    Notes = "Welcome to Project Dungbeetle, this is a sample entry." +
                    "\nFeel free to delete me later. This sample shows you how one of your," +
                    "entries may be structured in the future.",
                    CodeSnippet = "for (int i = 0; i < 10; i++) { Console.WriteLine(\"Hello, World!\"); }",
                    ErrorDescription = "This is where you would write about what's going on!"

                }
            );
        }

        if (!context.Hints.Any())
        {
            // *** SAMPLE HINTS ***
            context.Hints.AddRange( // .AddRange to add multiple entities at once
                new Models.Hints
                {
                    HintText = "Sometimes a misplaced semicolon (;) or bracket ({}) can cause unexpected errors." +
                    "\nDo a double-check and start there!",
                    HintCategory = "Syntax"
                },

                new Models.Hints
                {
                    HintText = "If your code compiles but doesn't behave as expected, review your logic flow." +
                    "\nConsider adding print statements to trace variable values.",
                    HintCategory = "Logic"
                }
            );
        }

        if (!context.Questionnaires.Any())
        {
            // *** SAMPLE QUESTIONS FOR QUESTIONNAIRE **** 
            context.Questionnaires.AddRange(
                new Models.Questionnaire
                {
                    QuestionText = "Which coding language(s) are you learning? Check all that apply.",
                    QuestionType = QuestionType.Checkbox,
                    Options = "C#, Java, Python, C++, JavaScript", // starting with simple options for now...
                },

                new Models.Questionnaire
                {
                    QuestionText = "How confident do you feel about your coding skills overall?",
                    QuestionType = QuestionType.RadioButton,
                    Options = "Very Confident, Somewhat Confident, Neutral, Somewhat Unconfident, Very Unconfident"

                },

                new Models.Questionnaire
                {
                    QuestionText = "What type of coding problems do you struggle with the most? Check all that apply.",
                    QuestionType = QuestionType.Checkbox,
                    Options = "Syntax Errors, Logic Errors, Debugging, Understanding Concepts"
                },

                new Models.Questionnaire
                {
                    QuestionText = "What are you using Project Dungbeetle for?",
                    QuestionType = QuestionType.RadioButton,
                    Options = "Personal Use, Professional Improvement, Academic Purposes, For Fun"
                }
            );

            context.SaveChanges();
        }
    }
}