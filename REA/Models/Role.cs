using REA.DB;
using SQLite;

namespace REA.Models {
    /// <summary>
    /// Role model holding record data of user roles
    /// Author: Nikita Lanetksy.
    /// </summary>
    [Table("Roles")]
    public class Role {
        [PrimaryKey, AutoIncrement]
        public int RoleID { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public int Power { get; set; }

        /// <summary>
        /// Retrieve all records from database of this type
        /// </summary>
        /// <returns>Return list of Roles from DB</returns>
        public static async Task<List<Role>> GetAllRolesAsync() {
            var roles = await SQLiteDatabaseService.Instance.GetItemsAsync<Role>();
            return roles?.ToList() ?? new List<Role>();
        }

        /// <summary>
        /// Override the base ToString to print all object attributes
        /// </summary>
        /// <returns>String containing all object attributes</returns>
        public override string ToString() {
            return $"RoleID: {RoleID}, Title: {Title}, Description: {Description ?? "None"}, Power: {Power}";
        }
    }
}
