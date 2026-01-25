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
    public int Id { get; set; }

    /// <summary>
    /// Sets the title of the user made entry
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Sets the description of the error that the use has encountered, 
    /// this can also be null if the entry is just a code snippet with notes. Or just notes.
    /// </summary>
    public string ErrorDescription { get; set; }

    /// <summary>
    /// Gets or sets the programming language associated with the code or content.
    /// </summary>
    public string CodingLanguage { get; set; }

    /// <summary>
    /// Allows the user to save a code snippet that was causing an error, 
    /// useful for debugging and/ or reflective learning.
    /// </summary>
    public string CodeSnippet { get; set; }

    /// <summary>
    /// Allows the user to save notes about the error, code snippet, or general concepts 
    /// </summary>
    public string Notes { get; set; }

    }
