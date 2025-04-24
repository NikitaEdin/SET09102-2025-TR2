using REA.DB;
using SQLite;

namespace REA.Models;

[Table("Maintenance")]
public class Maintenance {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string ScheduledDate { get; set; }
    public int AssignedUser { get; set; }
    public string Type { get; set; }

    public DateTime GetScheduledAtDateTime() {
        return DateTime.Parse(ScheduledDate);
    }

    public static async Task<List<Maintenance>> GetAllMaintenanceAsync() {
        var items = await SQLiteDatabaseService.Instance.GetItemsAsync<Maintenance>();
        return items?.ToList() ?? new List<Maintenance>();
    }
}