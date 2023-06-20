using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiHarianGuruService
{
    private readonly IMongoCollection<PresensiHarianGuru> _booksCollection;

    public PresensiHarianGuruService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<PresensiHarianGuru>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiHarianGuru>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiHarianGuru?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiHarianGuru newPresensiHarianGuru) =>
        await _booksCollection.InsertOneAsync(newPresensiHarianGuru);

    public async Task UpdateAsync(string id, PresensiHarianGuru updatedPresensiHarianGuru) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensiHarianGuru);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}