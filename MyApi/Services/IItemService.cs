namespace MyApi.Services;

public interface IItemService
{
    List<string> GetAll();
    
    void Add(string item);
    
    void Delete(string item);
    
    void Update(string oldItem, string newItem);
}
