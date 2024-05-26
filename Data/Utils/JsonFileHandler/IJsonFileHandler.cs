namespace Data.Utils.JsonFileHandler;

public interface IJsonFileHandler
{
    T? ReadFromJsonFile<T>(string fileName);
    void SaveToJsonFile<T>(string fileName,T entity);
    bool FileExists(string fileName);
}