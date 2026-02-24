using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectDungbeetle.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            context.Entries.AddRange( // .Add changed to .AddRange
                new Models.Entry
                {
                    // sample entry that the user can delete later
                    Title = "Hello World!",
                    CodingLanguage = "C#",
                    Notes = "Welcome to Project Dungbeetle, this is a sample entry." +
                    "\nFeel free to delete me later. This sample shows you how one of your," +
                    "entries may be structured in the future.",
                    CodeSnippet = "for (int i = 0; i < 10; i++) { Console.WriteLine(\"Hello, World!\"); }",
                    ErrorDescription = "This is where you would write about what's going on!", 
                    CreatedAt = DateTime.Now
                },

                new Models.Entry
                {
                    Title = "Loop Confusion",
                    CodingLanguage = "C#",
                    Notes = "Today I practiced for-loops and while-loops. I learned that a for-loop is better " +
                    "when you know how many times you want to run, and a while-loop is better when you " +
                    "don’t. I kept mixing up my conditions, so this is something I need to review.",
                    CodeSnippet = "int count = 0;\nwhile (count < 5)\n{\n    Console.WriteLine(\"Count is: \" + count);\n    count++;\n}",
                    ErrorDescription = "I forgot to increment the counter, which caused an infinite loop.",
                    CreatedAt = DateTime.Now
                }
            );
        }

        if (!context.Hints.Any())
        {
            // *** SAMPLE HINTS ***
            context.Hints.AddRange( // .AddRange to add multiple entities at once
                new Models.Hints // Hint 1
                {
                    HintText = "Sometimes a misplaced semicolon (;) or bracket ({}) can cause unexpected errors." +
                    "\nDo a double-check and start there!",
                    HintCategory = "Syntax"
                },

                new Models.Hints // Hint 2
                {
                    HintText = "If your code compiles but doesn't behave as expected, review your logic flow." +
                    "\nConsider adding print statements to trace variable values.",
                    HintCategory = "Logic"
                },
                
                new Models.Hints // Hint 3
                {
                    HintText = "\"Remember to name variables meaningfully; vague names like 'x' " +
                    "or 'temp' can make debugging harder.\"",
                    HintCategory = "Best Practices"
                },

                new Models.Hints // Hint 4
                {
                    HintText = "Check for nulls before accessing objects to avoid runtime errors.",
                    HintCategory = "Runtime Errors"
                },

                new Models.Hints // Hint 5
                {
                    HintText = "Use loops wisely: a for-loop is ideal when you know the iteration count;" +
                    "\na while-loop works when you need a condition-based loop.",
                    HintCategory = "Logic"
                },

                new Models.Hints // Hint 6
                {
                    HintText = "When debugging,isolate the smallest failing part of the code." +
                    "\nIt’s easier than scanning the entire program.",
                    HintCategory = "Logic"
                },

                new Models.Hints // Hint 7
                {
                    HintText = "Avoid Mismatched Data Types, assigning a value to a variable of an incompatible type" +
                    "\ncan lead to errors,such as trying to add an integer to a string.",
                    HintCategory = "Best Practices"
                }
            );
        }

        if (!context.Questionnaires.Any())
        {
            // *** SAMPLE QUESTIONS FOR QUESTIONNAIRE **** 
            // For the options split the strings up before the comma(,)
            context.Questionnaires.AddRange(
                new Models.Questionnaire
                {
                    QuestionText = "Which coding language(s) are you learning? Check all that apply.",
                    IsMultiple = true, // this is a checkbox question
                    Options = "C#, Java, Python, C++, JavaScript", // starting with simple options for now...
                },

                new Models.Questionnaire
                {
                    QuestionText = "How confident do you feel about your coding skills overall?",
                    IsMultiple = false, // this is a radio button
                    Options = "Very Confident, Somewhat Confident, Neutral, Somewhat Unconfident, Very Unconfident"

                },

                new Models.Questionnaire
                {
                    QuestionText = "What type of coding problems do you struggle with the most? Check all that apply.",
                    IsMultiple = true,// this is a checkbox question
                    Options = "Syntax Errors, Logic Errors, Debugging, Understanding Concepts"
                },

                new Models.Questionnaire
                {
                    QuestionText = "What are you using Project Dungbeetle for?",
                    IsMultiple = false, // this is a radio button
                    Options = "Personal Use, Professional Improvement, Academic Purposes, For Fun"
                }
            );

            context.SaveChanges();
        }
    }
}