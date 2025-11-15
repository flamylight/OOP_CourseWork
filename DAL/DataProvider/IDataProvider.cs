namespace DAL.DataProvider;

public interface IDataProvider<T>
{
    List<T> Load();
    void Save(List<T> list);
}