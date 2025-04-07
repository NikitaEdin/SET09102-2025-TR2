namespace REA.Models;

public class Alert {
    public required object Metadata { get; set; }
    public required string Message { get; set; }
    public required DateTime TriggeredAt { get; set; }
}