
using SQLite;

namespace REA.Models {
    [Table("Users")]
    public  class User {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
