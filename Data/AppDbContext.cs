using SQLite;
namespace duNotes.Data;

public class AppDbContext
{
    private readonly SQLiteAsyncConnection _db;

    public AppDbContext()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "duNotes.db3");
        _db = new SQLiteAsyncConnection(dbPath);

    }

    public SQLiteAsyncConnection Database => _db;

    public async Task InitializeAsync()
    {
        await _db.CreateTableAsync<Models.Filiere>();
        await _db.CreateTableAsync<Models.Matiere>();
        await _db.CreateTableAsync<Models.Document>();
        await _db.CreateTableAsync<Models.Avis>();
    }
}