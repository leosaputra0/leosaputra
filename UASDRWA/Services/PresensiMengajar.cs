using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<PresensiMengajar> _booksCollection;

    public PresensiMengajarService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<PresensiMengajar>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiMengajar>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiMengajar?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newPresensiMengajar) =>
        await _booksCollection.InsertOneAsync(newPresensiMengajar);

    public async Task UpdateAsync(string id, PresensiMengajar updatedPresensiMengajar) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensiMengajar);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}