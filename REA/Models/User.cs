
using REA.DB;
using SQLite;

namespace REA.Models {
    /// <summary>
    /// User model which holds the user related record data
    /// Author: Nikita Lanetsky
    /// </summary>
    [Table("Users")]
    public  class User {
        [PrimaryKey, AutoIncrement]
        [Column("user_id")]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }


        /// <summary>
        /// Retrieve all records from database of this type
        /// </summary>
        /// <returns>Return list of Users from DB</returns>
        public static async Task<List<User>> GetAllUsersAsync() {
            var users = await SQLiteDatabaseService.Instance.GetItemsAsync<User>();
            return users?.ToList() ?? new List<User>();
        }

        /// <summary>
        /// Override the base ToString to print all object attributes
        /// </summary>
        /// <returns>String containing all object attributes</returns>
        public override string ToString() {
            return $"UserID: {UserID}, Username: {Username}, Password: {Password}";
        }
    }
}
