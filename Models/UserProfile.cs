namespace ProjectDungbeetle.Models;

/// <summary>
/// The UserProfile class that represents a user's profile information.
/// It keeps track of what coding languages the user is learning, their skill level, 
/// the intended use of the application, cookie detection, and other relevant details.
/// </summary>
public class UserProfile
{
    /// <summary>
    /// Sets the unique identifier for the user made entry
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the experience level associated with the user,
    /// and their codin skills asociated with each selected one.
    /// </summary>
    public int ExperienceLevel { get; set; }

    /// <summary>
    /// Asks the user what coding languages they are currently learning. 
    /// Connected to CodingLanguage in Entry model.
    /// </summary>
    public string LearningLanguages { get; set; }

    /// <summary>
    /// Asks the user what their goal is for using this application
    /// </summary>
    public string IntendedUse { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cookies are enabled for the current session.
    /// Cookies are enabled by default to trigger the questionnaire only once, 
    /// for new users. Returning users will not see the questionnaire again, but can 
    /// update their response. 
    /// </summary>
    public bool CookiesEnabled { get; set; } = true;

}
