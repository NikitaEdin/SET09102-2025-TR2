
namespace REA.DB {
    /// <summary>
    /// Provides methods for interacting with database
    /// </summary>
    /// <remarks>
    /// This interface defines async methods to manage database tables and entries.<br></br>
    /// Classes implementing this interface are expected to provide the database operations
    /// </remarks>
    /// 
    /// \author Nikita Lanetsky

    public interface IDatabaseService {
        /// <summary>
        /// Create new table in database
        /// </summary>
        /// <typeparam name="T">The type of the table (model) to create</typeparam>
        /// <returns>A task representing async operation</returns>
        Task CreateTableAsync<T>() where T : new();

        /// <summary>
        /// Insert item into database
        /// </summary>
        /// <typeparam name="T">The type of item to insert</typeparam>
        /// <param name="item">The item to insert into database</param>
        /// <returns>The number of rows affected</returns>
        Task<int> InsertAsync<T>(T item);

        /// <summary>
        /// Retrieves list of items from database
        /// </summary>
        /// <typeparam name="T">The type of items to retrieve</typeparam>
        /// <returns>A list of items from database</returns>
        Task<List<T>> GetItemsAsync<T>() where T : new();

        /// <summary>
        /// Delete item from database
        /// </summary>
        /// <typeparam name="T">The type of the item to delete</typeparam>
        /// <param name="item">The item to delete from database</param>
        /// <returns>The number of rows affected</returns>
        Task<int> DeleteAsync<T>(T item);

        /// <summary>
        /// Update item in database
        /// </summary>
        /// <typeparam name="T">The type of the item to update</typeparam>
        /// <param name="item">The item to update in database</param>
        /// <returns>The number of rows affected</returns>
        Task<int> UpdateAsync<T>(T item);
    }
}