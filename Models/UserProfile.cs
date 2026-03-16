using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectDungbeetle.Models;

/// <summary>
/// An enum that gives the user options to choose from with their
/// UserExperience when changing their user profile.
/// </summary>
public enum UserOccupation
{
    Student,

    [Display(Name = "Teacher/Instructor")]
    Teacher,

    [Display (Name = "Software Developer")]
    Developer,

    [Display(Name = "Computer Programmer")]
    Programmer,

    Other
}

/// <summary>
/// An enum that gives the user options to choose from with their ExperienceLevel when changing their user profile.
/// </summary>
public enum ExperienceLevel
{
    [Display(Name = "Coding Newbie")]
    Beginner,

    [Display(Name = "Entry-Level Coder")]
    Intermediate,

    [Display(Name = "Advanced Coder")]
    Advanced,

    [Display(Name = "Expert Coder")]
    Expert
}

/// <summary>
/// An enum that gives the user options to choose from with their IntendedUse when changing their user profile.
/// </summary>
public enum IntendedUse
{
    Personal,
    Professional,
    Academic,
    Hobbyist
}


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
    /// Allows the user to input their name or a nickname that they prefer to be called. 
    /// This is optional and can be left blank if the user prefers.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the user's occupation, which can be selected from a predefined list. 
    /// Used with the UserOccupation enum to provide a dropdown selection for the user.
    /// </summary>
    public UserOccupation? Occupation { get; set; }

    /// <summary>
    /// Gets or sets the experience level associated with the user,
    /// and their coding skills asociated with each selected one.
    /// 
    /// Works with the ExperienceLevel enum to provide a dropdown selection for the user. 
    /// </summary>
    public ExperienceLevel? ExperienceLevel { get; set; }

}
