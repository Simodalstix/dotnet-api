namespace dotnet_api;

public class Score
{
    public int Id { get; set; }
    public string AthleteName { get; set; } = string.Empty;
    public string WorkoutName { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public DateTime CompletedAt { get; set; }
}