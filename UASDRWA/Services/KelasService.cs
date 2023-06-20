using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class KelasService
{
    private readonly IMongoCollection<Kelas> _booksCollection;

    public KelasService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<Kelas>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Kelas>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<Kelas?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Kelas newKelas) =>
        await _booksCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string id, Kelas updatedKelas) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedKelas);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}