namespace ProjectDungbeetle.Models;

/// <summary>
/// The UserProfile class that represents a user's profile information.
/// It keeps track of what coding languages the user is learning, their skill level, 
/// the intended use of the application, cookie detection, and other relevant details.
/// </summary>
public class UserProfile
{
    /// <summary>
    /// Sets the unique identifier for the user Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the experience level associated with the user,
    /// and their coding skills asociated with each selected one.
    /// 
    /// Works on a scale of 1 to 5, where: 1 = Beginner, 2 = Novice, 
    /// 3 = Intermediate, 4 = Advanced, 5 = Expert.
    /// </summary>
    public required int ExperienceLevel { get; set; } = 1;

    /// <summary>
    /// Asks the user what coding languages they are currently learning. 
    /// This is connected to CodingLanguage property in the Entry model.
    /// 
    /// This is required to help tailor the user experience and understand 
    /// their code issues better. I.e. User 1 has more Java entries, whereas, 
    /// user 2 has a mix of Python and JavaScript entries.
    /// </summary>
    public required string LearningLanguages { get; set; }

    /// <summary>
    /// Asks the user what their goal is for using this application. 
    /// 
    /// Personal use, Professional Development, Academic, Hobby, etc.
    /// </summary>
    public required string IntendedUse { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cookies are enabled for the current session.
    /// Cookies are enabled by default to trigger the questionnaire only once, 
    /// for new users. Returning users will not see the questionnaire again, but can 
    /// update their response. 
    /// </summary>
    public bool CookiesEnabled { get; set; } = true;

}
