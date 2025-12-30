using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoresController : ControllerBase
{
    // In-memory storage (resets when app restarts)
    private static readonly List<Score> _scores = new()
    {
        new Score
        {
            Id = 1,
            AthleteName = "John Smith",
            WorkoutName = "Fran",
            Result = "3:45",
            CompletedAt = DateTime.Now.AddDays(-1)
        },
        new Score
        {
            Id = 2,
            AthleteName = "Sarah Johnson",
            WorkoutName = "Fran",
            Result = "4:12",
            CompletedAt = DateTime.Now.AddDays(-1)
        },
        new Score
        {
            Id = 3,
            AthleteName = "Mike Wilson",
            WorkoutName = "Grace",
            Result = "2:58",
            CompletedAt = DateTime.Now.AddHours(-3)
        }
    };

    [HttpGet]
    public IEnumerable<Score> Get()
    {
        return _scores;
    }

    [HttpPost]
    public ActionResult<Score> Post([FromBody] CreateScoreRequest request)
    {
        var score = new Score
        {
            Id = _scores.Count > 0 ? _scores.Max(s => s.Id) + 1 : 1,
            AthleteName = request.AthleteName,
            WorkoutName = request.WorkoutName,
            Result = request.Result,
            CompletedAt = DateTime.Now
        };

        _scores.Add(score);
        
        return CreatedAtAction(nameof(Get), new { id = score.Id }, score);
    }
}