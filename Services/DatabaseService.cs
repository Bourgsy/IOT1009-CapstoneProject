using SQLite;
using NicksApp.Models;

namespace NicksApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "moods.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MoodEntry>().Wait();
        }

        public async Task<int> SaveMoodAsync(MoodEntry mood)
        {
            return await _database.InsertAsync(mood);
        }

        public async Task<double> GetGoodMoodPercentageAsync()
        {
            var today = DateTime.Today;
            var moods = await _database.Table<MoodEntry>()
                .Where(m => m.Timestamp.Date == today)
                .ToListAsync();

            if (!moods.Any()) return 0;
            return (double)moods.Count(m => m.IsGood) / moods.Count * 100;
        }
    }
}