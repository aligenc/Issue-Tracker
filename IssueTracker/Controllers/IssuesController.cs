using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.Models;
using IssueTracker.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace IssueTracker.Controllers
{
    [Route("api/issues")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueRepository _issueRepository;

        public IssuesController(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Issue>>> GetIssues()
        {
            var issues = await _issueRepository.GetAllIssues();
            return Ok(issues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssueById(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid issue ID.");

            var issue = await _issueRepository.GetIssueById(objectId);
            if (issue == null)
                return NotFound();

            return Ok(issue);
        }

        [HttpPost]
        public async Task<ActionResult<Issue>> CreateIssue(Issue issue)
        {
            var createdIssue = await _issueRepository.CreateIssue(issue);
            return CreatedAtAction(nameof(GetIssueById), new { id = createdIssue.Id }, createdIssue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(string id, Issue issue)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid issue ID.");

            issue.Id = objectId;
            var updated = await _issueRepository.UpdateIssue(issue);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid issue ID.");

            var deleted = await _issueRepository.DeleteIssue(objectId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
