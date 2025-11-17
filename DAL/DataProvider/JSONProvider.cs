using System.Text.Json;
namespace DAL.DataProvider;

public class JSONProvider<T>: IDataProvider<T>
{
    private readonly string _filePath;

    public JSONProvider(string filePath)
    {
        _filePath = filePath;
    }

    public List<T> Load()
    {
        if (!File.Exists(_filePath))
        {
            return new List<T>();
        }
        
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();;
    }

    public void Save(List<T> items)
    {
        var json = JsonSerializer.Serialize(items);
        File.WriteAllText(_filePath, json);
    }
}