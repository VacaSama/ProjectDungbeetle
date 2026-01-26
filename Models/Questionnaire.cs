using System.ComponentModel.DataAnnotations;
namespace ProjectDungbeetle.Models;

/// <summary>
/// Represents a collection of questions for the user to answer when they first
/// use the application. 
/// 
/// Ex: What coding languages they are learning, what their experience level is, 
/// what their learning goals are, etc.
/// </summary>
public class Questionnaire
{
    /// <summary>
    /// Sets the unique identifier for the questionnaire
    /// </summary>
    public int Id { get; set; }
}
