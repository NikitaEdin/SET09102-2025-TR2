
using SQLite;

namespace REA.Models {
    /// <summary>
    /// Represents the user record
    /// </summary>
    /// 
    /// \author Nikita Lanetsky
    [Table("Users")]
    public  class User {
        /// <summary>Unique identifier for user</summary>
        [PrimaryKey, AutoIncrement]
        [Column("user_id")]
        public int UserID { get; set; }

        /// <summary>Username used for authentication</summary>
        public string Username { get; set; }

        /// <summary>Plain-text password</summary>
        /// \attention The user's password is currently stored in plain text - mainly for testing purposes
        public string Password { get; set; }

        /// <summary>Reference to the Role by its ID</summary>
        [Column("role_id")]
        public int RoleId { get; set; }


        /// <summary>
        /// Returns a string representation of the record
        /// </summary>
        /// <returns>String containing all record's attributes</returns>
        public override string ToString() {
            return $"UserID: {UserID}, Username: {Username}, Password: {Password}";
        }
    }
}
