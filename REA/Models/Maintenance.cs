namespace REA.Models;

public class Maintenance {
    public required string Name { get; set; }
    public required DateTime ScheduledDate { get; set; }
    public required string AssignedUser { get; set; }
    public required string Type { get; set; }
}