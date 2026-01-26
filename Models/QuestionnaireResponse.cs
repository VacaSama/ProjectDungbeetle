using System.ComponentModel.DataAnnotations;
namespace ProjectDungbeetle.Models;


/// <summary>
/// Represents the user response to the questionnaire presented to new users. 
//  and records their preferences and learning goals. 
/// </summary>
public class QuestionnaireResponse
{
    /// <summary>
    /// Sets the unique identifier for the user response to 
    /// the questionnaire.
    /// </summary>
    public int Id { get; set; }
}
