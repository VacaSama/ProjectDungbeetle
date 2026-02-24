using System.ComponentModel.DataAnnotations;
namespace ProjectDungbeetle.Models;

/// <summary>
/// Represents a collection of questions for the user to answer when they first
/// use the application. 
/// 
/// Ex: What coding languages they are learning, what their experience level is, 
/// what their learning goals are, etc.
/// </summary>
/// 
public class Questionnaire
{
    /// <summary>
    /// Sets the unique identifier for the questionnaire
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Asks the user a specific question to gather information about their
    /// coding experience and goals.
    /// </summary>
    public required string QuestionText { get; set; } // What languages are you learning?, What is your experience level?


    /// <summary>
    /// Separates the different possible answers the user can select from.
    /// Checkbox Question Type will allow a check all that apply format. 
    /// While, Radio Button Question Type will allow ONLY ONE selection.
    ///                                         Radio Button (select 1 ONLY!), 
    ///  If the value Is a Multiple then it is a checkbox question, Else
    ///  it must ne a radio button
    /// </summary>                                
    public required bool IsMultiple { get; set; }

    /// <summary>
    /// Gets or sets the possible answer options for the question.
    /// </summary>
    public required string Options { get; set; } 
}
