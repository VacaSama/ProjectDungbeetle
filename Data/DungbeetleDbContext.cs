namespace ProjectDungbeetle.Data;
using Microsoft.EntityFrameworkCore;
using ProjectDungbeetle.Models;
using Microsoft.Identity.Client;

public class DungbeetleDbContext : DbContext
{
    public DungbeetleDbContext(DbContextOptions<DungbeetleDbContext> options) : base(options)
    {
        // nothing to see here :) 
    }

    // declare DBSets/Models/ aka tables here 

    /// <summary>
    /// Retrieves or sets the collection of Entry objects in the database.
    /// </summary>
    public DbSet<Entry> Entries { get; set; }

    /// <summary>
    /// Retrieves or sets the collection of Hints objects in the database.
    /// </summary>
    public DbSet<Hints> Hints { get; set; }

    /// <summary>
    /// Retrieves or sets the collection of Questionnaire(questions) objects in the database.
    /// </summary>
    public DbSet<Questionnaire> Questionnaires { get; set; }

    /// <summary>
    /// Retrieves or sets the collection of QuestionnaireResponse objects in the database.
    /// Based per user.
    /// </summary>
    public DbSet<QuestionnaireResponse> QuestionnaireResponses { get; set; }

    /// <summary>
    /// Retrieves or sets the collection of UserProfile objects in the database.
    /// Based per user.
    /// </summary>
    public DbSet<UserProfile> UserProfiles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
