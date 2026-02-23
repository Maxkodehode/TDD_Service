namespace MyApi.Services;

public interface IItemService
{
    List<string> GetAll();
    
    void Add(string item);
    
    void Delete(int id);
    
    void Update(int id, string newItem);
}
