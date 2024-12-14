using SQLite;

namespace NicksApp.Models
{
    public class MoodEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Mood { get; set; }
        public bool IsGood { get; set; }
        public DateTime Timestamp { get; set; }
    }
}