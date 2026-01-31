using System.ComponentModel.DataAnnotations;
namespace ProjectDungbeetle.Models;
/// <summary>
/// The Entry class that represents a User created entry. 
/// Entries are notes or errors that the user wants to keep track of, 
/// it also acts as a reflective log that the user can use to improve their 
/// skills in computer programming and debugging. 
/// </summary>
public class Entry
{
    /// <summary>
    /// Sets the unique identifier for the user made entry
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    ///  This is the title of the entry made by the user. 
    ///  The max length of characters will be set to 75 characters to avoid 
    ///  super long titles that are hard to read.
    /// </summary>
    [StringLength(75)]
    public required string Title { get; set; }

    /// <summary>
    /// Sets the description of the error that the user has encountered, 
    /// this can also be null if the entry is just a code snippet with notes. Or just notes.
    /// </summary>
    public string? ErrorDescription { get; set; }

    /// <summary>
    /// Gets or sets the programming language associated with the code or content.
    /// At least one coding language must be selected for the entry.
    /// </summary>
    public required string CodingLanguage { get; set; }

    /// <summary>
    /// Allows the user to save a code snippet that was causing an error, 
    /// useful for debugging and/ or reflective learning. Or the user can use this 
    /// to save useful loops, functions, etc.
    /// </summary>
    public required string CodeSnippet { get; set; }

    /// <summary>
    /// Allows the user to save notes about the error, code snippet, or general concepts .
    /// Notes are not required, but highly encouraged.
    /// </summary>
    public string? Notes { get; set; }

}
