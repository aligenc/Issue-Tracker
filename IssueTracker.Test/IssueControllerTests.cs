using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssueTracker.Controllers;
using IssueTracker.Models;
using IssueTracker.Repositories;
using IssueTracker.Enums;
using MongoDB.Bson;

namespace IssueTracker.Test
{
    public class IssueControllerTests
    {
        private readonly Mock<IIssueRepository> _mockRepository;
        private readonly IssuesController _controller;

        public IssueControllerTests()
        {
            _mockRepository = new Mock<IIssueRepository>();
            _controller = new IssuesController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetIssues_ReturnsOkResult()
        {
            // Arrange
            var issues = new List<Issue>()
            {
                new Issue { Id = ObjectId.GenerateNewId(), Title = "Issue 1", Status = IssueStatus.Open },
                new Issue { Id = ObjectId.GenerateNewId(), Title = "Issue 2", Status = IssueStatus.Closed }
            };

            _mockRepository.Setup(repo => repo.GetAllIssues())
                   .ReturnsAsync(issues);

            // Act
            var result = await _controller.GetIssues();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<List<Issue>>(okResult.Value);
            Assert.Equal(2, model.Count); 
        }

        [Fact]
        public async Task CreateIssue_ReturnsCreatedResult()
        {
            // Arrange
            var newIssue = new Issue { Title = "New Issue", Status = IssueStatus.Open };
            _mockRepository.Setup(repo => repo.CreateIssue(It.IsAny<Issue>()))
                           .ReturnsAsync(newIssue); // Assuming the issue creation is successful

            // Act
            var result = await _controller.CreateIssue(newIssue);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var model = Assert.IsType<Issue>(createdResult.Value);
            Assert.Equal("New Issue", model.Title);
            Assert.Equal(IssueStatus.Open, model.Status);
        }

        [Fact]
        public async Task UpdateIssue_ReturnsNoContentResult()
        {
            // Arrange
            var existingIssueId = ObjectId.GenerateNewId();
            var updatedIssue = new Issue { Id = existingIssueId, Title = "Updated Issue", Status = IssueStatus.Closed };
            _mockRepository.Setup(repo => repo.UpdateIssue(It.IsAny<Issue>()))
                           .ReturnsAsync(true); // Assuming the update operation was successful

            // Act
            var result = await _controller.UpdateIssue(existingIssueId.ToString(), updatedIssue);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteIssue_ReturnsNoContentResult()
        {
            // Arrange
            var existingIssueId = ObjectId.GenerateNewId();
            _mockRepository.Setup(repo => repo.DeleteIssue(It.IsAny<ObjectId>()))
                           .ReturnsAsync(true); // Assuming the delete operation was successful

            // Act
            var result = await _controller.DeleteIssue(existingIssueId.ToString());

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
