using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.ViewModels;

public class UserProfileViewModel
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public UserOccupation? Occupation { get; set; }
    public ExperienceLevel? ExperienceLevel { get; set; }
    public LearningLanguages LearningLanguages { get; set; }
    public IntendedUse IntendedUse { get; set; }
}
