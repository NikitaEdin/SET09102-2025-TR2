using REA.DB;
using SQLite;

namespace REA.Models {
    /// <summary>
    /// Represents a user role record
    /// </summary>
    /// 
    /// \author Nikita Lanetsky
    [Table("Roles")]
    public class Role {
        /// <summary>Unique identifier for role</summary>
        [PrimaryKey, AutoIncrement]
        [Column("role_id")]
        public int RoleID { get; set; }

        /// <summary>Title of the role</summary>
        public string Title { get; set; }

        /// <summary>Optional description of the role's purpose/permissions</summary>
        public string? Description { get; set; }

        /// <summary>Numeric value representing the role's authority or access level (between 0 and 100)</summary>
        public int Power { get; set; }

        /// <summary>
        /// Returns a string representation of the record
        /// </summary>
        /// <returns>String containing all record's attributes</returns>
        public override string ToString() {
            return $"RoleID: {RoleID}, Title: {Title}, Description: {Description ?? "None"}, Power: {Power}";
        }
    }
}
