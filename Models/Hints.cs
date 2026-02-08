using System.ComponentModel.DataAnnotations;
namespace ProjectDungbeetle.Models;

/// <summary>
/// Provides the user with hints and tips that can help them improve how they are thinking
/// about their issues and errors.
/// </summary>
public class Hints
{
    /// <summary>
    /// Sets the unique identifier for the hints
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Sets the hint text, which provides the user with helpful information
    /// on common issues or errors most programmers face.
    /// </summary>
    public required string HintText { get; set; }

    /// <summary>
    /// Sets the category used to group or classify the hint. So that 
    /// if the user missed the hint, they can search for it by category.
    /// </summary>
    public required string HintCategory { get; set; }
}
