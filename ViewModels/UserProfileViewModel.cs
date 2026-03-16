using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.ViewModels;

public class UserProfileViewModel
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public UserOccupation? Occupation { get; set; }
    public ExperienceLevel? ExperienceLevel { get; set; }
    public List<Questionnaire>? QuestionniareData { get; set; }

    public List<QuestionnaireResponse>? UserResponseData { get; set; }
}
