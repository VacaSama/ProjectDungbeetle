using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.ViewModels;

public class UserProfileViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the full name of the entity.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the user's occupation.
    /// </summary>
    public UserOccupation? Occupation { get; set; }

    /// <summary>
    /// Gets or sets the experience level associated with the entity.
    /// </summary>
    public ExperienceLevel? ExperienceLevel { get; set; }

    /// <summary>
    /// Retreives the Questionnaire Data from the questionnaire so that 
    /// the corresponding question can be inserted into the proper input
    /// </summary>
    public List<Questionnaire>? QuestionniareData { get; set; }

    /// <summary>
    /// Gets or sets the collection of questionnaire responses provided by the user.
    /// </summary>
    public List<QuestionnaireResponse>? UserResponseData { get; set; }
}
