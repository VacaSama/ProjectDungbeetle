using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.ViewModels;

public class DashboardViewModel
{
    /// <summary>
    /// Retrieves the users profile information to be displayed on the dashboard
    /// this includes basic information about the user from the questionnaire.
    /// </summary>
    public UserProfile? UserProfile { get; set; }

    /// <summary>
    ///  Retrieves the users entries to be displayed on the dashboard, 
    ///  this is nullable because the user at some point may not have any entries. 
    ///  Every new user starts with 1-2 sample entries to get them, familiar with the entry creation process
    /// </summary>
    public List<Entry>? Entries { get; set; }

    /// <summary>
    ///  Retrieves hitns from the database to be displayed on the dashboard, 
    ///  later the hints will also have its own section so that the user can view ALL hints. 
    ///  Hints are not user created.
    /// </summary>
    public List<Hints>? Hints { get; set; }

    /// <summary>
    /// Retrieves the Questionnaire for the new user to be displayed as a modal on the dashboard, 
    /// this is used to get basic user information such as programming experience, goals, etc.
    /// </summary>
    public Questionnaire? Questionnaire { get; set; }

    /// <summary>
    /// Retrieves the users response from the questionnaire that they filled out, 
    /// this will be displayed on the User Profile section. But for visibility, at this time
    /// it will also be displayed on the dashboard. 
    /// This is nullable because the user may have skipped the questionnaire.
    /// </summary>
    public QuestionnaireResponse? UserResponse { get; set; }
}
