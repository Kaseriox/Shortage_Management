using Data.Utils.JsonFileHandler;

namespace Data.Repository;

public class JsonRepository<T> : IRepository<T>
{
    private readonly IJsonFileHandler _jsonFileHandler;
    private readonly string _jsonFileName;
    private readonly List<T> _items = [];

    public JsonRepository(IJsonFileHandler jsonFileHandler, string jsonFileName)
    {
        _jsonFileHandler = jsonFileHandler;
        _jsonFileName = jsonFileName;
        if (jsonFileHandler.FileExists(jsonFileName))
        {
            _items = _jsonFileHandler.ReadFromJsonFile<List<T>>(_jsonFileName) ?? [];
        }
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public void Add(T entity)
    {
        _items.Add(entity);
        SaveChangesToFile();
    }

    public void Remove(T entity)
    {
        _items.Remove(entity);
       SaveChangesToFile();
    }

    private void SaveChangesToFile()
    {
        _jsonFileHandler.SaveToJsonFile(_jsonFileName,_items);
    }
}