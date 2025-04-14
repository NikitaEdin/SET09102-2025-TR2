
namespace REA.DB {
    public interface IDatabaseService {
        Task CreateTableAsync<T>() where T : new();
        Task<int> InsertAsync<T>(T item);
        Task<int> UpdateAsync<T>(T item);
        Task<List<T>> GetItemsAsync<T>() where T : new();
        Task<int> DeleteAsync<T>(T item);
        Task<int> UpdateAsync<T>(T item);
    }
}
