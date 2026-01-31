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

    /// <summary>
    /// Retrieves the unique identifier from the UserProfile model,
    /// so that we know which user is submitting the response.
    /// </summary>
    public int UserProfileId { get; set; }

    /// <summary>
    /// Retrieves the unique identifier from the Questionnaire model, 
    /// so that we know which question the user is responding to.
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    /// Stores the user's answer(s) to the questionnaire question.
    /// </summary>
    public required string UserResponse { get; set; }
}
