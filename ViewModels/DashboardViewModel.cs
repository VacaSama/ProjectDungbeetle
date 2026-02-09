using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.ViewModels;

public class DashboardViewModel
{
    /// <summary>
    /// Retrieves the users profile information to be displayed on the dashboard
    /// this includes basic information about the user from the questionnaire.
    /// </summary>
    public UserProfile UserProfile { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Entry> Entries { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Hints> Hints { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Questionnaire Questionnaire { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public QuestionnaireResponse UserResponse { get; set; }
}
