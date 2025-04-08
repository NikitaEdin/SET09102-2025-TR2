using REA.Models;
using SQLite;

namespace REA.DB {
    public class SQLiteDatabaseService : IDatabaseService {
        private SQLiteAsyncConnection _database;
        private static SQLiteDatabaseService? _instance;

        private static readonly object Locker = new object();

        public static SQLiteDatabaseService Instance {
            get {
                lock (Locker) {
                    if (_instance == null) {
                        _instance = new SQLiteDatabaseService();
                    }
                    return _instance;
                }
            }
        }

        private SQLiteDatabaseService() {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "local.db");

            try {
                //if (!File.Exists(dbPath)) {
                    var assembly = GetType().Assembly;
                    using (Stream stream = assembly.GetManifestResourceStream("REA.Resources.local.db")) {
                        if (stream != null) {
                            using (var fileStream = new FileStream(dbPath, FileMode.Create, FileAccess.Write)) {
                                stream.CopyTo(fileStream);
                            }
                        }
                    //}
                }
            } catch (Exception ex) { }

        // Ini SQLite connection
        _database = new SQLiteAsyncConnection(dbPath);

        }
      
        // Insert a new item into the database
        public async Task<int> InsertAsync<T>(T item) {
            return await _database.InsertAsync(item);
        }

        // Get all items of type T from the database
        public async Task<List<T>> GetItemsAsync<T>() where T : new() {
            return await _database.Table<T>().ToListAsync();
        }

        // Delete an item from the database
        public async Task<int> DeleteAsync<T>(T item) {
            return await _database.DeleteAsync(item);
        }

        public async Task CreateTableAsync<T>() where T : new() =>  await _database.CreateTableAsync<T>();
        
    }
}
