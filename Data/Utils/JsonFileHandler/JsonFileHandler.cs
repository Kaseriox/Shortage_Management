using System.Text.Json;

namespace Data.Utils.JsonFileHandler;

public class JsonFileHandler : IJsonFileHandler
{
    private const string JsonFileEnding = ".json";
    public T? ReadFromJsonFile<T>(string fileName)
    {
        string fullFileName = GetFullFileName(fileName);
        string fileContent = File.ReadAllText(fullFileName);
        return JsonSerializer.Deserialize<T>(fileContent);
    }

    public void SaveToJsonFile<T>(string fileName, T entity)
    {
        string fullFileName = GetFullFileName(fileName);
        string serializedString = JsonSerializer.Serialize(entity);
        File.WriteAllText(fullFileName,serializedString);
    }

    public bool FileExists(string fileName)
    {
        string fullFileName = GetFullFileName(fileName);
        return File.Exists(fullFileName);
    }

    private string GetFullFileName(string fileName)
    {
        return string.Concat(fileName, JsonFileEnding);
    }
}