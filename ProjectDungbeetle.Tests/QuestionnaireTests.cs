using Xunit;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Text;
using ProjectDungbeetle.Data;
using ProjectDungbeetle.Controllers;
using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.Tests;

/// <summary>
/// Contains unit tests for verifying the behavior of questionnaire-related functionality in the application.
/// </summary>
/// <remarks>This class uses the xUnit testing framework to ensure that questionnaire responses are saved and
/// managed correctly. Tests within this class typically interact with an in-memory database to validate data
/// persistence and integrity.</remarks>
public class QuestionnaireTests
{
    [Fact]
    public void SaveQuestionnaire_SavesResponsesCorrectly()
    {
        // Arrange: create fake DB
        var options = new DbContextOptionsBuilder<DungbeetleDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        using var context = new DungbeetleDbContext(options);

        // Add a fake user profile
        var profile = new UserProfile { Id = 1 };
        context.UserProfiles.Add(profile);
        context.SaveChanges();

        // Create fake form data
        var form = new FormCollection(new Dictionary<string, StringValues>
        {
            { "q-1", "Personal Use" },
            { "q-2", "C#, JavaScript" }
        });

        var controller = new HomeController(context);

        // Act: call the method
        controller.SaveQuestionnaire(form);

        // Assert: verify DB results
        var responses = context.QuestionnaireResponses.ToList();

        Assert.Equal(2, responses.Count);

        Assert.Contains(responses, r =>
            r.QuestionId == 1 &&
            r.UserResponse == "Personal Use");

        Assert.Contains(responses, r =>
            r.QuestionId == 2 &&
            r.UserResponse == "C#, JavaScript");
    }
}
