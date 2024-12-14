using SQLite;
using NicksApp.Models;
using System.Diagnostics;

namespace NicksApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "moods.db");
            _database = new SQLiteAsyncConnection(dbPath);
            Task.Run(async () => await _database.CreateTableAsync<MoodEntry>()).Wait();
        }

        public async Task<int> SaveMoodAsync(MoodEntry mood)
        {
            try
            {
                return await _database.InsertAsync(mood);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Database Error: {ex.Message}");
                throw;
            }
        }

        public async Task<double> GetGoodMoodPercentageAsync()
        {
            try
            {
                var today = DateTime.Today;
                var moods = await _database.Table<MoodEntry>().ToListAsync();
                var todayMoods = moods.Where(m => m.Timestamp.Date == today).ToList();

                if (!todayMoods.Any()) return 0;
                return (double)todayMoods.Count(m => m.IsGood) / todayMoods.Count * 100;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Database Error: {ex.Message}");
                return 0;
            }
        }
    }
}