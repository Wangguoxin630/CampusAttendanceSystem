using System.Text.Json;
using System.IO;

namespace CampusAttendanceSystem;

public static class FileManager
{
    private static string FilePath =>
        Path.Combine(FileSystem.AppDataDirectory, "records.json");

    public static void SaveRecords(List<AttendanceRecord> records)
    {
        string json = JsonSerializer.Serialize(records);
        File.WriteAllText(FilePath, json);
    }

    public static List<AttendanceRecord> LoadRecords()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<AttendanceRecord>>(json) ?? new();
        }
        return new();
    }
}

public class AttendanceRecord
{
    public string Type { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}