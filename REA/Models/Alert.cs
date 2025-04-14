using REA.DB;
using SQLite;

namespace REA.Models;

[Table("Alerts")]
public class Alert {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int Metadata_ID { get; set; }
    public string Message { get; set; }
    public string TriggeredAt { get; set; }

    public DateTime GetTriggeredAtDateTime() {
        return DateTime.Parse(TriggeredAt);
    }

    public static async Task<List<Alert>> GetAllAlertsAsync() {
        var items = await SQLiteDatabaseService.Instance.GetItemsAsync<Alert>();
        return items?.ToList() ?? new List<Alert>();
    }
}