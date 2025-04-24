using SQLite;

namespace REA.DB {

    /// <summary>
    /// Provides SQLite-specific database functionality, implementing the singleton pattern for global access.
    /// </summary>
    /// <remarks>
    /// This service encapsulates SQL operations tailored for SQLite and ensures a single instance is used throughout the application.
    /// </remarks>
    /// 
    /// \author Nikita Lanetsky
    public class SQLiteDatabaseService : IDatabaseService {
        private SQLiteAsyncConnection _database;
        private static SQLiteDatabaseService? _instance;

        private static readonly object Locker = new object();

        /// <summary>
        /// Singleton instance of the database connection and access
        /// </summary>
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
                //TODO: keep commented for testing purposes
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

        // Init SQL connection
        _database = new SQLiteAsyncConnection(dbPath);

        }

        /// <summary>
        /// Inserts new item into database asynchronously
        /// </summary>
        /// <typeparam name="T">The type of the item to be inserted</typeparam>
        /// <param name="item">The item instance to insert</param>
        /// <returns>
        public async Task<int> InsertAsync<T>(T item) {
            return await _database.InsertAsync(item);
        }


        /// <summary>
        /// Retrieves all items of specified type from  database asynchronously
        /// </summary>
        /// <typeparam name="T">The type of items to retrieve</typeparam>
        /// <returns>
        /// A task representing asynchronous operation - containing a list of items retrieved from database.
        /// </returns>
        public async Task<List<T>> GetItemsAsync<T>() where T : new() {
            return await _database.Table<T>().ToListAsync();
        }


        /// <summary>
        /// Updates an existing record in database with specified item asynchronously
        /// </summary>
        /// <typeparam name="T">The type of the item to update</typeparam>
        /// <param name="item">The item containing updated values</param>
        /// <returns>
        /// A task representing asynchronous operation - containing the number of rows affected
        /// </returns>
        public async Task<int> UpdateAsync<T>(T item) {
            return await _database.UpdateAsync(item); 
        }


        /// <summary>
        /// Deletes specified item from database asynchronously
        /// </summary>
        /// <typeparam name="T">The type of item to delete</typeparam>
        /// <param name="item">The item instance to delete</param>
        /// <returns>
        /// A task representing asynchronous operation - containing the number of rows affected
        /// </returns>
        public async Task<int> DeleteAsync<T>(T item) {
            return await _database.DeleteAsync(item);
        }

        /// <summary>
        /// Create new table for specified type within database asynchronously
        /// </summary>
        /// <typeparam name="T">The type representing the table structure</typeparam>
        /// <returns>
        /// A task representing asynchronous operation
        /// </returns>
        public async Task CreateTableAsync<T>() where T : new() =>  await _database.CreateTableAsync<T>();
        
    }
}
